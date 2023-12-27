using Mashrok.Application.Interfaces;
using Mashrok.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mashrok.Application.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<commercial> commercialRepo { get; }
        public IGenericRepository<LOVE_ON_Post> lOVE_ON_PostRepo { get; }
        public IGenericRepository<Message> MessageRepo { get; }
        public IGenericRepository<Partnership_proposal> partnership_proposalRepo { get; }
        public IGenericRepository<real_estate_no> real_estate_noRepo { get; }
        public IGenericRepository<real_estate_yes> real_estate_yesRepo { get; }
        public IGenericRepository<UserRequest> UserRequestRepo { get; }
        public IGenericRepository<ApplicationUser> UsersRepo { get; }

        public IGenericRepository<Notifacation> NotifacationRepo { get; }
        public int CommitChanges();
    }
}
