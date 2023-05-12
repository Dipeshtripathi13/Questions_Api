// the controller defines an Asp.net controller class named QuestionController is responsible for handling incoming HTTP request 
//and retrun HTTP responses to client

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questions_Api.Data;
using Questions_Api.Models;

namespace Questions_Api.Controllers
{
    [ApiController] //this attribute is used to indicate that the controller will handle Http requests
    [Route("[controller]")]// specifies the base URL path for the controller
    public class QuestionController : Controller
    {
        // the controller has a constructro that takes an arguent of type DataContext. this is dependency injection pattern where the Datacontext
        // is injected into the controller via the constructor
        //in the constructor the injected DataContext object is assigned to a private field 
        private readonly DataContext _dbContext;

        public QuestionController(DataContext dbContext)
        {
           
            _dbContext = dbContext;
        }
        //end point to give all the list of the questiobn
        [HttpGet]
        public ActionResult<IEnumerable<Question_Entity>> GetQuestions()
        {
            return _dbContext.Questions.ToList();
        }
        //end point to give only the random num number of questions entity
        [HttpGet("{num}")]
        public ActionResult<IEnumerable<Question_Entity>> GetNumQuestions(int num)
        {
            var all_questions = _dbContext.Questions.ToList();//return all the question entity to all_questions
            var randomQuestion = all_questions.OrderBy(x => Guid.NewGuid()).Take(num);//return only the random num question_entity from all_questions
            return Ok(randomQuestion);
        }
        [HttpPost("addquestion")]
        public async Task<ActionResult<string>> AddQuestion(Question_Entity registeredObject)
        {
            //Method takes a single parameter of type Question_Entity of name registeredObject, The parameter contain the data for new question_entity object to be added to the database
            //a new instance of the question_entity class is createdand its properties are set based on the valeus in the registeredobject parameter
            //Question_Entity object is added to the dbContext.Questions DbSet using Add method
            //finally the change are saved to the database using the _db.context.savechangeAsync() method which return a task that is awaited to ensure that the 
            //change are fullycommitted to the database before method returns
            var question = new Question_Entity
            {
                Question = registeredObject.Question,
                Option1 = registeredObject.Option1,
                Option2 = registeredObject.Option2,
                Option3 = registeredObject.Option3,
                Option4 = registeredObject.Option4,
                Answer = registeredObject.Answer

            };
            if (registeredObject.Answer != null)
            {
                _dbContext.Questions.Add(question);
                await _dbContext.SaveChangesAsync();
                return "Question Added Sucessufully";

            }
            return "Added Failed";
            
        }
        [HttpPut("uptatequestion")]
        public async Task<ActionResult<string>> UpdateQuestion(Question_Entity updateObject)
        {
            var currentQuestion = _dbContext.Questions.Where(s => s.Id == updateObject.Id).FirstOrDefault();
            if (currentQuestion != null)
            {
                currentQuestion.Question = updateObject.Question;
                currentQuestion.Option1 = updateObject.Option1;
                currentQuestion.Option2 = updateObject.Option2;
                currentQuestion.Option3 = updateObject.Option3;
                currentQuestion.Option4 = updateObject.Option4;
                currentQuestion.Answer = updateObject.Answer;

                _dbContext.SaveChanges();
            }
            else
            {
                return "Question not found";
            };
            return "Question Updated successfully";
        }
        [HttpDelete("deletequestion")]
        public async Task<ActionResult<string>> DeleteQuestion(int Id)
        {
            if (Id < 1)
            {
                return BadRequest("Question not found");
            }
            var currentquestion = _dbContext.Questions.Where(s=> s.Id== Id).FirstOrDefault();
            if (currentquestion != null)
            {
                _dbContext.Entry(currentquestion).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            else
            {
                return "Qustion Not found";
            }
            return "Question Successfully Deleted";
        }
       
    }
}
