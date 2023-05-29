using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationManagement.Api.Models;

namespace TranslationManagement.Tests.MockData
{
    public class TranslationJobMockData
    {
        public static List<TranslationJob> GetJobs()
        {
            return new List<TranslationJob>()
            {
                new TranslationJob()
                { 
                    Id = 1,
                    CustomerName = "Test",
                    OriginalContent = "Test",   
                    Price = 1,
                    Status = JobStatus.New,


                },
                 new TranslationJob()
                {

                },
                  new TranslationJob()
                {

                },
            };
        }
    }
}
