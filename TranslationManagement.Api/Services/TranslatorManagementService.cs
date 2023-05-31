using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TranslationManagement.Api.Controlers;
using TranslationManagement.Api.Models;

namespace TranslationManagement.Api.Services
{
    public class TranslatorManagementService : ITranslatorManagementService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TranslatorManagementController> _logger;

        public TranslatorManagementService(AppDbContext context, ILogger<TranslatorManagementController> logger)
        {
            _context = context;
            //_context = scopeFactory.CreateScope().ServiceProvider.GetService<AppDbContext>();
            _logger = logger;
        }
        public bool AddTranslator(TranslatorModel translator)
        {
            _context.Translators.Add(translator);
            return _context.SaveChanges() > 0;
        }

        public TranslatorModel[] GetTranslators()
        {
            return _context.Translators.ToArray();
        }

        public TranslatorModel[] GetTranslatorsByName(string name)
        {
            return _context.Translators.Where(t => t.Name == name).ToArray();
        }

        public string UpdateTranslatorStatus(int Translator, string newStatus)
        {
            _logger.LogInformation($"User status update request: {newStatus} for user {Translator.ToString()}");
            // if (TranslatorStatuses.Where(status => status == newStatus).Count() == 0)
            if (Enum.TryParse<TranslatorStatus>(newStatus, true, out _))
            {
                throw new ArgumentException("unknown status");
            }

            var translator = _context.Translators.Single(j => j.Id == Translator);
            translator.Status = Enum.Parse<TranslatorStatus>(newStatus, true);
            _context.SaveChanges();

            return "updated";
        }
    }
}
