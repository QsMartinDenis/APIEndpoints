using APIendpoints.Entities;
using APIendpoints.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace APIendpoints.Endpoints.Brands
{
    public class GetAllEndpoint : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<IEnumerable<Brand>>
    {
        private readonly IBrandRepository _repository;

        public GetAllEndpoint(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("brands")]
        public override async Task<ActionResult<IEnumerable<Brand>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var brands = await _repository.GetAsync();
            return Ok(brands);
        }
    }
}
