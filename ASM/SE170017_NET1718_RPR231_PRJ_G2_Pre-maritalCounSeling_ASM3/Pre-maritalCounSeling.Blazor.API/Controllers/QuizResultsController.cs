using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Pre_maritalCounSeling.BAL.Auth;
using Pre_maritalCounSeling.BAL.ServiceQuiz;
using Pre_maritalCounSeling.BAL.ServiceUser;
using Pre_maritalCounSeling.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Pre_maritalCounSeling.Blazor.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuizResultsController : ControllerBase
    {
        #region Fields and Constructor

        private readonly ILogger<QuizResultsController> _logger;
        private readonly IQuizResultService _quizResultService;
        private readonly IUserService _userService;

        public QuizResultsController(ILogger<QuizResultsController> logger, IQuizResultService quizResultService, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _quizResultService = quizResultService ?? throw new ArgumentNullException(nameof(quizResultService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        #endregion

        /// <summary>
        /// Get all quiz results
        /// </summary>
        [HttpGet]
        //[PermissionAuthorize("ADMIN", "CUSTOMER")]
        public async Task<IActionResult> GetQuizResultsAsync()
        {
            try
            {
                var results = await _quizResultService.GetQuizResultsSimplyAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving quiz results.");
                return StatusCode(500, new { message = "Error retrieving quiz results." });
            }
        }

        /// <summary>
        /// Get a quiz result by ID
        /// </summary>
        [HttpGet("{id:long}")]
        //[PermissionAuthorize("ADMIN", "CUSTOMER")]
        public async Task<IActionResult> GetQuizResultAsync(long id)
        {
            try
            {
                var result = await _quizResultService.GetQuizResultSimplyAsync(id);
                if (result == null)
                {
                    return NotFound(new { message = "Quiz result not found." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving quiz result with ID {id}.");
                return StatusCode(500, new { message = "Error retrieving quiz result." });
            }
        }

        /// <summary>
        /// Delete a quiz result by ID
        /// </summary>
        [HttpDelete("{id:long}")]
        //[PermissionAuthorize("ADMIN", "CUSTOMER")]
        public async Task<IActionResult> DeleteQuizResultAsync(long id)
        {
            try
            {
                await _quizResultService.DeleteQuizResultSimplyAsync(id);
                return Ok(new { message = "Quiz result deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting quiz result with ID {id}.");
                return StatusCode(500, new { message = "Error deleting quiz result." });
            }
        }

        /// <summary>
        /// Create new quiz result - Dummy data not standard data
        /// </summary>
        [HttpPost]
        //[PermissionAuthorize("ADMIN", "CUSTOMER")]
        public async Task<IActionResult> CreateQuizResultAsync([FromBody] QuizResult request)
        {
            try
            {
                await _quizResultService.CreateQuizResultSimplyAsync(request);
                return Ok(new { message = "Quiz result created successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating quiz result." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuizResultAsync([FromBody] QuizResult request)
        {
            try
            {
                await _quizResultService.UpdateQuizResultSimplyAsync(request);
                return Ok(new { message = "Quiz result updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating quiz result." });
            }
        }

        [HttpGet("userlistselectbox")]
        public async Task<IActionResult> GetUserListSimplyAsync()
        {
            try
            {
                var results = await _userService.GetAllAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving user list." });
            }
        }
    }
}
