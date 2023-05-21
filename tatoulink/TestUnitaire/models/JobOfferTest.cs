using tatoulink.Controllers;
using tatoulink.DataAccess.Repositories;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using DbContext = tatoulink.DataAccess.EfModels.DbContext;
using JobOffer = tatoulink.Dbo.JobOffer;

namespace tatoulink.TestUnitaire
{
    public class JobOffersControllerTests
    {
        private readonly Mock<tatoulink.DataAccess.EfModels.DbContext> _mockContext;
        private readonly Mock<ILogger<JobOfferRepository>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly JobOffersController _controller;


        [Fact]
        public void TestJobOfferProperties()
        {
            // Arrange
            int expectedId = 1;
            string expectedOfferName = "Test Job Offer";
            string expectedDescription = "This is a test job offer";
            DateTime expectedCreationDate = DateTime.Now;
            int expectedType = 1;
            string expectedDuration = "Full-time";
            DateTime expectedExpiringDate = DateTime.Now.AddDays(30);
            string expectedCreatorId = "123456";

            Dbo.JobOffer jobOffer = new Dbo.JobOffer
            {
                Id = expectedId,
                OfferName = expectedOfferName,
                Description = expectedDescription,
                CreationDate = expectedCreationDate,
                Type = expectedType,
                Duration = expectedDuration,
                ExpiringDate = expectedExpiringDate,
                CreatorId = expectedCreatorId
            };

            // Assert
            Assert.Equal(expectedId, jobOffer.Id);
            Assert.Equal(expectedOfferName, jobOffer.OfferName);
            Assert.Equal(expectedDescription, jobOffer.Description);
            Assert.Equal(expectedCreationDate, jobOffer.CreationDate);
            Assert.Equal(expectedType, jobOffer.Type);
            Assert.Equal(expectedDuration, jobOffer.Duration);
            Assert.Equal(expectedExpiringDate, jobOffer.ExpiringDate);
            Assert.Equal(expectedCreatorId, jobOffer.CreatorId);
        }


        [Fact]
        public async Task TestCreateJobOffer()
        {
            // Arrange
            var dbContextMock = new Mock<DbContext>();
            var jobOfferRepositoryMock = new Mock<JobOfferRepository>(dbContextMock.Object, null, null);
            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<JobOfferRepository>>();

            var jobOfferController = new JobOffersController(dbContextMock.Object, mapperMock.Object, loggerMock.Object);

            var jobOffer = new JobOffer
            {
                Id = 1,
                OfferName = "Test Job Offer",
                Description = "This is a test job offer",
                CreationDate = DateTime.Now,
                Type = 1,
                Duration = "Full-time",
                ExpiringDate = DateTime.Now.AddDays(30),
                CreatorId = "123456"
            };

            var expectedRedirectResult = new RedirectToActionResult("Index", null, null);

            var httpContext = new DefaultHttpContext();
            var actionContext = new ActionContext(httpContext, new(), new(), new());
            jobOfferController.ControllerContext = new ControllerContext(actionContext);

            // Act
            var result = await jobOfferController.Create(jobOffer);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.Equal(expectedRedirectResult.ActionName, redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
            Assert.Null(redirectResult.RouteValues);
        }
    }
    }
