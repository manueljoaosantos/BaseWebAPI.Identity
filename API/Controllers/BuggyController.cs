using API.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        public BuggyController()
        {}

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {


            return Ok();
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            //Bearer Colocar o token obtido do login tipo
            //Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hbnVlbEB0ZXN0LmNvbSIsImdpdmVuX25hbWUiOiJNYW51ZWwiLCJuYmYiOjE2NTE0MTgwNDgsImV4cCI6MTY1MjAyMjg0OCwiaWF0IjoxNjUxNDE4MDQ4LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.m7PP7A8Kev5ySr7eO3GBoKJIHhebYORZjTdNsDmF5FEXhzuJpF_sz0EeLhOEupHFe-ped9zC3oM4kNczLYtlIQ 
            return "secret stuff";
        }
        
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}