using BusinessService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.Models;

namespace API_SERVICE.Controllers
{
    [Route("api")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly MainService mainService;

        public MainController(MainService mainService)
        {
            this.mainService = mainService;
        }
        [HttpGet]
        [PermissionAuthorize(1,2,3)]
        [EnableQuery]
        public async Task<IActionResult> GetAllAsync() => Ok(await mainService.GetAllAsync());

        [HttpGet("{idstr}")]
        [PermissionAuthorize(1)]
        [EnableQuery]
        public async Task<IActionResult> GetDetailAsync(string idstr) => Ok(await mainService.GetDetailAsync(idstr));

        [HttpGet("viewbag")]
        [PermissionAuthorize(1)]
        public async Task<IActionResult> GetViewBag()
        {
            return Ok(await mainService.GetViewBag());
        }

        [HttpDelete("{idstr}")]
        [PermissionAuthorize(1, 2, 3)]
        public async Task<IActionResult> DeleteAsync(string idstr)
        {
            await mainService.DeleteAsync(idstr);
            return Ok();
        }

        [HttpPut]
        [PermissionAuthorize(1)]
        public async Task<IActionResult> UpdateAsync([FromBody] CosmeticInformation request)
        {
            await mainService.UpdateAsync(request);
            return Ok();
        }

        [HttpPost]
        [PermissionAuthorize(1)]
        public async Task<IActionResult> CreateAsync([FromBody] CosmeticInformation request)
        {
            await mainService.CreateAsync(await mainService.GetRequestWithId(request));
            return Ok();
        }

        [HttpPost("search")]
        [PermissionAuthorize(1, 2, 3)]
        public async Task<IActionResult> SearchAsync(SearchRequest request) => Ok(await mainService.SearchAsync(request.Item1, request.Item2, request.Item3));


        [HttpPost("search2")]
        [PermissionAuthorize(1, 2, 3)]
        public async Task<IActionResult> SearchAsync2(SearchRequest request)
        {
            return Ok(await mainService.SearchAsync2(request.Item1, request.Item2, request.Item3));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO request) => Ok(await mainService.LoginAsync(request.UserName, request.Password));



        //private TEntity MapToEntity<TDTO, TEntity>(TDTO dto) where TEntity : new()
        //{
        //    if (dto == null) return default;

        //    var entity = new TEntity();
        //    var dtoProperties = typeof(TDTO).GetProperties();
        //    var entityProperties = typeof(TEntity).GetProperties().ToDictionary(p => p.Name);

        //    foreach (var dtoProp in dtoProperties)
        //    {
        //        if (entityProperties.TryGetValue(dtoProp.Name, out var entityProp) &&
        //            entityProp.CanWrite &&
        //            entityProp.PropertyType.IsAssignableFrom(dtoProp.PropertyType))
        //        {
        //            entityProp.SetValue(entity, dtoProp.GetValue(dto));
        //        }
        //    }

        //    return entity;
        //}
  
    
    }
}
