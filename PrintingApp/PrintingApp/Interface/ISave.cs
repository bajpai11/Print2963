using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PrintingApp.Interface
{
    public interface ISave
    {
        Task SaveTextAsync(string filename, string contentType, MemoryStream s);
    }
}
