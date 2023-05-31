using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using External.ThirdParty.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.Models;
using TranslationManagement.Api.Services;

namespace TranslationManagement.Api.Controllers
{
    
    [ApiController]
    [Route("api/jobs/[action]")]
    public class TranslationJobController : ControllerBase
    {
       
        
       
        
        private readonly ITranslationJobService _translationJobService;

        public TranslationJobController(ITranslationJobService translationJobService)
        {
           
            _translationJobService = translationJobService;
        }

        [HttpGet]
        public TranslationJob[] GetJobs()
        {
            return _translationJobService.GetJobs();
        }




        [HttpPost]
        public bool CreateJob(TranslationJob job)
        {
            return _translationJobService.CreateJob(job);
           
        }

        [HttpPost]
        public bool CreateJobWithFile(IFormFile file, string customer)
        {
            return _translationJobService.CreateJobWithFile(file, customer);
        }

        [HttpPost]
        public string UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
        {
            
           return _translationJobService.UpdateJobStatus(jobId, translatorId, newStatus);
        }
    }
}