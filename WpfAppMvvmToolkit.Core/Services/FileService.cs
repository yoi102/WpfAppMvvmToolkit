using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMvvmToolkit.Core.Models;

namespace WpfAppMvvmToolkit.Core.Services
{
    public class FileService : IFileService
    {
        private readonly IHttpRestClient httpRestClient;

        public FileService(IHttpRestClient httpRestClient)
        {
            this.httpRestClient = httpRestClient;
        }


        public async Task<IActionResult> UploadAsync(List<string> directories,string userAccount)
        {
            BaseRequest baseRequest = new BaseRequest();
            baseRequest.Files = directories;
            baseRequest.Parameters = new Dictionary<string, string>
            {
                { "subDirectory", userAccount }
            };
            return await httpRestClient.ExecuteFileRequestAsync(baseRequest);
        }

    }
}
