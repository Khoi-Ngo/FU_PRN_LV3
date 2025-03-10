using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pre_maritalCounSeling.BAL.ServiceQuiz;
using Pre_maritalCounSeling.DAL.Entities;

namespace Pre_maritalCounSeling.Blazor.API.Controllers
{
    [Route("api/v1/quizzes")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        #region Init
        private readonly ILogger<QuizzesController> _logger;
        private readonly IQuizService _quizService;

        public QuizzesController(ILogger<QuizzesController> logger, IQuizService quizService)
        {
            _logger = logger;
            _quizService = quizService;
        }
        #endregion

        // GET: api/v1/quizzes
        [HttpGet]
        public async Task<IActionResult> GetQuizzesAsync()
        {
            try
            {
                var quizzes = await _quizService.GetQuizzesAsync();
                return Ok(quizzes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving quizzes.");
            }
        }
    }
}
