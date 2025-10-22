using Microsoft.AspNetCore.Mvc;
using SimuQuestAPI.DTOs;
using SimuQuestAPI.Interfaces;
using SimuQuestAPI.Models;

namespace SimuQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetAll()
        {

            var questions = await _questionRepository.GetAll();

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

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDTO>> GetById(int id)
        {
            var question = await _questionRepository.GetById(id);

            var questionDTO = new QuestionDTO
            {

                Id = question.Id,
                Texto = question.Statement,
                Explicacao = question.Explicacao,
                Ordem = question.Ordem,
                ExamId = question.SimulatedExamId,
                //NomeExame = question.SimulatedExam.Nome,
                Options = question.Options.Select(o => new OptionDTO
                {
                    Correta = o.IsCorrect,
                    Id = o.Id,
                    Ordem = o.Ordem,
                    Questao = o.Question.ToString(),
                    QuestionId = o.QuestionId,
                    Texto = o.Texto
                }).ToList()
            };

            return Ok(questionDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] QuestionDTO questionDTO)
        {
            var question = new Question
            {
                Id = questionDTO.Id,
                Statement = questionDTO.Texto,
                Explicacao = questionDTO.Explicacao,
                Ordem = questionDTO.Ordem,
                SimulatedExamId = questionDTO.ExamId
            };

            await _questionRepository.Add(question);

            return Ok();
        }

        [HttpPost("{examId}/add-questions")]
        public async Task<ActionResult> CreateQuestionsBatch(int examId, [FromBody] List<QuestionDTO> questionDTOs)
        {
            var questions = new List<Question>();
            foreach (var qDto in questionDTOs)
            {
                var question = new Question
                {
                    Statement = qDto.Texto,
                    Explicacao = qDto.Explicacao,
                    SimulatedExamId = examId,
                    Options = qDto.Options.Select(oDto => new Option
                    {
                        Texto = oDto.Texto,
                        IsCorrect = oDto.Correta,
                        QuestionId = qDto.Id
                        //Ordem = oDto.Ordem
                    }).ToList()
                };

                questions.Add(question);
            }

            await _questionRepository.CreateQuestionsBatch(examId, questions);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, QuestionDTO questionDTO)
        {
            var question = new Question
            {
                Id = questionDTO.Id,
                Statement = questionDTO.Texto,
                Explicacao = questionDTO.Explicacao,
                Ordem = questionDTO.Ordem,
                SimulatedExamId = questionDTO.ExamId
            };

            await _questionRepository.Update(question);

            return Ok(question);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionRepository.Delete(id);

            return Ok();
        }
    }
}
