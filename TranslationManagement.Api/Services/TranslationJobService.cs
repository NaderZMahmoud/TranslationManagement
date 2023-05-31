using External.ThirdParty.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Linq;
using System.Xml.Linq;
using TranslationManagement.Api.Models;

namespace TranslationManagement.Api.Services
{
    
    public class TranslationJobService : ITranslationJobService
    {
        const double PricePerCharacter = 0.01;
        private readonly AppDbContext _context;
        public TranslationJobService(AppDbContext context)
        {

            _context = context;

        }
        public bool CreateJob(TranslationJob job)
        {
            job.Status = JobStatus.New;
            SetPrice(job);
            _context.TranslationJobs.Add(job);
            bool success = _context.SaveChanges() > 0;
            if (success)
            {
                var notificationSvc = new UnreliableNotificationService();
                while (!notificationSvc.SendNotification("Job created: " + job.Id).Result)
                {
                }


            }

            return success;
        }
        private void SetPrice(TranslationJob job)
        {
            job.Price = job.OriginalContent.Length * PricePerCharacter;
        }
        public bool CreateJobWithFile(IFormFile file, string customer)
        {
            var reader = new StreamReader(file.OpenReadStream());
            string content;

            if (file.FileName.EndsWith(".txt"))
            {
                content = reader.ReadToEnd();
            }
            else if (file.FileName.EndsWith(".xml"))
            {
                var xdoc = XDocument.Parse(reader.ReadToEnd());
                content = xdoc.Root.Element("Content").Value;
                customer = xdoc.Root.Element("Customer").Value.Trim();
            }
            else
            {
                throw new NotSupportedException("unsupported file");
            }

            var newJob = new TranslationJob()
            {
                OriginalContent = content,
                TranslatedContent = "",
                CustomerName = customer,
            };

            SetPrice(newJob);

            return CreateJob(newJob);
        }

        public TranslationJob[] GetJobs()
        {
            return _context.TranslationJobs.ToArray();
        }

        public string UpdateJobStatus(int jobId, int translatorId, string newStatus)
        {
            //if (typeof(JobStatuses).GetProperties().Count(prop => prop.Name == newStatus) == 0)
            if (!Enum.TryParse<JobStatus>(newStatus, true, out _))
            {
                return "invalid status";
            }

            var job = _context.TranslationJobs.Single(j => j.Id == jobId);

            bool isInvalidStatusChange = (job.Status == JobStatus.New && newStatus == JobStatus.Completed.ToString()) ||
                                         job.Status == JobStatus.Completed || newStatus == JobStatus.New.ToString();
            if (isInvalidStatusChange)
            {
                return "invalid status change";
            }

            job.Status = Enum.Parse<JobStatus>(newStatus, true);
            _context.SaveChanges();
            return "updated";
        }
    }
}
