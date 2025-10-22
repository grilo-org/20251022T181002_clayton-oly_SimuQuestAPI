using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;


namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedOptionController : ControllerBase
    {
        private readonly ISelectedOptionRepository _selectedOptionRepository;

        public SelectedOptionController(ISelectedOptionRepository selectedOptionRepository)
        {
            _selectedOptionRepository = selectedOptionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var selectedOptions = await _selectedOptionRepository.GetAll();
            return Ok(selectedOptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var selectedOption = await _selectedOptionRepository.GetById(id);
            return Ok(selectedOption);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SelectedOptionDTO selectedOptionDTO)
        {
            var selectedOption = new SelectedOption
            {
                Id = selectedOptionDTO.OptionId,
                OptionId = selectedOptionDTO.OptionId,
            };

            await _selectedOptionRepository.Add(selectedOption);

            return Ok(selectedOption);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SelectedOptionDTO selectedOptionDTO)
        {
            var selectedOption = new SelectedOption
            {
                Id = selectedOptionDTO.OptionId,
                OptionId = selectedOptionDTO.OptionId,
            };

            await _selectedOptionRepository.Update(selectedOption);
            return Ok(selectedOption);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _selectedOptionRepository.Delete(id);
            return Ok();
        }
    }
}
