
using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
//using ProjectEweis.Migrations;

using ProjectEweis.ModelView.LOVEVM;
using System.Numerics;

namespace ProjectEweis.Services.Love
{
    public class Love : ILove
    {
          
        private readonly IUnitOfWork _unitOfWork;
        public Love(IUnitOfWork unitOfWork)
        {
         
           _unitOfWork=unitOfWork;

        }
        public string ADDlove(LOVEVM VM)
        {


            var x = _unitOfWork.lOVE_ON_PostRepo.Fitler(m => m.Reactor.Id == VM.Reactor && m.commercialID == VM.commercial && m.real_estate_noID == VM.real_estate_no && m.real_estate_yesID == VM.real_estate_yes);
                                                              

            if (x.Count >= 1)
            {
                return "you add this love in list love befor";
            }
            else
            {
                var Reactor = _unitOfWork.UsersRepo.First(m => m.Id == VM.Reactor);
                var commercial = _unitOfWork.commercialRepo.First(m => m.ID.ToString() == VM.commercial);
                var real_estate_no = _unitOfWork.real_estate_noRepo.First(m => m.ID.ToString() == VM.real_estate_no);
                var real_estate_yes = _unitOfWork.real_estate_yesRepo.First(m => m.ID.ToString() == VM.real_estate_yes);

                if (Reactor != null && (commercial != null || real_estate_no != null || real_estate_yes != null) )
                {
                   
                    var lOVE_ON_Post = new LOVE_ON_Post()
                    {
                        Reactor = Reactor,
                        commercialID = VM.commercial ,
                        real_estate_noID = VM.real_estate_no,
                        real_estate_yesID = VM.real_estate_yes,
                    };

                    _unitOfWork.lOVE_ON_PostRepo.Insert(lOVE_ON_Post);
                    _unitOfWork.CommitChanges();
                    return "you add the offer in love list Successfully";
                }
                else
                {
                    return "you invaled IDs";
                }
            }
        }


        public List<LOVE_ON_Post> GetmyListLove(string UserID)
        {
            return _unitOfWork.lOVE_ON_PostRepo.Fitler(m => m.Reactor.Id == UserID && m.Deleted == 0).ToList();
        }

        public string RemoveFromloveList(string UserID , string IDPOST)
        {
            var love_On_POST = _unitOfWork.lOVE_ON_PostRepo.Fitler(m=> m.Reactor.Id == UserID  && (m.commercialID ==IDPOST || m.real_estate_noID == IDPOST || m.real_estate_yesID == IDPOST)).First();
            if(love_On_POST == null)
            {
                return "you invaled IDs";
            }
            else
            {
                love_On_POST.Deleted = 1;
                _unitOfWork.CommitChanges();
                return "you removed from lost love";
            }
        } 
    }
}
