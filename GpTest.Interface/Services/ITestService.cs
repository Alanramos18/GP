using Gp.Test.Api.DTO;

namespace Gp.Test.Interface.Services
{
    public interface ITestService
    {
        /// <summary>
        ///     Get all the personas.
        /// </summary>
        /// <returns>A list of personas</returns>
        IList<PersonasDTOResponse> Search(SearchPersonasDTORequest searchDto);

        /// <summary>
        ///     Get a single persona by id.
        /// </summary>
        /// <param name="id">Persona's id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>A single persona</returns>
        Task<PersonasDTOResponse> GetByIdAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        ///     Create a new persona
        /// </summary>
        /// <param name="dto">Persona DTO to be created</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<PersonasDTOResponse> CreatePersonaAsync(PersonasDTORequest dto, CancellationToken cancellationToken);

        /// <summary>
        ///     Update a persona.
        /// </summary>
        /// <param name="id">Person's id</param>
        /// <param name="dto">Persona DTO to be updated</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task UpdatePersonaAsync(string id, PersonasDTORequest dto, CancellationToken cancellationToken);

        /// <summary>
        ///     Check for Name-Dni duplicate validation
        /// </summary>
        /// <param name="dto">Persona DTO to be updated</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<bool> CheckDuplicateAsync(PersonasDTORequest dto, CancellationToken cancellationToken);
    }
}
