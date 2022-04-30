using API.Errors;
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