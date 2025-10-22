using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswerController : ControllerBase
    {
        private readonly IUserAnswerRepository _userAnswerRepository;
        public UserAnswerController(IUserAnswerRepository userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userAnswer = await _userAnswerRepository.GetAll();

            var userAnswerDTO = userAnswer.
                Select(u => new UserAnswerDTO
                {
                    IsCorrect = u.IsCorrect,
                    QuestionId = u.QuestionId,
                });

            return Ok(userAnswerDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userAnswer = await _userAnswerRepository.GetById(id);

            var userAnswerDTO = new UserAnswerDTO
            {
                IsCorrect = userAnswer.IsCorrect,
                QuestionId = userAnswer.QuestionId,
            };

            return Ok(userAnswerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAnswerDTO userAnswerDTO)
        {
            var userAnswer = new UserAnswer
            {
                IsCorrect = userAnswerDTO.IsCorrect,
                QuestionId = userAnswerDTO.QuestionId,
            };

            await _userAnswerRepository.Add(userAnswer);
            return Ok(userAnswerDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserAnswerDTO userAnswerDTO)
        {
            var userAnswer = new UserAnswer
            {
                IsCorrect = userAnswerDTO.IsCorrect,
                QuestionId = userAnswerDTO.QuestionId,
            };

            await _userAnswerRepository.Update(userAnswer);
            return Ok(userAnswerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userAnswerRepository.Delete(id);
            return Ok();
        }
    }
}
