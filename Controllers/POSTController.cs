
using Mashrok.Application.IUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEweis.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class POSTController : ControllerBase
    {
       // private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public POSTController(/*ApplicationDbContext db*/ IUnitOfWork unitOfWork)
        {
            //_db = db;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetPOST(string IDPOST)
        {

            var _commercial = _unitOfWork.commercialRepo.First(m => m.ID.ToString() == IDPOST);
            var _yes = _unitOfWork.real_estate_yesRepo.First(m => m.ID.ToString() == IDPOST);
            var _no = _unitOfWork.real_estate_noRepo.First(m => m.ID.ToString() == IDPOST);

            if (_yes != null)
                return Ok(_yes);
            else if (_no != null)
                return Ok(_no);
            else if (_commercial != null)
                return Ok(_commercial);
            else return BadRequest("Your id is not exiext in postes  (_no  OR  _yes  Or _no)");

        }
    }
}
