using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulatedResultController : ControllerBase
    {
        private readonly ISimulatedResultRepository _simulatedResultRepository;

        public SimulatedResultController(ISimulatedResultRepository simulatedResultRepository)
        {
            _simulatedResultRepository = simulatedResultRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimulatedResultDTO>>> GetAll()
        {
            var simulatedResults = await _simulatedResultRepository.GetAll();

            var simulatedResultsDTO = simulatedResults
                .Select(s => new SimulatedResultDTO
                {
                    Id = s.Id,
                    SimulatedExamId = s.SimulatedExamId,
                    Pontuacao = s.Pontuacao,
                    SimulatedExamTitle = s.SimulatedExam.Nome
                });

            return Ok(simulatedResultsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SimulatedResultDTO>> GetById(int id)
        {
            var simulatedResult = await _simulatedResultRepository.GetById(id);

            var simulatedResultDTO = new SimulatedResultDTO
            {
                Id = simulatedResult.Id,
                SimulatedExamId = simulatedResult.SimulatedExamId,
                Pontuacao = simulatedResult.Pontuacao,
                SimulatedExamTitle = simulatedResult.SimulatedExam.Nome
            };

            return Ok(simulatedResultDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SimulatedResultDTO simulatedResultDTO)
        {
            var simulatedResult = new SimulatedResult
            {
                Id = simulatedResultDTO.Id,
                SimulatedExamId = simulatedResultDTO.SimulatedExamId,
                Pontuacao = simulatedResultDTO.Pontuacao,
            };

            await _simulatedResultRepository.Add(simulatedResult);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SimulatedResultDTO simulatedResultDTO)
        {
            var simulatedResult = new SimulatedResult
            {
                Id = simulatedResultDTO.Id,
                SimulatedExamId = simulatedResultDTO.SimulatedExamId,
                Pontuacao = simulatedResultDTO.Pontuacao
            };

            await _simulatedResultRepository.Update(simulatedResult);

            return Ok(simulatedResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _simulatedResultRepository.Delete(id);

            return Ok();
        }
    }
}
