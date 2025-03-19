using BusinessService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.Models;

namespace API_SERVICE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly MainService mainService;

        public MainController(MainService mainService)
        {
            this.mainService = mainService;
        }
        [HttpGet]
        //[PermissionAuthorize("Admin", "Customer")]
        [PermissionAuthorize(1)]


        [EnableQuery]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await mainService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet("{idstr}")]
        //[PermissionAuthorize("Admin", "Customer")]
        [PermissionAuthorize(1)]

        [EnableQuery]
        public async Task<IActionResult> GetDetailAsync(string idstr)
        {
            try
            {
                return Ok(await mainService.GetDetailAsync(idstr));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpDelete("{idstr}")]
        //[PermissionAuthorize("Admin", "Customer")]

        [PermissionAuthorize(1)]

        public async Task<IActionResult> DeleteAsync(string idstr)
        {
            try
            {
                await mainService.DeleteAsync(idstr);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error when deleting.");
            }
        }
        //[HttpDelete("{id}")]
        ////[PermissionAuthorize("Admin", "Customer")]
        //public async Task<IActionResult> DeleteAsync(long id)
        //{
        //    try
        //    {
        //        await mainService.DeleteAsync(id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error when deleting.");
        //    }
        //}
        //[HttpGet("{id}")]
        ////[PermissionAuthorize("Admin", "Customer")]
        //[EnableQuery]
        //public async Task<IActionResult> GetDetailAsync(long id)
        //{
        //    try
        //    {
        //        return Ok(await mainService.GetDetailAsync(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpPut]
        //[PermissionAuthorize("Admin")]
        [PermissionAuthorize(1)]

        public async Task<IActionResult> UpdateAsync([FromBody] CosmeticInformation request)
        {
            try
            {
                await mainService.UpdateAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error when updating");
            }
        }


        [HttpPost]
        //[PermissionAuthorize("Admin")]
        [PermissionAuthorize(1)]


        public async Task<IActionResult> CreateAsync([FromBody] CosmeticInformation request)
        {
            try
            {
                await mainService.CreateAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating " });
            }
        }


        //SEARCH
        //[HttpGet]
        ////[PermissionAuthorize("Admin", "Customer")]
        //[EnableQuery]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    try
        //    {
        //        return Ok(await mainService.GetAllAsync());
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}


        //LOGIN

        //Authenticate
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO request)
        {
            try
            {
                return Ok(await mainService.LoginAsync(request.UserName, request.Password));
            }
            catch (Exception ex)
            {
                return BadRequest("Something wrong when login");
            }
        }
    }

}
