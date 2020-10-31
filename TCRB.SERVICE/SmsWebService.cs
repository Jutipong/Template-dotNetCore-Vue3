using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TCRB.DAL.Model;
using TCRB.DAL.Model.Appsetting;
using TCRB.DAL.Model.Commons;
using TCRB.DAL.Model.Sms;

namespace TCRB.SERVICE
{
    public class SmsWebService
    {
        private readonly ILogger<SmsWebService> _logger;
        private readonly AppsittingModel _appsitting;
        private string methodName([CallerMemberName] string name = null) => name;

        public SmsWebService(ILogger<SmsWebService> logger, IOptions<AppsittingModel> appsitting)
        {
            _logger = logger;
            _appsitting = appsitting.Value;
        }
        public async Task<ResponseModel> RequestOTPAsync(OTPMessage oTPMessage, Guid tokenID)
        {
            var result = new ResponseModel();
            try
            {
                oTPMessage.TimeMinute = _appsitting.SmsSettings.TimeMinute;
                _logger.LogInformation($"Start Function => {methodName()}, Parameters => {JsonSerializer.Serialize(oTPMessage)}");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_appsitting.SmsSettings.Url.Base);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("TokenID", tokenID.ToString());

                    using (var content = new StringContent(JsonSerializer.Serialize(oTPMessage), Encoding.UTF8, "application/json"))
                    {
                        HttpResponseMessage res = await client.PostAsync(_appsitting.SmsSettings.Url.RequestOTP, content);
                        string contentResponse = await res.Content.ReadAsStringAsync();

                        _logger.LogInformation($"Call API: {_appsitting.SmsSettings.Url.Base}/{_appsitting.SmsSettings.Url.RequestOTP} => {methodName()} " +
                            $", Request => {JsonSerializer.Serialize(oTPMessage)}" +
                            $", Response => {JsonSerializer.Serialize(contentResponse)}");

                        var datas = JsonSerializer.Deserialize<ResponseIWalletApi>(JsonSerializer.Deserialize<object>(contentResponse).ToString());

                        result.Success = datas.rspresult;
                        result.Code = result.Success ? datas.message?.FirstOrDefault()?.TCRBRS02 : null;
                        result.Datas = datas?.message;
                    }
                }

                _logger.LogInformation($"Finish Function => {methodName()}, Result => {JsonSerializer.Serialize(result)}");
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                _logger.LogError(ex, $"Error Function => {methodName()}");
            }
            return result;
        }

        public async Task<ResponseModel> VerifyOTP(ReferidOTP referidOTP)
        {
            var result = new ResponseModel();
            try
            {
                _logger.LogInformation($"Start Function => {methodName()}, Parameters => {JsonSerializer.Serialize(referidOTP)}");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_appsitting.SmsSettings.Url.Base);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var content = new StringContent(JsonSerializer.Serialize(referidOTP), Encoding.UTF8, "application/json"))
                    {
                        HttpResponseMessage res = await client.PostAsync(_appsitting.SmsSettings.Url.VerifyOTP, content);
                        string contentResponse = await res.Content.ReadAsStringAsync();

                        _logger.LogInformation($"Call API: {_appsitting.SmsSettings.Url.Base}/{_appsitting.SmsSettings.Url.VerifyOTP} => {methodName()} " +
                            $", Request => {JsonSerializer.Serialize(referidOTP)}" +
                            $", Response => {JsonSerializer.Serialize(contentResponse)}");

                        var datas = JsonSerializer.Deserialize<ResponseIWalletApi>(JsonSerializer.Deserialize<object>(contentResponse).ToString());

                        var isSuccess = (datas.message?.FirstOrDefault()?.TCRBRS02 == "true");
                        result.Success = isSuccess;
                        result.Code = (result.Success ? "P002" :
                            ((bool)(datas.message?.FirstOrDefault()?.TCRBRS03?.Contains("OTP Expire time")) ? "E003" : "E005"));
                        result.Datas = datas?.message;
                    }
                }

                _logger.LogInformation($"Finish Function => {methodName()}, Result => {JsonSerializer.Serialize(result)}");
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Code = "E002";
                _logger.LogError(ex, $"Error Function => {methodName()}");
            }
            return result;
        }

    }
}
