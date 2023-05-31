using TranslationManagement.Api.Models;

namespace TranslationManagement.Api.Services
{
    public interface ITranslatorManagementService
    {
        TranslatorModel[] GetTranslators();
        TranslatorModel[] GetCertifiedTranslators();
        TranslatorModel[] GetTranslatorsByName(string name);
        bool AddTranslator(TranslatorModel translator);
        string UpdateTranslatorStatus(int Translator, string newStatus);
    }
}
