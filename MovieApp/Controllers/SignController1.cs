using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;

namespace MovieApp.Controllers
{


    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[Controller]")]
    public class SignController1 : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public SignController1(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

       
        [HttpPost, Route("~/api/SignIn")]
        public async Task<IActionResult> CreateSignin([FromHeader] string Signature, [FromBody] SignIn signs)
        {
            var resp = new CommonResponse();
            if (Signature != "hello12")
            {
                resp.StatusCode = 356;
                resp.Message = "Signature expired.";
                return Ok(resp);
            }

            if (signs.AuthCode != "hello12")
            {
                resp.StatusCode = 355;
                resp.Message = "Session expired.";
                return Ok(resp);
            }

            var data = await _unitOfWork.SignService.signin(signs);
            return Ok(data);
        }
    }
}
