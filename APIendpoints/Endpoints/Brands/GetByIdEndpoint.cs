using APIendpoints.Entities;
using APIendpoints.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace APIendpoints.Endpoints.Brands
{
    public class GetByIdEndpoint : EndpointBaseAsync
        .WithRequest<byte>
        .WithActionResult<Brand> 
    {
        private readonly IBrandRepository _repository;

        public GetByIdEndpoint(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("brands/{id}")]
        public override async Task<ActionResult<Brand>> HandleAsync(byte id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.FindByIdAsync(id);

            if (result.BrandName == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
