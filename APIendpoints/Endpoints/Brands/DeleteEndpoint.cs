using APIendpoints.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace APIendpoints.Endpoints.Brands
{
    public class DeleteEndpoint : EndpointBaseAsync
        .WithRequest<byte>
        .WithActionResult
    {
        private readonly IBrandRepository _repository;

        public DeleteEndpoint(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("brands/delete/{id}")]
        public override async Task<ActionResult> HandleAsync(byte id, CancellationToken cancellationToken = default)
        {
            var brand = await _repository.FindByIdAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            var result = await _repository.DeleteAsync(brand);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
