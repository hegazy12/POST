using Mashrok.Application.Interfaces;
using Mashrok.Application.IUnitOfWork;
using Mashrok.Domain;
using Mashrok.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext _db)
        {
            db = _db;
            commercialRepo = new GenericRepository<commercial>(db);
            lOVE_ON_PostRepo = new GenericRepository<LOVE_ON_Post>(db);
            MessageRepo = new GenericRepository<Message>(db);
            partnership_proposalRepo = new GenericRepository<Partnership_proposal>(db);
            real_estate_noRepo = new GenericRepository<real_estate_no>(db);
            real_estate_yesRepo = new GenericRepository<real_estate_yes>(db);
            UserRequestRepo = new GenericRepository<UserRequest>(db);
            UsersRepo = new GenericRepository<ApplicationUser>(db);

            NotifacationRepo = new GenericRepository<Notifacation>(db);

        }
        public IGenericRepository<commercial> commercialRepo { get; private set; }
        public IGenericRepository<LOVE_ON_Post> lOVE_ON_PostRepo { get; private set; }
        public IGenericRepository<Message> MessageRepo { get; private set; }
        public IGenericRepository<Partnership_proposal> partnership_proposalRepo { get; private set; }
        public IGenericRepository<real_estate_no> real_estate_noRepo { get; private set; }
        public IGenericRepository<real_estate_yes> real_estate_yesRepo { get; private set; }
        public IGenericRepository<UserRequest> UserRequestRepo { get; private set; }
        public IGenericRepository<ApplicationUser> UsersRepo { get; private set; }

        public IGenericRepository<Notifacation> NotifacationRepo { get; private set; }

        public int CommitChanges()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
