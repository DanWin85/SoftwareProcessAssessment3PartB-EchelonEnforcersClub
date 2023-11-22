using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using EchelonEnforcers.Models;
using System.Security.Claims;

namespace Echelon_Enforcers.Tests
{
    public class NewsModelsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public NewsModelsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task CreateNews_Should_Return_Successful_Response()
        {
            // Arrange
            var client = _factory.CreateClient();
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "bob@EchelonEnforcers.com"), 
                // You can add other claims as needed
            }, "test"));

            // Set the user for the request
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Guid.NewGuid()); // Assuming Bearer token authentication

            var newsModel = new NewsModel
            {
                // Provide necessary properties for creating a news item
                Heading = "Test News",
                Content = "This is a test news article.",
                PublishedDate = DateTimeOffset.Now,
                Author = user.Identity.Name,
                Visible = true,
                // Add other properties as needed
            };

            // Convert the newsModel to JSON
            var content = new StringContent(JsonConvert.SerializeObject(newsModel), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/NewsModel/Create", content);

            // Assert
            response.EnsureSuccessStatusCode();
            // Add additional assertions based on your requirements
        }
    }
}