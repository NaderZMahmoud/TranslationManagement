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
       
        
       
        private readonly ILogger<TranslatorManagementController> _logger;
        private readonly ITranslationJobService _translationJobService;

        public TranslationJobController(ILogger<TranslatorManagementController> logger,ITranslationJobService translationJobService)
        {
           // _context = scopeFactory.CreateScope().ServiceProvider.GetService<AppDbContext>();
            _logger = logger;
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
            var success = _translationJobService.CreateJob(job);
            if (success) { 
                _logger.LogInformation("New job notification sent");
        }
            return success;
        }

        [HttpPost]
        public bool CreateJobWithFile(IFormFile file, string customer)
        {
            return _translationJobService.CreateJobWithFile(file, customer);
        }

        [HttpPost]
        public string UpdateJobStatus(int jobId, int translatorId, string newStatus = "")
        {
            _logger.LogInformation($"Job status update request received:{newStatus} for job { jobId.ToString()} by translator {translatorId}");
           return _translationJobService.UpdateJobStatus(jobId, translatorId, newStatus);
        }
    }
}