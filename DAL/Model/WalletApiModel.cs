using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.Model
{
    public class ResponseIWalletApi
    {
        public bool rspresult { get; set; }
        public IWalletApiHeader header { get; set; }
        public List<IWalletApiMessage> message { get; set; }
    }
    public class IWalletApiHeader
    {
        public string TCRBRH01 { get; set; }
        public string TCRBRH02 { get; set; }
        public string TCRBRH03 { get; set; }
        public string TCRBRH04 { get; set; }
        public string TCRBRH05 { get; set; }
    }
    public class IWalletApiMessage
    {
        public string TCRBRS01 { get; set; }
        public string TCRBRS02 { get; set; }
        public string TCRBRS03 { get; set; }
        public string TCRBRS04 { get; set; }
        public string TCRBRS05 { get; set; }
        public string TCRBRS06 { get; set; }
        public string TCRBRS07 { get; set; }
        public string TCRBRS08 { get; set; }
        public string TCRBRS09 { get; set; }
        public string TCRBRS10 { get; set; }
        public string TCRBRS11 { get; set; }
        public string TCRBRS12 { get; set; }
        public string TCRBRS13 { get; set; }
        public string TCRBRS14 { get; set; }
        public string TCRBRS15 { get; set; }
        public string TCRBRS16 { get; set; }
        public string TCRBRS17 { get; set; }
        public string TCRBRS18 { get; set; }
        public string TCRBRS19 { get; set; }
        public string TCRBRS20 { get; set; }
    }
}
