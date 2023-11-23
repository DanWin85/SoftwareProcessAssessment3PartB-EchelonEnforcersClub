using EchelonEnforcers.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace EchelonEnforcers.Tests
{
    public class CompetitionsModelsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CompetitionsModelsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Create_Competitions_Should_Return_Successful_Response()
        {
           
            var client = _factory.CreateClient();
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "bob@EchelonEnforcers.com"),
                
            }, "test"));

            
            client.DefaultRequestHeaders.Add("Authorization",
                "Bearer " + Guid.NewGuid()); 

            var competitionsModel = new CompetitionsModel
            {
                Title = "Test News",
                Content = "This is a test competition.",
                Details = "This is a test competition",
                DateTime = DateTime.Now,
                Location = "Test",
                PublishedDate = DateTimeOffset.Now,
                Author = user.Identity.Name,
            };


            var content = new StringContent(JsonConvert.SerializeObject(competitionsModel), Encoding.UTF8, "application/json");


            var response = await client.PostAsync("/CompetitionsModels/Create", content);


            response.EnsureSuccessStatusCode();

        }
    }
}
