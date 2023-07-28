using CleanArchitecture.Application.Person.Commands;
using CleanArchitecture.Application.Person.Queries;
using CleanArchitecture.Application.Person.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _mediator.Send(new GetPersonById { Id = id });
            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllPersons()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePerson command)
        {
            var validator = new CreatePersonValidator();
            var validationResult = validator.Validate(command);
            return validationResult.IsValid 
                ? Ok(await _mediator.Send(command)) 
                : BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPerson = await _mediator.Send(new DeletePerson { Id = id });
            return Ok(deletedPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePerson command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}