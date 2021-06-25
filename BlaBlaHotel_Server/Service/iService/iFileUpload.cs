using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaHotel_Server.Service.iService
{
    public interface iFileUpload
    {
        Task<string> UploadFile(IBrowserFile File);

        bool DeleteFile(string FileName);

    }
}
