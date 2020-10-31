using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Text.Json;
using TCRB.DAL.DataWrapper;
using TCRB.DAL.Model.Commons;

namespace TCRB.BLL
{
    public class UserManagementDataService
    {
        private readonly ILogger _logger;
        private readonly IDataAccessWrapper _dataAccess;

        public UserManagementDataService(IDataAccessWrapper dataAccess, ILogger<UserManagementDataService> logger)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public ResponseModel InquiryADUser(string adUser)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var response = new ResponseModel();

            try
            {
                _logger.LogInformation($"Start Function => {methodName}");

                var result = _dataAccess.UserManagementDataAccess.InquiryADUser(adUser);
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
    }
}
