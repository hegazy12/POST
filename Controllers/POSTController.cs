using DAL.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEweis.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class POSTController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public POSTController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetPOST(string IDPOST)
        {

            var _commercial = _db.commercials.FirstOrDefault(m => m.ID.ToString() == IDPOST);
            var _yes = _db.real_estate_yess.FirstOrDefault(m => m.ID.ToString() == IDPOST);
            var _no = _db.real_estate_nos.FirstOrDefault(m => m.ID.ToString() == IDPOST);

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
