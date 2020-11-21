using HELPER;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DAL.Model.Commons
{
    public class _ResponseModel
    {
        public string ID { get; set; }
        public string Code { get; set; }

        public int Total { get; set; } = 0;

        private bool _Success = false;
        public bool Success
        {
            get
            {
                return _Success;
            }
            set
            {
                _Success = value;
            }
        }

        private int _StatusCode = StatusCodes.Status500InternalServerError;
        public int StatusCode
        {
            get
            {
                return _Success ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError;
            }
            set
            {
                _StatusCode = value;
            }
        }

        private string _Message = string.Empty; //EnumStatus.Fail.AsDescription();
        public string Message
        {
            get
            {
                if (string.IsNullOrEmpty(_Message))
                {
                    return _Success ? EnumHttpStatus.SUCCESS.AsDescription() : EnumHttpStatus.INTERNAL_SERVER_ERROR.AsDescription();
                }
                else
                {
                    return _Message;
                }
            }
            set
            {
                _Message = value;
            }
        }
    }
    public class ResponseModel : _ResponseModel
    {
        public object Datas { get; set; }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public new T Datas { get; set; }
    }

    public class ResponseModels<T> : ResponseModel
    {
        public new List<T> Datas { get; set; } = new List<T>();
    }
}
