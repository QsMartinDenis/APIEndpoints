using APIendpoints.Endpoints.Brands;
using APIendpoints.Entities;
using APIendpoints.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace APIendpointsTests.Endpoints
{
    public class GetAllBrandEnpointTests
    {
        private readonly IBrandRepository _rep;
        public GetAllBrandEnpointTests()
        {
            _rep = A.Fake<IBrandRepository>();
        }

        [Fact]
        public async void GetAllEndpoint_GetBrands_ReturnOk()
        {
            //Arrange
            var brands = A.Fake<IEnumerable<Brand>>();
            A.CallTo(() => _rep.GetAsync()).Returns(brands);
            var endpoint = new GetAllEndpoint(_rep);
                
            //Act
            var result = await endpoint.HandleAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<Brand>>));
        }
    }
}
