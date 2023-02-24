using Microsoft.AspNetCore.Mvc;
using RegistryPets.RegisrtyPets.Models;
using RegistryPets.RegisrtyPets.Models.Requests;
using RegistryPets.RegisrtyPets.Services;

namespace RegistryPets.RegisrtyPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpPost("create")]
        //[SwaggerOperation(OperationId = "CreateSkill")]
        public ActionResult<int> Create([FromBody] CreateSkillRequest createSkillRequest)
        {
            int res = _skillRepository.Create(new Skill
            {
                AnimalTypeId = createSkillRequest.AnimalTypeId,
                CharacterSkill = createSkillRequest.CharacterSkill,
            });
            return Ok(res);
        }

        [HttpPut("update")]
       // [SwaggerOperation(OperationId = "UpdateSkill")]
        public ActionResult<int> Update([FromBody] UpdateSkillRequest updateSkillRequest)
        {
            int res = _skillRepository.Update(new Skill
            {
                SkillId = updateSkillRequest.SkillId,
                CharacterSkill = updateSkillRequest.CharacterSkill,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        //[SwaggerOperation(OperationId = "DeleteSkill")]
        public ActionResult<int> Delete(int skillId)
        {
            int res = _skillRepository.Delete(skillId);
            return Ok(res);
        }

        [HttpGet("getAll")]
        //[SwaggerOperation(OperationId = "GetAllSkills")]
        public ActionResult<List<Skill>> GetAll()
        {
            return Ok(_skillRepository.GetAll());
        }

        [HttpGet("getById")]
        //[SwaggerOperation(OperationId = "GetSkillById")]
        public ActionResult<Skill> GetById(int skillId)
        {
            return Ok(_skillRepository.GetById(skillId));
        }
    }
}
