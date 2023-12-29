
using Mashrok.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ProjectEweis.Healper;
using ProjectEweis.Hubs;
using ProjectEweis.ModelView.POSTVM;
using ProjectEweis.ModelView.RequestVM;
using ProjectEweis.Services.Notification;
using ProjectEweis.Services.POST;
using ProjectEweis.Services.Request;


namespace ProjectEweis.Controllers
{
  //[Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IPOST _POST;
        private readonly IRequest _Request;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly INotification _Notification;

        public HomeController(IPOST POST ,IRequest Request ,UserManager<ApplicationUser> userManager ,  IHubContext<ChatHub> hubContext , INotification Notification )
        {
            _POST = POST;
            _Request = Request;
            _userManager = userManager;
            _hubContext = hubContext;
            _Notification = Notification;
        }

        [HttpPost]
        public string AddCommercialPost([FromBody] CommercialVM commercialVM)
        {
                var x = _POST.AddCommercialPost(commercialVM);
                
                if (x.Stutes == "save ok")
                {
                var xx = _Notification.NtfyAddCommercial(x.IDPost); 
                _hubContext.Clients.All.SendAsync("Notify", xx);
                }

                return x.Stutes;
        }


        [HttpPost]
        public string Addreal_estate_yesPost([FromForm] real_estate_yes_VM VM )
        {
            return _POST.Addreal_estate_yes(VM).Stutes;
        }
        

        [HttpPost]
        public string Addreal_estate_noPost([FromBody] real_estate_no_VM VM)
        {
            return _POST.Addreal_estate_no(VM).Stutes;
        }

        [HttpGet]
        public AllPosts GetAllPost()
        {
            return _POST.GetAllPosts();
        }


        [HttpGet]
        public AllPosts GetmyPosts(string Iduser)
        {
            return _POST.GetmyPosts(Iduser); 
        }

        [HttpPost]
        public string AddRequest_Commercial(UserRequesVM Reques)
        {
            return _Request.AddrequestForCommercial(Reques);
        }


        [HttpPost]
        public string AddRequest_Real_Estate_Yes(UserRequesVM Reques)
        {
            return _Request.AddrequestForRealEstateYes(Reques);
        }


        [HttpPost]
        public string AddRequest_Real_Estate_No(UserRequesVM Reques)
        {
            return _Request.AddrequestForRealEstateNo(Reques);
        }


        [HttpGet]
        public List<UserRequest> GetMyRequest(string IDrquest)
        {
            return _Request.GetMyRequests(IDrquest);
        }


        [HttpGet]
        public List<UserRequest> GetRequestsOnPost(string IDrquest)
        {
            return _Request.GetRequestsOnPost(IDrquest);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCities()
        {
            List<cities> cities = new List<cities>();
            var filePath = Directory.GetCurrentDirectory() + @"\cities.json";
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                cities=JsonConvert.DeserializeObject<List<cities>>(json);
            }
            return Ok(cities);
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult GetRegions()
        {
            List<regions> regions = new List<regions>();
            var filePath = Directory.GetCurrentDirectory() + @"\regions.json";
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                regions = JsonConvert.DeserializeObject<List<regions>>(json);
            }
            return Ok(regions);
        }

        [HttpPost]
        public async Task<string> AddApprovalRequest(ApproveModel model)
        {
            return _Request.AddApprovalRequest(model.IdownerofPost,model.IdRequest,model.status);
        }
    }
}
