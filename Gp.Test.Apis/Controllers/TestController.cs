namespace GP.Test.Apis.Controllers
{
    using System.Threading;
    using Gp.Test.Api.DTO;
    using Gp.Test.Interface.Services;
    using Gp.Test.Interface.Validations;
    using GP.Test.Apis.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ITestValidation _testValidation;

        public TestController(ITestService testService, ITestValidation testValidation)
        {
            _testService= testService;
            _testValidation= testValidation;
        }

        /// <summary>
        ///     Search for Personas by filter
        /// </summary>
        /// <returns>A list of personas</returns>
        /// <response code="200">Ok.</response>
        /// <response code="404">Not found.</response>
        [HttpPost("Search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonasDTOResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Search([FromBody]SearchPersonasDTORequest searchDto, CancellationToken cancellationToken)
        {
            try
            {
                var result = _testService.Search(searchDto);

                if (result == null || result.Count == 0)
                {
                    return new NotFoundObjectResult("No records were found");
                }

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        ///     Get a Persona
        /// </summary>
        /// <param name="id">Id of the persona</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>A single persona</returns>
        /// <response code="200">Ok.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonasDTOResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            try
            {
                if(!_testValidation.ValidateId(id))
                {
                    return new BadRequestObjectResult("Id format is wrong");
                }

                var result = await _testService.GetByIdAsync(id, cancellationToken);

                if (result == null)
                {
                    return new NotFoundObjectResult("No record was found");
                }

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     Create a new Persona
        /// </summary>
        /// <param name="dto">Dto of the persona</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>A new persona</returns>
        /// <response code="201">Created.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Not found.</response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonasDTOResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePersonaAsync([FromBody] PersonasDTORequest dto, CancellationToken cancellationToken = default)
        {
            try
            {
                _testValidation.ValidatePersona(dto);

                var isDuplicated = await _testService.CheckDuplicateAsync(dto, cancellationToken);

                if (isDuplicated)
                {
                    return new BadRequestObjectResult("That name/dni combination already exists");
                }

                var result = await _testService.CreatePersonaAsync(dto, cancellationToken);

                return new CreatedAtRouteResult("CreatePersonaAsync", result);
            }
            catch(TestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     Update a Persona
        /// </summary>
        /// <param name="dto">Dto of the persona</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>An updated persona</returns>
        /// <response code="200">Ok.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonasDTOResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonaAsync([FromRoute]string id, [FromBody] PersonasDTORequest dto, CancellationToken cancellationToken = default)
        {
            try
            {
                await _testService.UpdatePersonaAsync(id, dto, cancellationToken);

                return new OkObjectResult("Persona updated");
            }
            catch (TestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
