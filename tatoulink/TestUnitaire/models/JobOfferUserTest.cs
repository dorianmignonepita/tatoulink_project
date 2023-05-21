using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using tatoulink.Controllers;
using tatoulink.DataAccess.EfModels;
using tatoulink.DataAccess.Repositories;
using tatoulink.Dbo;
using Xunit;
using JobOfferUser = tatoulink.Dbo.JobOfferUser;

namespace TestUnitaire.models
{
    public class JobOfferUserTest
    {
        [Fact]
        public async Task TestCreateJobOffer()
        {
            var id = 1;
            var jobOfferId = 2;
            var userId = "Dorian aime beaucoup le C#";

            var jobOfferUser = new JobOfferUser
            {
                Id = 1,
                JobOfferId = 2,
                UserId = "Dorian aime pas beaucoup le C#",
            };

            var jobOfferUser2 = new JobOfferUser
            {
                Id = 2,
                JobOfferId = 3,
                UserId = "Dorian aime beaucoup le C#",
            };

            Assert.Equal(jobOfferUser.Id, id);
            Assert.Equal(jobOfferUser.UserId, userId);
            Assert.NotEqual(jobOfferUser.JobOfferId, jobOfferId);
            Assert.NotEqual(jobOfferUser2.Id, id);
            Assert.Equal(jobOfferUser2.UserId, userId);
            Assert.NotEqual(jobOfferUser2.JobOfferId, jobOfferId);
        }
    }
}
