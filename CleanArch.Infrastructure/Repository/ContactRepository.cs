using CleanArch.Application.Interfaces;
using CleanArch.Core.Entities;
using CleanArch.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CleanArch.Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {

        private readonly IConfiguration configuration;
        public ContactRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #region ===[ IContactRepository Methods ]==================================================
        public async Task<IReadOnlyList<Contact>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.QueryAsync<Contact>(ContactQueries.AllContact);

                return result.ToList();
            }
        }
        public async Task<Contact> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.QuerySingleOrDefaultAsync<Contact>(ContactQueries.ContactById, new { ContactId = id });

                return result;
            }
        }
        public async Task<string> AddAsync(Contact entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.ExecuteAsync(ContactQueries.AddContact, entity);

                return result.ToString();
            }
        }
        public async Task<string> UpdateAsync(Contact entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.ExecuteAsync(ContactQueries.UpdateContact, entity);

                return result.ToString();
            }
        }
        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.ExecuteAsync(ContactQueries.DeleteContact, new { ContactId = id });

                return result.ToString();
            }
        }

        #endregion
    }
}
