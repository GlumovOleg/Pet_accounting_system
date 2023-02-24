using Microsoft.AspNetCore.Mvc;
using RegistryPets.RegisrtyPets.Models;
using RegistryPets.RegisrtyPets.Models.Requests;
using RegistryPets.RegisrtyPets.Services;

namespace RegistryPets.RegisrtyPets.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AnimalController : ControllerBase
        {
            private IAnimalRepository _animalRepository;

            public AnimalController(IAnimalRepository animalRepository)
            {
                _animalRepository = animalRepository;
            }


            [HttpPost("create")]
            //[SwaggerOperation(OperationId = "AnimalCreate")]
            public ActionResult<int> Create([FromBody] CreateAnimalRequest createAnimalRequest)
            {
                int result = _animalRepository.Create(new Animal
                {
                    AnimalTypeId = createAnimalRequest.AnimalTypeId,
                    Name = createAnimalRequest.Name,
                    Birthday = createAnimalRequest.Birthday,
                    Description = createAnimalRequest.Description,
                });
                return Ok(result);
            }


            [HttpPut("update")]
            //[SwaggerOperation(OperationId = "AnimalUpdate")]
            public ActionResult<int> Update([FromBody] UpdateAnimalRequest updateAnimalRequest)
            {
                int result = _animalRepository.Update(new Animal
                {
                    AnimalId = updateAnimalRequest.AnimalId,
                    Name = updateAnimalRequest.Name,
                    Birthday = updateAnimalRequest.Birthday,
                    Description = updateAnimalRequest.Description,
                });
                return Ok(result);
            }


            [HttpDelete("delete")]
            //[SwaggerOperation(OperationId = "AnimalDelete")]
            public ActionResult<int> Delete(int animalId)
            {
                int result = _animalRepository.Delete(animalId);
                return Ok(result);
            }


            [HttpGet("getAll")]
            //[SwaggerOperation(OperationId = "AnimalGetAll")]
            public ActionResult<List<Animal>> GetAll()
            {
                return Ok(_animalRepository.GetAll());
            }


            [HttpGet("getById")]
            //[SwaggerOperation(OperationId = "AnimalGetById")]
            public ActionResult<Animal> GetById(int animalId)
            {
                return Ok(_animalRepository.GetById(animalId));
            }

    }
}
