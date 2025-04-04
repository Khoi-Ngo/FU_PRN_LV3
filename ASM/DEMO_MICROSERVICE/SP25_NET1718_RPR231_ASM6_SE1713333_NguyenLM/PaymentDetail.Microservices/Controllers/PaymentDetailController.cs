using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentDetail.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly List<BusinessObject.Shared.Models.> PaymentDetails;

        public PaymentDetailController()
        {
            PaymentDetails = new()
            {
                new BusinessObject.Shared.Models.PaymentDetail
                {
                    PaymentDetailId = 1,
                    
                }
            };
        }
        // GET: api/<PaymentDetailController>
        [HttpGet]
        public IEnumerable<BusinessObject.Shared.Models.PaymentDetail> Get()
        {
            return PaymentDetails;
        }

        // GET api/<PaymentDetailController>/5
        [HttpGet("{id}")]
        public BusinessObject.Shared.Models.PaymentDetail Get(int id)
        {
            return PaymentDetails.Find(p => p.PaymentDetailId == id);
        }

        // POST api/<PaymentDetailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaymentDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
