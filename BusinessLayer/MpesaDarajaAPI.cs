using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using MpesaDarajaAPI.Dtos.Requests;
using MpesaDarajaAPI.Enums;
using MpesaDarajaAPI.Dtos;
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

    private async Task<string> generateAccessToken()
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
}