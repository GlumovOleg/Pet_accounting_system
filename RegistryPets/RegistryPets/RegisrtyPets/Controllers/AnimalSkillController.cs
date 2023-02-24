using Microsoft.AspNetCore.Mvc;
using RegistryPets.RegisrtyPets.Models;
using RegistryPets.RegisrtyPets.Models.Requests;
using RegistryPets.RegisrtyPets.Services;

namespace RegistryPets.RegisrtyPets.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AnimalSkillController : ControllerBase
        {
            private IAnimalSkillRepository _animalSkillRepository;

            public AnimalSkillController(IAnimalSkillRepository animalSkillRepository)
            {
                _animalSkillRepository = animalSkillRepository;
            }

            [HttpPost("create")]
            //[SwaggerOperation(OperationId = "CreateAnimalSkill")]
            public ActionResult<int> Create([FromBody] CreateAnimalSkillRequest createSkillRequest)
            {
                int res = _animalSkillRepository.Create(new AnimalSkill
                {
                    AnimalId = createSkillRequest.AnimalId,
                    SkillId = createSkillRequest.SkillId,
                });
                return Ok(res);
            }

            [HttpPut("update")]
            //[SwaggerOperation(OperationId = "UpdateAnimalSkill")]
            public ActionResult<int> Update([FromBody] UpdateAnimalSkillRequest updateSkillRequest)
            {
                int res = _animalSkillRepository.Update(new AnimalSkill
                {
                    AnimalSkillId = updateSkillRequest.AnimalSkillId,
                    SkillId = updateSkillRequest.SkillId,
                });
                return Ok(res);
            }

            [HttpDelete("delete")]
            //[SwaggerOperation(OperationId = "DeleteAnimalSkill")]
            public ActionResult<int> Delete(int animalSkillId)
            {
                int res = _animalSkillRepository.Delete(animalSkillId);
                return Ok(res);
            }

            [HttpGet("getAll")]
            //[SwaggerOperation(OperationId = "GetAllAnimalSkills")]
            public ActionResult<List<AnimalSkill>> GetAll()
            {
                return Ok(_animalSkillRepository.GetAll());
            }

            [HttpGet("getById")]
            //[SwaggerOperation(OperationId = "GetAnimalSkillById")]
            public ActionResult<AnimalSkill> GetById(int animalSkillId)
            {
                return Ok(_animalSkillRepository.GetById(animalSkillId));
            }

        }
}
