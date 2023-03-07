using System.IO.Compression;
using WpfAppMvvmToolkit.API.Context.UnitOfWork;

namespace WpfAppMvvmToolkit.API.Services;

public class FileService : IFileService
{
    #region Field
    private readonly IUnitOfWork unitOfWork;//获取uow
    private readonly IWebHostEnvironment webHostEnvironment;

    #endregion

    #region Constructor

    public FileService(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
    {
        this.unitOfWork = unitOfWork;
        this.webHostEnvironment = webHostEnvironment;
    }


    #endregion

    #region Upload File

    public void UploadFile(List<IFormFile> files, string subDirectory)
    {
        subDirectory = subDirectory ?? string.Empty;
        //var target = Path.Combine(webHostEnvironment.ContentRootPath, subDirectory);//根目录+
        var target = Path.Combine(Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData), subDirectory);//应用配置存储文件位置

        Directory.CreateDirectory(target);

        files.ForEach(async file =>
        {
            if (file.Length <= 0) return;
            var filePath = Path.Combine(target, file.FileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
        });
    }

    #endregion

    #region Download File

    public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory)
    {
        var zipName = $"archive-{DateTime.Now:yyyy_MM_dd-HH_mm_ss}.zip";

        var files = Directory.GetFiles(Path.Combine(webHostEnvironment.ContentRootPath, subDirectory)).ToList();

        using var memoryStream = new MemoryStream();
        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            files.ForEach(file =>
            {
                var theFile = archive.CreateEntry(Path.GetFileName(file));
                using var binaryWriter = new BinaryWriter(theFile.Open());
                binaryWriter.Write(File.ReadAllBytes(file));
            });
        }

        return ("application/zip", memoryStream.ToArray(), zipName);
    }

    #endregion

    #region Size Converter

    public string SizeConverter(long bytes)
    {
        var fileSize = new decimal(bytes);
        var kilobyte = new decimal(1024);
        var megabyte = new decimal(1024 * 1024);
        var gigabyte = new decimal(1024 * 1024 * 1024);

        return fileSize switch
        {
            _ when fileSize < kilobyte => "Less then 1KB",
            _ when fileSize < megabyte =>
                $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB",
            _ when fileSize < gigabyte =>
                $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB",
            _ when fileSize >= gigabyte =>
                $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB",
            _ => "n/a"
        };
    }

    #endregion
}