﻿using Company.Data;
using Company.Manager;
using Company.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyManager _ccmanager;
       private readonly ILogger<CompanyController> logger;

        public CompanyController(ICompanyManager ccmanager,ILogger<CompanyController> logger)
        {
            _ccmanager = ccmanager;
            this.logger = logger;
        }
        

        [HttpGet("GetCompany")]
        public IActionResult Get()
         {


            
            try
            {
                logger.LogInformation("Getting all the companydetails");
                var cc = _ccmanager.Getcomp();
                return Ok(cc);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }
        }




        [HttpPost("CreateCompany")]

        public IActionResult Create([FromBody] CompanyRequest request)
        {
           
            try
            {
                logger.LogInformation("Created all the companydetails");
                var cc = _ccmanager.Create(request);
                return Ok(cc);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }

        }

       [HttpPut("UpdateCompany")]
        public IActionResult Update([FromBody] CompanyRequest request)
        {
            

            try
            {
                logger.LogInformation("updated the companydetails");
                var cc = _ccmanager.Update(request);
                return Ok(cc);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }
        }

        [HttpDelete("DeleteCompany/{UserId}")]
        public IActionResult Delete([FromRoute]int UserId)
        {
            
            try
            {
                logger.LogInformation($"Deleted the companydetails of {UserId}");
                var cc = _ccmanager.Delete(UserId);
                return Ok(cc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }

        }

        [HttpGet("GetCompany/{Id}")]
        public IActionResult Get([FromRoute] int Id)
        {
            
            try
            {
                logger.LogInformation($"Getting the companydetails of {Id}");
                var cc = _ccmanager.Get(Id);
                return Ok(cc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }
        }

        

    }
}
