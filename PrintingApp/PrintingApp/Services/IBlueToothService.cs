using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrintingApp.Services
{
    public interface IBlueToothService
    {
        IList<string> GetDeviceList();
        Task Print(string deviceName, string text);
    }

}
