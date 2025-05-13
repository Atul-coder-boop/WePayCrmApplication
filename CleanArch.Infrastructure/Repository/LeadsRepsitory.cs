using CleanArch.Application.Interfaces;
using CleanArch.Core.Entities;
using CleanArch.Sql.Queries;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace CleanArch.Infrastructure.Repository
{
    public class LeadsRepsitory : IFreshLeadsRepository
    {
        public readonly IConfiguration _Configuration;

        public LeadsRepsitory(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public async Task<string> AddAsync(FreshLeads entity)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
                {
                    var result = await connection.ExecuteAsync(LeadsQueries.AddNewLeads, entity);
                    return result.ToString();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public async Task<int> GetCredManagerIDAsync()
        {
            using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
            {
                 var result =  connection.QuerySingle(LeadsQueries.GetRandomCredManagerID);
                return result.CredMgrId;
            }
        }

        public int GetLeadAssignIDAsync()
        {
            using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
            {
                var result = connection.QuerySingle(LeadsQueries.GetrandomTelecallerId);
                return result.CallerID;
            }
        }

        public async Task<IReadOnlyList<FreshLeads>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.QueryAsync<FreshLeads>(LeadsQueries.GetFresLeadsdata);

                return result.ToList();
            }
        }

        public async Task<FreshLeads> GetFreshLeadByIdAsync(string id)
        {
            using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.QuerySingleOrDefaultAsync<FreshLeads>(LeadsQueries.GetFresLeadsdataByID, new { CustomerId = id });

                return result!;
            }
        }

        public async Task<string> UpdateLoanRequest(string CustomerID, UpdateLonaRequest entity)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("CustomerId", CustomerID, DbType.String);
                param.Add("Purpose", entity.Purpose, DbType.String);
                param.Add("MonthlyIncome", entity.MonthlyIncome, DbType.String);
                param.Add("LoanRequired", entity.LoanRequired, DbType.String);
                param.Add("city", entity.city, DbType.String);
                param.Add("State", entity.State, DbType.String);
                param.Add("PinCode", entity.PinCode, DbType.String);
                using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
                {
                    var result = await connection.ExecuteAsync(LeadsQueries.UpdateloanApplicationDetails, param);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public  async Task<string> AddCustomerAddres(CuctomerAddress cuctomerAddress)
        {
            try
            {
                var parm = new DynamicParameters();
                parm.Add("@Type", cuctomerAddress.Type,DbType.String);
                parm.Add("@Address", cuctomerAddress.Address,DbType.String);
                parm.Add("@City", cuctomerAddress.City,DbType.String);
                parm.Add("@State", cuctomerAddress.State,DbType.String);
                parm.Add("@HouseType", cuctomerAddress.HouseType,DbType.String);
                parm.Add("@Pincode", cuctomerAddress.Pincode,DbType.String);
                parm.Add("@Status", cuctomerAddress.Status,DbType.String);
                parm.Add("@customerId", cuctomerAddress.customerId,DbType.String);
                using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
                {
                    var result = await connection.ExecuteAsync(LeadsQueries.InsertCustomerAddress, parm);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<IReadOnlyList<CuctomerAddress>> GetCuctomerAddressByID(string ID)
        {
            using (IDbConnection connection = new SqlConnection(_Configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.QueryAsync<CuctomerAddress>(LeadsQueries.GetCustomerAddressbyID, new { customerid = ID });
                return result.ToList()!;
            }
        }
    }
}
