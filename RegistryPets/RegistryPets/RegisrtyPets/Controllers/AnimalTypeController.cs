using Microsoft.AspNetCore.Mvc;
using RegistryPets.RegisrtyPets.Models;
using RegistryPets.RegisrtyPets.Models.Requests;
using RegistryPets.RegisrtyPets.Services;

namespace RegistryPets.RegisrtyPets.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class AnimalTypeController : ControllerBase
        {
            private IAnimalTypeRepository _animalTypeRepository;

            public AnimalTypeController(IAnimalTypeRepository animalTypeRepository)
            {
                _animalTypeRepository = animalTypeRepository;
            }

            [HttpPost("create")]
            //[SwaggerOperation(OperationId = "CreateAnimalType")]
            public ActionResult<int> Create([FromBody] CreateAnimalTypeRequest createAnimalTypeRequest)
            {
                int res = _animalTypeRepository.Create(new AnimalType
                {
                    Type = createAnimalTypeRequest.Type,
                });
                return Ok(res);
            }

            [HttpPut("update")]
            //[SwaggerOperation(OperationId = "UpdateAnimalType")]
            public ActionResult<int> Update([FromBody] UpdateAnimalTypeRequest updateAnimalTypeRequest)
            {
                int res = _animalTypeRepository.Update(new AnimalType
                {
                    AnimalTypeId = updateAnimalTypeRequest.AnimalTypeId,
                    Type = updateAnimalTypeRequest.Type,
                });
                return Ok(res);
            }

            [HttpDelete("delete")]
            //[SwaggerOperation(OperationId = "DeleteAnimalType")]
            public ActionResult<int> Delete(int KindOfAnimalId)
            {
                int res = _animalTypeRepository.Delete(KindOfAnimalId);
                return Ok(res);
            }

            [HttpGet("getAll")]
           // [SwaggerOperation(OperationId = "GetAllAnimalType")]
            public ActionResult<List<AnimalType>> GetAll()
            {
                return Ok(_animalTypeRepository.GetAll());
            }

            [HttpGet("getById")]
            //[SwaggerOperation(OperationId = "GetAnimalTypeById")]
            public ActionResult<AnimalType> GetById(int AnimalTypeId)
            {
                return Ok(_animalTypeRepository.GetById(AnimalTypeId));
            }

        }
}
