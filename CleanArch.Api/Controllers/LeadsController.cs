using CleanArch.Api.Models;
using CleanArch.Application.Interfaces;
using CleanArch.Application.UseCaseoperations;
using CleanArch.Core.Entities;
using DocumentFormat.OpenXml.Math;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Data.SqlClient;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeadsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpPost]
        [ActionName("AddFreshLeads")]
        public async Task<ApiResponse<string>> Add()
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var data = "";
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            return apiResponse;
        }

        [HttpGet]
        [ActionName("GetAllFreshLeads")]
        public async Task<ApiResponse<List<FreshLeads>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<FreshLeads>>();
            try
            {
                var data = await _unitOfWork.Leads.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        [HttpGet("{id}")]
        [ActionName("GetLeadById")]
        public async Task<ApiResponse<FreshLeads>> GetLeadById(string id)
        {
            var apiResponse = new ApiResponse<FreshLeads>();
            try
            {
                var data = await _unitOfWork.Leads.GetFreshLeadByIdAsync(id);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        [HttpPost]
        [ActionName("UpdateLoanRequest")]
        public async Task<ApiResponse<string>> UpdateLeads(string CustomerID, UpdateLonaRequest updateLonaRequest)
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var data = await _unitOfWork.Leads.UpdateLoanRequest(CustomerID, updateLonaRequest);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        [HttpPost]
        [ActionName("AddCustomerAddresDetails")]
        public async Task<ApiResponse<string>> AddCustomerAddres(CuctomerAddress cuctomerAddress)
        {
            var apiResponse = new ApiResponse<string>();
            try
            {
                var data = await _unitOfWork.Leads.AddCustomerAddres(cuctomerAddress);
                apiResponse.Success = true;
                apiResponse.Message = data;
            }
            catch (Exception ex)
            {
                apiResponse.Success = true;
                apiResponse.Message = ex.ToString();
            }
            return apiResponse;
        }


        [HttpGet("{CustomerId}")]
        [ActionName("GetCustomerAddresById")]
        public async Task<ApiResponse<List<CuctomerAddress>>> GetAddressByID(string CustomerId)
        {
            var response = new ApiResponse<List<CuctomerAddress>>();
            try
            {
                var data = await _unitOfWork.Leads.GetCuctomerAddressByID(CustomerId);
                response.Success = true;
                response.Result = data.ToList();

              
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
