using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AllMark.Services.Interfaces
{
    public interface IExcelService
    {
        void ReadFile(Stream stream);

        void ReadFiles(IEnumerable<IFormFile> files);
    }
}
