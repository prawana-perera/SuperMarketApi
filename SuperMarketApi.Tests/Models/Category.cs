using System;
using Xunit;

using Supermarket.API.Models;

namespace SuperMarketApi.Tests.Models
{
    public class CategoryTests
    {
        private Category _category;

        [Fact]
        public void IsGoodCategory_WhenBooks_ShouldReturnFalse()
        {
            _category = new Category {
                Id = 1,
                Name = "Books"
            };

            var isGood = _category.IsGoodCategory();

            Assert.False(isGood, "Books should not be a good category");
        }

        [Fact]
        public void IsGoodCategory_WhenBedding_ShouldReturnTrue()
        {
            _category = new Category {
                Id = 1,
                Name = "Bedding"
            };

            var isGood = _category.IsGoodCategory();

            Assert.True(isGood, "Bedding should be a good category");
        }

        [Fact]
        public void IsGoodCategory_WhenNull_ShouldReturnFalse()
        {
            _category = new Category {
                Id = 1
            };

            var isGood = _category.IsGoodCategory();

            Assert.False(isGood, "Null category should not be a good category");
        }
    }
}
