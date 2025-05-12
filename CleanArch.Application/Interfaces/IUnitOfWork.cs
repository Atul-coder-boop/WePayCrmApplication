namespace CleanArch.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IContactRepository Contacts { get; }
        IFreshLeadsRepository Leads { get; }
    }
}
