using APIendpoints.Entities;
using APIendpoints.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace APIendpoints.Endpoints.Brands
{
    public class CreateEndpoint : EndpointBaseAsync
        .WithRequest<string>
        .WithoutResult
    {
        private readonly IBrandRepository _repository;

        public CreateEndpoint(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("brands/add")]
        public override async Task<ActionResult> HandleAsync([FromBody] string brandName, CancellationToken cancellationToken = default)
        {
            var brand = new Brand()
            {
                BrandName = brandName
            };

            var result = await _repository.CreateAsync(brand);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
