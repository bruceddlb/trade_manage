using System;
using System.Collections.Generic;
using System.Web;

namespace QSDMS.API.Payment.WxPay
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}