using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Profile.Models;
using Task_Profile.Dao;


namespace Task_Profile.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfo _personalInfo;

        public PersonalInfoController(IPersonalInfo personalInfo)
        {
            _personalInfo = personalInfo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persons>>> GetPersonInfo()
        {
            var persons = await _personalInfo.GetPersonInfo();
            if (persons == null)
            {
                return NotFound();
            }
            return Ok(persons);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Persons(Persons persons)
        {
            if (persons != null)
            {
                if (ModelState.IsValid)
                {
                    int res = await _personalInfo.InsertPerson(persons );
                    if (res > 0)
                    {
                        return Ok("Data Added");

                    }
                }
                return BadRequest("Database Failed to Add persons information");

            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdatePersonAddress(int id, string ResidentialAddress)
        {

            int? product = null;
            product = await _personalInfo.UpdatePersonAddress(id, ResidentialAddress);
            if (product != null) return NoContent();
            else return NotFound($"Id {id} Not Found");
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeletePersonById(int id)
        {
            int res = await _personalInfo.DeletePersonById(id);
            if (res != 0) return Ok(id);
            else return NotFound($"Id {id} not found");
        }

        [HttpGet("{id:int}", Name = "GetProduct")]

        public async Task<ActionResult<Persons>> GetProduct(int id)
        {
            Persons? pdtFound = await _personalInfo.GetPersonById(id);
            if (pdtFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pdtFound);
            }
        }

    }
}
