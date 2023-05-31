using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TranslationManagement.Api.Models;
using TranslationManagement.Api.Services;

namespace TranslationManagement.Api.Controlers
{
    [ApiController]
    [Route("api/TranslatorsManagement/[action]")]
    public class TranslatorManagementController : ControllerBase
    {
       

       // public static readonly string[] TranslatorStatuses = { "Applicant", "Certified", "Deleted" };

       
       
        private readonly ITranslatorManagementService _translatorManagementService;

        public TranslatorManagementController(ITranslatorManagementService translatorManagementService)
        {
           
            _translatorManagementService = translatorManagementService;
        }

        [HttpGet]
        public TranslatorModel[] GetTranslators()
        {
            return _translatorManagementService.GetTranslators();
        }

        [HttpGet]
        public TranslatorModel[] GetTranslatorsByName(string name)
        {
           return  _translatorManagementService.GetTranslatorsByName(name);
        }

        [HttpPost]
        public bool AddTranslator(TranslatorModel translator)
        {
           return _translatorManagementService.AddTranslator(translator);
        }
        
        [HttpPost]
        public string UpdateTranslatorStatus(int Translator, string newStatus = "")
        {
            
           return _translatorManagementService.UpdateTranslatorStatus(Translator, newStatus);
        }
    }
}