using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrintingApp.Interface
{
  public interface IQrScanningService
    {
        Task<string> ScanAsync();

    }
}
