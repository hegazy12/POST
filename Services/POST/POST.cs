
using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjectEweis.Hubs;
using ProjectEweis.ModelView.POSTVM;

namespace ProjectEweis.Services.POST
{
    public class POST : IPOST
    {
        maper maper = new maper();
        //private IHubContext<NotifyHub> hubContext;
      //  private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
       
        public POST(/*ApplicationDbContext db,*/ IUnitOfWork unitOfWork, IHubContext<NotifyHub> _hubContext)
        {
           // _db = db;
            _unitOfWork = unitOfWork;

        }

        public string AddCommercialPost(CommercialVM commercialVM)
        {
            try
            {
                var commercial = maper.MapCommercial(commercialVM);
                commercial.Owner = _unitOfWork.UsersRepo.First(u => u.Id == commercialVM.UserId);
                _unitOfWork.commercialRepo.Insert(commercial);
                _unitOfWork.CommitChanges();

                var not = new Notifacation()
                {
                    NotifyType = "1",
                    NotifyText = "new post in commercial type",
                return "save ok";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

        public string Addreal_estate_yes(real_estate_yes_VM VM)
        {
            try
            {
                var real_estate_yes = maper.Mapreal_estate_yes(VM);
                real_estate_yes.Owner = _unitOfWork.UsersRepo.First(u => u.Id == VM.UserID);
              _unitOfWork.real_estate_yesRepo.Insert(real_estate_yes);
                _unitOfWork.CommitChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

        }
        public string Addreal_estate_no(real_estate_no_VM VM)
        {
            try
            {
                var real_estate_no = maper.Mapreal_estate_no(VM);
                real_estate_no.Owner= _unitOfWork.UsersRepo.First(u => u.Id == VM.UserID);
                _unitOfWork.real_estate_noRepo.Insert(real_estate_no);
                _unitOfWork.CommitChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

        public AllPosts GetAllPosts()
        {
            return new AllPosts()
            {
             // commercials     = _db.commercials.Include(m => m.Owner).Where(m=> m.Deleted == 0).ToList(),
              commercials     = _unitOfWork.commercialRepo.Fitler(m=> m.Deleted == 0, "Owner").ToList(),
                real_Estate_No  = _unitOfWork.real_estate_noRepo.Fitler(m => m.Deleted == 0, "Owner").ToList(),
              real_Estate_Yes = _unitOfWork.real_estate_yesRepo.Fitler(m => m.Deleted == 0, "Owner").ToList(),
             };
        }

        public AllPosts GetmyPosts(string Iduser)
        {
            return new AllPosts()
            {
                commercials = _unitOfWork.commercialRepo.Fitler(m => m.Deleted == 0&m.Owner.Id==Iduser, "Owner").ToList(),
                real_Estate_No = _unitOfWork.real_estate_noRepo.Fitler(m => m.Deleted == 0 & m.Owner.Id == Iduser, "Owner").ToList(),
                real_Estate_Yes = _unitOfWork.real_estate_yesRepo.Fitler(m => m.Deleted == 0 & m.Owner.Id == Iduser, "Owner").ToList(),
            };
        }
    }
}