using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WpfAppMvvmToolkit.API.Services;

namespace WpfAppMvvmToolkit.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }
    [HttpPost]
    public IActionResult Upload([Required] List<IFormFile> formFiles, [Required] string subDirectory)
    {
        try
        {
            _fileService.UploadFile(formFiles, subDirectory);

            return Ok(new { formFiles.Count, Size = _fileService.SizeConverter(formFiles.Sum(f => f.Length)) });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    //返回单文件流





    //返回的zip
    [HttpGet]
    public IActionResult Download([Required] string subDirectory)
    {
        try
        {
            var (fileType, archiveData, archiveName) = _fileService.DownloadFiles(subDirectory);

            return File(archiveData, fileType, archiveName);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}