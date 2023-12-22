
using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using ProjectEweis.Migrations;

using ProjectEweis.ModelView.POSTVM;
using ProjectEweis.ModelView.RequestVM;

namespace ProjectEweis.Services.Request
{
    public class Request : IRequest
    {

        private readonly ModelView.POSTVM.maper maper = new ModelView.POSTVM.maper();
     //   private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public Request(/*ApplicationDbContext db,*/ IUnitOfWork unitOfWork)
        {
           // _db = db;
            _unitOfWork = unitOfWork;

        }

        public string AddrequestForCommercial(UserRequesVM userReques)
        {
            try{
                UserRequest request = maper.MapUserReques(userReques);
                request.Requester = _unitOfWork.UsersRepo.First(u => u.Id == userReques.Requester);
                request.commercial = _unitOfWork.commercialRepo.First(u => u.ID.ToString() == userReques.commercial);
                _unitOfWork.UserRequestRepo.Insert(request);
                _unitOfWork.CommitChanges();
                return "it is ok";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

        public string AddrequestForRealEstateNo(UserRequesVM userReques)
        {
            try
            {
                UserRequest request = maper.MapUserReques(userReques);
                request.Requester = _unitOfWork.UsersRepo.First(u => u.Id == userReques.Requester);
                request.real_estate_no = _unitOfWork.real_estate_noRepo.First(u => u.ID.ToString() == userReques.commercial);
              _unitOfWork.UserRequestRepo.Insert(request);
                _unitOfWork.CommitChanges();
                return "it is ok";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

        public string AddrequestForRealEstateYes(UserRequesVM userReques)
        {
            try
            {
                UserRequest request = maper.MapUserReques(userReques);
                request.Requester = _unitOfWork.UsersRepo.First(u => u.Id == userReques.Requester);
                request.real_estate_yes = _unitOfWork.real_estate_yesRepo.First(u => u.ID.ToString() == userReques.commercial);
               _unitOfWork.UserRequestRepo.Insert(request);
                _unitOfWork.CommitChanges();
                return "it is ok";
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

        public List<UserRequest> GetMyRequests(string IDuser)
        {
            return _unitOfWork.UserRequestRepo.Fitler(m => m.Requester.Id == IDuser).ToList();
        }      

        public List<UserRequest> GetRequestsOnPost(string IDRequest)
        {
            return _unitOfWork.UserRequestRepo.Fitler(m => m.real_estate_no.ID.ToString() == IDRequest || m.real_estate_yes.ID.ToString() == IDRequest  || m.commercial.ID.ToString() == IDRequest).ToList();
        }
        public string AddApprovalRequest(string IdownerofPost, string IdRequest, string status)
        {
            var req = _unitOfWork.UserRequestRepo.Fitler(m => m.Id.ToString() == IdRequest).FirstOrDefault();
            if (req != null)
            {
                if (req.real_estate_no.Owner.Id == IdownerofPost ||
                   req.real_estate_yes.Owner.Id == IdownerofPost ||
                   req.commercial.Owner.Id == IdownerofPost)
                {
                    req.Approvalstate = status;
                    _unitOfWork.CommitChanges();
                    return "you update status effective";
                }
                return "you are not owner";
            }
            return "Id request isnot true";
        }
    }
}
