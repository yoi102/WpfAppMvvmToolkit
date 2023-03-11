using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMvvmToolkit.Core.Models;

namespace WpfAppMvvmToolkit.Core.Services
{
    public interface IHttpRestClient
    {
        Task<ApiResponse> ExecuteRequestAsync(BaseRequest baseRequest);
        Task<IActionResult> ExecuteFileRequestAsync(BaseRequest baseRequest);











    }
}
