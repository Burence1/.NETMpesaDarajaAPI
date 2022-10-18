using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using MpesaDarajaAPI.Dtos.Requests;
using MpesaDarajaAPI.Enums;
using MpesaDarajaAPI.Dtos;
using MpesaDarajaAPI.Dtos.Reponses;
using RestSharp;
using RestSharp.Authenticators;

namespace MpesaDarajaAPI.BusinessLayer;

public class MpesaDarajaAPI
{
    private string _accessToken;
    private DateTime _tokenExpiryIn;
    private readonly string _consumerKey, _consumerSecret;
    public bool _isSandBox;
    private string baseUrl => _isSandBox ? "https://sandbox.safaricom.co.ke" : "https://api.safaricom.co.ke";
    private  readonly string authUrl ="oauth/v1/generate?grant_type=client_credentials";

    public MpesaDarajaAPI(string accessToken, string consumerSecret, string consumerKey, DateTime tokenExpiryIn)
    {
        _accessToken = "";
        _consumerKey = consumerKey;
        _consumerSecret = consumerSecret;
        _tokenExpiryIn = tokenExpiryIn;
    }

    private async Task<string> GenerateAccessToken()
    {
        if (_tokenExpiryIn > DateTime.Now) return _accessToken;
        try
        {
            RestClient restClient = new RestClient(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_consumerKey,_consumerSecret)
            };

            RestRequest request = new RestRequest(authUrl,Method.Get);
            request.AddHeader("Content-Type", "application/json");

            var response = await restClient.ExecuteAsync<AccessTokenDto>(request);
            if (response.IsSuccessful)
                throw new Exception(response.ErrorMessage);

            _tokenExpiryIn = DateTime.Now.AddSeconds(response.Data.expiryIn).AddMinutes(-1);
            _accessToken = response.Data.accessToken;

            return _accessToken;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<(S SuccessResponse, ErrorResponse errorResponse, bool IsSuccessful)> MpesaPostRequestsAsync<S>(
        string resourceUrl, string data) where S : new()
    {
        try
        {
            string token = await GenerateAccessToken();
            RestClient restClient = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(resourceUrl, Method.Post);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", $"Bearer {token}");
            restRequest.AddParameter("application/json;charset=utf-8", data, ParameterType.RequestBody);
            var response = await restClient.ExecuteAsync(restRequest);

            (S SuccessResponse, ErrorResponse errorResponse, bool IsSuccessful) result = (new S(), null, false);
            if (!response.IsSuccessful)
            {
                result.errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                result.IsSuccessful = false;
            }
            else
            {
                result.SuccessResponse = JsonConvert.DeserializeObject<S>(response.Content);
                result.IsSuccessful = true;
            }

            return result;
        }

        catch (Exception e)
        {
            throw e;
        }
    }


    private async Task<MpesaResponse> MpesaRequestsAsync(string url, string payload)
    {
        try
        {
            var result = await MpesaPostRequestsAsync<CommonSuccessResponse>(url, payload);
            return new MpesaResponse()
            {
                ErrorResponse = result.errorResponse,
                SuccessResponse = result.SuccessResponse,
                IsSuccess = result.IsSuccessful
            };
        }
        catch (Exception e)
        {
            throw e;
        }
    }


    private async Task<STKPushResponse> STKPushAsync(STKPushRequest request)
    {
        var response =
            await MpesaPostRequestsAsync<StkPushSuccessResponse>("mpesa/stkpush/v1/processrequest", request.ToString());
        return new STKPushResponse()
        {
            ErrorResponse = response.errorResponse,
            SuccessResponse = response.SuccessResponse,
            IsSuccess = response.IsSuccessful
        };
    }
}