using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Supermarket.API.Models;
using Xunit;

namespace SuperMarketApi.IntegrationTests
{
    public class CategoriesApiTest : IClassFixture<CustomWebApplicationFactory<SuperMarketApi.Startup>>
    {
        private readonly CustomWebApplicationFactory<SuperMarketApi.Startup> _factory;
        private readonly HttpClient _client;

        public CategoriesApiTest(CustomWebApplicationFactory<SuperMarketApi.Startup> factory)
        {
            _factory = factory;

            // Arrange
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Categories_ReturnsListOfCategories()
        {
            // Act
            var response = await _client.GetAsync("/api/categories");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(content);

            Assert.Equal(2, categories.Count());
        }

        [Fact]
        public async Task Post_Categories_CreatesAndReturnsNewCategory()
        {
            // Act
            var category = new CategoryDTO()
            {
                Name = "Bedding"
            };

            var response = await _client.PostAsync(
                "/api/categories",
                new StringContent(
                    JsonConvert.SerializeObject(category),
                    Encoding.UTF8,
                    "application/json"
                )
            );

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var createdCategory = JsonConvert.DeserializeObject<CategoryDTO>(content);

            Assert.Equal(category.Name, createdCategory.Name);
            Assert.NotNull(createdCategory.Id); // whats the best way to ensure ID is defined

            Assert.Equal($"/api/Categories/{createdCategory.Id}", response.Headers.Location.AbsolutePath);
        }
    }
}
