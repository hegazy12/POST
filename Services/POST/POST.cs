
using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using Mashrok.Infrastructure.UnitOfWork;
using ProjectEweis.ModelView.POSTVM;

namespace ProjectEweis.Services.POST
{
    public class POST : IPOST
    {
        maper maper = new maper();
        private readonly IUnitOfWork _unitOfWork;
        public POST(IUnitOfWork unitOfWork)
        {
          
            _unitOfWork = unitOfWork;
            
        }

        public PostReturnVM AddCommercialPost(CommercialVM commercialVM)
        {
            PostReturnVM returnvM = new PostReturnVM();

            try
            {
                var commercial = maper.MapCommercial(commercialVM);
                commercial.Owner = _unitOfWork.UsersRepo.First(u => u.Id == commercialVM.UserId);
                _unitOfWork.commercialRepo.Insert(commercial);
                _unitOfWork.CommitChanges();

                var POSTI = _unitOfWork.commercialRepo.
                    Fitler(m=> m.Owner.Id == commercialVM.UserId).
                    OrderBy(m=> m.DateCreated).LastOrDefault();
                

                returnvM.IDPost = POSTI.ID.ToString();
                returnvM.Stutes = "save ok";
                return returnvM;
            }
            catch (Exception ex)
            {
                returnvM.IDPost = "-1";
                returnvM.Stutes = ex.InnerException.Message; 

                return returnvM;
            }
        }

        public PostReturnVM Addreal_estate_yes(real_estate_yes_VM VM)
        {
            PostReturnVM returnvM = new PostReturnVM();

            try
            {
                var real_estate_yes = maper.Mapreal_estate_yes(VM);
                real_estate_yes.Owner = _unitOfWork.UsersRepo.First(u => u.Id == VM.UserID);
                _unitOfWork.real_estate_yesRepo.Insert(real_estate_yes);
                _unitOfWork.CommitChanges();

                var POSTI = _unitOfWork.
                            real_estate_yesRepo.
                            Fitler(m => m.Owner.Id == VM.UserID).
                            OrderBy(m => m.DateCreated).
                            LastOrDefault();


                returnvM.IDPost = POSTI.ID.ToString();
                returnvM.Stutes = "save ok";
                return returnvM;

                
            }
            catch (Exception ex)
            {
                
                returnvM.IDPost = "-1";
                returnvM.Stutes = ex.InnerException.Message;
                return returnvM;
            }

        }
        public PostReturnVM Addreal_estate_no(real_estate_no_VM VM)
        {
            PostReturnVM returnvM = new PostReturnVM();
            try
            {
                var real_estate_no = maper.Mapreal_estate_no(VM);
                real_estate_no.Owner= _unitOfWork.UsersRepo.First(u => u.Id == VM.UserID);
                _unitOfWork.real_estate_noRepo.Insert(real_estate_no);
                _unitOfWork.CommitChanges();
                
                var POSTI = _unitOfWork.
                            real_estate_noRepo.
                            Fitler(m => m.Owner.Id == VM.UserID).
                            OrderBy(m => m.DateCreated).
                            LastOrDefault();

                returnvM.IDPost = POSTI.ID.ToString();
                returnvM.Stutes = "save ok";
                return returnvM;
                
            }
            catch (Exception ex)
            {
                returnvM.IDPost = "-1";
                returnvM.Stutes = ex.InnerException.Message;
                return returnvM;
            }
        }

        public AllPosts GetAllPosts()
        {
            return new AllPosts()
            {
            
                commercials     = _unitOfWork.commercialRepo.Fitler(m=> m.Deleted == 0, "Owner").ToList(),
                real_Estate_No  = _unitOfWork.real_estate_noRepo.Fitler(m => m.Deleted == 0, "Owner").ToList(),
                real_Estate_Yes = _unitOfWork.real_estate_yesRepo.Fitler(m => m.Deleted == 0, "Owner").ToList(),
             };
        }

        public AllPosts GetmyPosts(string Iduser)
        {
            return new AllPosts()
            {
                commercials = _unitOfWork.commercialRepo.Fitler(m => m.Deleted == 0 & m.Owner.Id==Iduser, "Owner").ToList(),
                real_Estate_No = _unitOfWork.real_estate_noRepo.Fitler(m => m.Deleted == 0 & m.Owner.Id == Iduser, "Owner").ToList(),
                real_Estate_Yes = _unitOfWork.real_estate_yesRepo.Fitler(m => m.Deleted == 0 & m.Owner.Id == Iduser, "Owner").ToList(),
            };
        }
    }
}