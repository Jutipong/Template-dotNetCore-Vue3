using AutoMapper;
using DAL.DataWrapper;
using DAL.Entity;
using DAL.Model.Commons;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Text.Json;

namespace TCRB.BLL
{
    public class UserTestDataService
    {
        private readonly ILogger _logger;
        private readonly IDataAccessWrapper _dataAccess;

        public UserTestDataService(IDataAccessWrapper dataAccess, ILogger<UserTestDataService> logger)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public DataTableResponseModel InquiryMasterDatatable(DatableOption option, UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new DataTableResponseModel();

            try
            {
                _logger.LogInformation($"Start Function => {methodName}, Parameters => {JsonSerializer.Serialize(userTest)}");
                result = _dataAccess.UserTestDataAccess.InquiryMasterDatatable(option, userTest);
                _logger.LogInformation($"Finish Function => {methodName}, Result => {JsonSerializer.Serialize(result)}");
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return result;
        }

        public ResponseModels<UserTest> Inquiry(UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var response = new ResponseModels<UserTest>();

            try
            {
                _logger.LogInformation($"Start Function => {methodName}, Parameters => {JsonSerializer.Serialize(userTest)}");
                var result = _dataAccess.UserTestDataAccess.Inquiry(userTest);
                response = result;
                _logger.LogInformation($"Finish Function => {methodName}, Result => {JsonSerializer.Serialize(result)}");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return response;
        }

        public ResponseModel Create(UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var response = new ResponseModel();

            try
            {
                _logger.LogInformation($"Start Function => {methodName}, Parameters => {JsonSerializer.Serialize(userTest)}");
                var result = _dataAccess.UserTestDataAccess.Create(userTest);
                response.Datas = result;
                response.Success = true;
                _logger.LogInformation($"Finish Function => {methodName}, Result => {JsonSerializer.Serialize(result)}");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return response;
        }

        public ResponseModel Update(UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel();

            try
            {
                _logger.LogInformation($"Start Function => {methodName}, Parameters => {JsonSerializer.Serialize(userTest)}");
                result = _dataAccess.UserTestDataAccess.Update(userTest);
                _logger.LogInformation($"Finish Function => {methodName}, Result => {JsonSerializer.Serialize(result)}");
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return result;
        }

        public ResponseModel Delete(UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var response = new ResponseModel();

            try
            {
                _logger.LogInformation($"Start Function => {methodName}, Parameters => {JsonSerializer.Serialize(userTest)}");
                var result = _dataAccess.UserTestDataAccess.Delete(userTest);
                _logger.LogInformation($"Finish Function => {methodName}, Result => {JsonSerializer.Serialize(result)}");

                response.Datas = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return response;
        }
    }
}