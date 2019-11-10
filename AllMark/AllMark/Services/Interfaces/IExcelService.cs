using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace AllMark.Services.Interfaces
{
    public interface IExcelService
    {
        void ReadFile(Stream stream);

        void ReadFiles(IEnumerable<IFormFile> files);
    }
}
