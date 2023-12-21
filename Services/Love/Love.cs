using DAL.DBContext;
using ProjectEweis.Models;
using ProjectEweis.ModelView.LOVEVM;
using System.Numerics;

namespace ProjectEweis.Services.Love
{
    public class Love : ILove
    {
        private readonly ApplicationDbContext _db;
        public Love(ApplicationDbContext db)
        {
            _db = db;
        }
        public string ADDlove(LOVEVM VM)
        {
           

            var x = _db.LOVE_ON_Post.Where(m => m.Reactor.Id == VM.Reactor && m.commercialID == VM.commercial &&  m.real_estate_noID == VM.real_estate_no &&  m.real_estate_yesID == VM.real_estate_yes)
                                                              .ToList();

            if (x.Count >= 1)
            {
                return "you add this love in list love befor";
            }
            else
            {
                var Reactor = _db.Users.FirstOrDefault(m => m.Id == VM.Reactor);
                var commercial = _db.commercials.FirstOrDefault(m => m.ID.ToString() == VM.commercial);
                var real_estate_no = _db.real_estate_nos.FirstOrDefault(m => m.ID.ToString() == VM.real_estate_no);
                var real_estate_yes = _db.real_estate_yess.FirstOrDefault(m => m.ID.ToString() == VM.real_estate_yes);

                if (Reactor != null && (commercial != null || real_estate_no != null || real_estate_yes != null) )
                {
                   
                    var lOVE_ON_Post = new LOVE_ON_Post()
                    {
                        Reactor = Reactor,
                        commercialID = VM.commercial ,
                        real_estate_noID = VM.real_estate_no,
                        real_estate_yesID = VM.real_estate_yes,
                    };

                    _db.LOVE_ON_Post.Add(lOVE_ON_Post);
                    _db.SaveChanges();
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
            return _db.LOVE_ON_Post.Where(m => m.Reactor.Id == UserID).ToList();
        }
    }
}
