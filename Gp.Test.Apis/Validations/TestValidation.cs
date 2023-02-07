using System.Text.RegularExpressions;
using Gp.Test.Api.DTO;
using Gp.Test.Interface.Validations;
using GP.Test.Apis.Exceptions;

namespace GP.Test.Apis.Validations
{
    public class TestValidation : ITestValidation
    {
        /// <inheritdoc />
        public bool ValidateId(string id)
        {
            if(string.IsNullOrEmpty(id))
                return false;

            string strRegex = @"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(id))
                return true;
            else
                return false;
        }

        /// <inheritdoc />
        public void ValidatePersona(PersonasDTORequest dto)
        {
            if (dto == null) throw new TestException("Dto is empty");

            if (string.IsNullOrEmpty(dto.Dni) || dto.Dni.Length != 8)
            {
                throw new TestException("DNI is invalid");
            }

            if (string.IsNullOrEmpty(dto.Telefono) || dto.Telefono.Length != 8)
            {
                throw new TestException("Telefono is invalid");
            }
               
            // Continue with more validations....
        }
    }
}
