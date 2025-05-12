using CleanArch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ILeadsRepository<T> where T : class
    {
        Task<string> AddAsync(T entity);
        Task<int> GetCredManagerIDAsync();
        int GetLeadAssignIDAsync();
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetFreshLeadByIdAsync(string id);
        Task<string> UpdateLoanRequest(string CustomerID,UpdateLonaRequest entity);
        Task<string> AddCustomerAddres(CuctomerAddress cuctomerAddress);

        Task<IReadOnlyList<CuctomerAddress>> GetCuctomerAddressByID(string ID);
        
    }
}
