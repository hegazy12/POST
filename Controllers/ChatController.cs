using DAL.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEweis.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ChatController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetMesssages/{requestId}")]
        public IActionResult GetMesssages(string requestId)
        {
            if (requestId != null)
            {
                var messages=_db.Messages.Where(a => a.RequestId == requestId).ToList();
                return Ok(messages);
            }
            return NotFound();
        }


    }
}
