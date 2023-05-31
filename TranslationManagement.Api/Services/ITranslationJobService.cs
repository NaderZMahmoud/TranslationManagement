using Microsoft.AspNetCore.Http;
using TranslationManagement.Api.Models;

namespace TranslationManagement.Api.Services
{
    public interface ITranslationJobService
    {
        TranslationJob[] GetJobs();
        bool CreateJob(TranslationJob job);
        bool CreateJobWithFile(IFormFile file, string customer);
        string UpdateJobStatus(int jobId, int translatorId, string newStatus);
    }
}
