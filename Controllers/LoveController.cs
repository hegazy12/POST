using DAL.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectEweis.Models;
using ProjectEweis.ModelView.LOVEVM;
using ProjectEweis.Services.Love;
using TestApiJWT.Models;

namespace ProjectEweis.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoveController : ControllerBase
    {
        private readonly ILove _love;
        public LoveController(ILove love)
        {
            _love = love;
        }

        [HttpPost]
        public string AddLove(LOVEVM lOVEVM)
        {
            return _love.ADDlove(lOVEVM);
        }

        [HttpGet]
        public List<LOVE_ON_Post> GetmyListLove(string IdUser)
        {
            return _love.GetmyListLove(IdUser);
        }

        [HttpPost]
        public string RemoveFromloveList(string IdUser , string IdPOST)
        {
            return _love.RemoveFromloveList(IdUser,IdPOST);
        }
    }
}
