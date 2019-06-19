using System;
using System.Collections.Generic;
using System.Text;

namespace PrintingApp.Interface
{
    public interface IAppPaymentService
    {
        string PhonePay(string amount);
     }
}
