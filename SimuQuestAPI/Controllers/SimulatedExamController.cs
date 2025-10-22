using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulatedExamController : ControllerBase
    {
        private readonly ISimulatedExamRepository _examRepository;

        public SimulatedExamController(ISimulatedExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimulatedExamDTO>>> GetAll()
        {
            var exams = await _examRepository.GetAll();

            var examDTOs = exams
              .Select(s => new SimulatedExamDTO
              {
                  Descricao = s.Descricao,
                  Nome = s.Nome,
                  Imagem = s.Imagem,
                  Id = s.Id,

                  Questions = s.Questions.Select(q => new QuestionDTO
                  {
                      Id = q.Id,
                      Texto = q.Statement,
                  }).ToList()
              }).ToList();

            return Ok(examDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SimulatedExamDTO>> GetById(int id)
        {
            var exam = await _examRepository.GetById(id);

            var examDTO = new SimulatedExamDTO
            {
                Id = exam.Id,
                Nome = exam.Nome,
                Descricao = exam.Descricao,
                DataCriacao = exam.DataCriacao,
                Questions = exam.Questions.Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Ordem = q.Ordem,
                    Texto = q.Statement,

                    Options = q.Options.Select(o => new OptionDTO
                    {
                        Id = o.Id,
                        Texto = o.Texto,
                        Correta = o.IsCorrect,
                        Ordem = o.Ordem,
                    }).ToList(),
                }).ToList(),

            };

            return Ok(examDTO);
        }

        [HttpGet("{examId}/questoes-aleatorias")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestoesAleatorias(int examId, int quantidade)
        {
            var questions = await _examRepository.GetQuestoesAleatorias(examId, quantidade);

            var questionsDTO = questions
                .Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Texto = q.Statement,
                    Explicacao = q.Explicacao,
                    Ordem = q.Ordem,
                    ExamId = q.SimulatedExamId,
                    Options = q.Options.Select(o => new OptionDTO
                    {
                        Correta = o.IsCorrect,
                        Id = o.Id,
                        Ordem = o.Ordem,
                        Questao = o.Question.ToString(),
                        QuestionId = o.QuestionId,
                        Texto = o.Texto
                    }).ToList()
                }).ToList();

            return Ok(questionsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SimulatedExamDTO examDTO)
        {
            var exam = new Models.SimulatedExam
            {
                Id = examDTO.Id,
                Nome = examDTO.Nome,
                Descricao = examDTO.Descricao,
                Imagem = examDTO.Imagem,
            };

            await _examRepository.Add(exam);
            return Ok(examDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SimulatedExamDTO examDTO)
        {
            var exam = new Models.SimulatedExam
            {
                Id = examDTO.Id,
                Nome = examDTO.Nome,
                Descricao = examDTO.Descricao,
                Imagem = examDTO.Imagem,
            };

            await _examRepository.Update(exam);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _examRepository.Delete(id);
            return Ok();
        }
    }
}
