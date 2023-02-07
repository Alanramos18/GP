using Gp.Test.Api.DTO;

namespace Gp.Test.Interface.Validations
{
    public interface ITestValidation
    {
        /// <summary>
        ///     Validate id format.
        /// </summary>
        /// <param name="id">Id of persona</param>
        /// <returns></returns>
        bool ValidateId(string id);

        /// <summary>
        ///     Validate persona properties
        /// </summary>
        /// <param name="dto">Dto to validate</param>
        void ValidatePersona(PersonasDTORequest dto);
    }
}
