using AutoMapper;
using Gp.Test.Api.DTO;
using Gp.Test.Entity;
using Gp.Test.Interface.Repositories;
using Gp.Test.Interface.Services;

namespace Gp.Test.Business.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public IList<PersonasDTOResponse> Search(SearchPersonasDTORequest searchDto)
        {
            try
            {
                var result = _testRepository.Search(searchDto);

                if (result == null)
                {
                    return null;
                }

                var response = result.Select(_mapper.Map<Personas, PersonasDTOResponse>);

                return response.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <inheritdoc />
        public async Task<PersonasDTOResponse> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var result = await _testRepository.GetByIdAsync(Guid.Parse(id), cancellationToken);

            if (result == null)
            {
                return null;
            }

            var response = _mapper.Map<PersonasDTOResponse>(result);

            return response;
        }

        /// <inheritdoc />
        public async Task<PersonasDTOResponse> CreatePersonaAsync(PersonasDTORequest dto, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Personas>(dto);

                if (entity != null)
                {
                    await _testRepository.AddAsync(entity, cancellationToken);
                    await _testRepository.SaveChangesAsync(cancellationToken);
                }

                return _mapper.Map<PersonasDTOResponse>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public async Task UpdatePersonaAsync(string id, PersonasDTORequest dto, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _testRepository.GetByIdAsync(Guid.Parse(id), cancellationToken);

                if (entity == null)
                {
                    return;
                }

                entity.NombreCompleto = dto.NombreCompleto;
                entity.Edad = dto.Edad;
                entity.Domicilio = dto.Domicilio;
                entity.Telefono = dto.Telefono;
                entity.Profesion = dto.Profesion;
                entity.Dni= dto.Dni;

                _testRepository.Update(entity);
                await _testRepository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <inheritdoc />
        public Task<bool> CheckDuplicateAsync(PersonasDTORequest dto, CancellationToken cancellationToken)
        {
            return _testRepository.CheckDuplicateAsync(dto.NombreCompleto, dto.Dni, cancellationToken);
        }
    }
}
