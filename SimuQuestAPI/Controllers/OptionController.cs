using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;


namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionRepository _optionRepository;

        public OptionController(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionDTO>>> GetAll()
        {

            var options = await _optionRepository.GetAll();

            var optionsDTO = options
                .Select(o => new OptionDTO
                {
                    Id = o.Id,
                    Texto = o.Texto,
                    Correta = o.IsCorrect,
                    Ordem = o.Ordem,
                    QuestionId = o.QuestionId,
                    Questao = o.Question.Statement
                });

            return Ok(optionsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OptionDTO>> GetById(int id)
        {
            var option = await _optionRepository.GetById(id);

            var optionDTO = new OptionDTO
            {
                Id = option.Id,
                Texto = option.Texto,
                Correta = option.IsCorrect,
                Ordem = option.Ordem,
                QuestionId = option.QuestionId
            };

            return Ok(optionDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OptionDTO optionDTO)
        {
            var option = new Option
            {
                Id = optionDTO.Id,
                Texto = optionDTO.Texto,
                IsCorrect = optionDTO.Correta,
                //Ordem = optionDTO.Ordem,
                QuestionId = optionDTO.QuestionId
            };

            await _optionRepository.Add(option);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OptionDTO optionDTO)
        {
            var option = new Option
            {
                Id = optionDTO.Id,
                Texto = optionDTO.Texto,
                IsCorrect = optionDTO.Correta,
                //Ordem = optionDTO.Ordem,
                QuestionId = optionDTO.QuestionId
            };

            await _optionRepository.Update(option);

            return Ok(option);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _optionRepository.Delete(id);

            return Ok();
        }
    }
}
