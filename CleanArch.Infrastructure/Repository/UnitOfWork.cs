using CleanArch.Application.Interfaces;

namespace CleanArch.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IContactRepository contactRepository,IFreshLeadsRepository freshLeadsRepository)
        {
            Contacts = contactRepository;
            Leads = freshLeadsRepository;
        }

        public IContactRepository Contacts { get; set; }
        public IFreshLeadsRepository Leads { get; set; }
    }
}
