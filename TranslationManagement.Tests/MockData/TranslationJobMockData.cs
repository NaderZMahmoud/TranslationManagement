﻿using System;
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
                     Id = 2,
                    CustomerName = "Test2",
                    OriginalContent = "Test2",
                    Price = 2,
                    Status = JobStatus.Completed,
                },
                  new TranslationJob()
                {
                       Id = 3,
                    CustomerName = "Test3",
                    OriginalContent = "Test3",
                    Price = 3,
                    Status = JobStatus.InProgress,
                },
            };
        }
    }
}
