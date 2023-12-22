
using Mashrok.Application.IUnitOfWork;
using Mashrok.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEweis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
       //   private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public ChatController(/*ApplicationDbContext db,*/IUnitOfWork unitOfWork)
        {
         //   _db = db;
           _unitOfWork=unitOfWork;
        }
        [HttpGet("GetMesssages/{requestId}")]
        public IActionResult GetMesssages(string requestId)
        {
            if (requestId != null)
            {
                var messages=_unitOfWork.MessageRepo.Fitler(a => a.RequestId == requestId).ToList();
               // var messages = _db.Messages.Where(a => a.ReceiverId == requestId).ToList();
                return Ok(messages);
            }

            return NotFound();
        }
    }
}
