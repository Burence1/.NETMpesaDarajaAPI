using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpesaDarajaAPI.Data;
using MpesaDarajaAPI.Dtos.Requests;
using MpesaDarajaAPI.BusinessLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MpesaDarajaAPI.Controller
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class MpesaDarajaApiController : ControllerBase
    {
        private AppDbContext _context;
        private static BusinessLayer.MpesaDarajaAPI _mpesaDarajaApi;

        public MpesaDarajaApiController(AppDbContext context,BusinessLayer.MpesaDarajaAPI darajaApi)
        {
            _context = context;
            _mpesaDarajaApi = darajaApi;
        }

        [HttpGet]
        [Route("register-urls")]
        public Task RegisterMpesaUrls(C2BRegisterUrlRequest request)
        {
            return _mpesaDarajaApi.C2BRegUrlAsync(request); ;
        }


        // POST api/<MpesaDarajaApiController>
        //[HttpPost]
        //[Route("register-urls")]
        //public void Post([FromBody] string value)
        //{
        //}

        
    }
}
