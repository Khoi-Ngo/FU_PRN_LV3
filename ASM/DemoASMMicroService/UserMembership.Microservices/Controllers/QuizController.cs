using Microsoft.AspNetCore.Mvc;

namespace UserMembership.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        private readonly List<Micro1.BusinessObject.Shared.Models.Quiz> quizs;
        public QuizController()
        {
            quizs = new List<Micro1.BusinessObject.Shared.Models.Quiz>()
            {
                new Micro1.BusinessObject.Shared.Models.Quiz()
                {
                  Id = 1,
                  Title = "Title A",
                }
          
            };
        }
        // GET: api/<UserMembershipController>
        [HttpGet]
        public IEnumerable<Micro1.BusinessObject.Shared.Models.Quiz> Get()
        {
            return quizs;
        }

        // GET api/<UserMembershipController>/5
        [HttpGet("{id}")]
        public Micro1.BusinessObject.Shared.Models.Quiz Get(long id)
        {
            return quizs.Find(gr => gr.Id == id);
        }

        // POST api/<UserMembershipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserMembershipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserMembershipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
