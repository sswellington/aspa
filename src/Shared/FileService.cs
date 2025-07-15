using Aspa.Html.Constants;

namespace Aspa.Shared;

public class FileService
{
    public readonly LoggerService Logger;
    private const string FolderToKeepAfterClean = "assets"; 
    
    public FileService()
    {
        Logger = new LoggerService();

        CheckPublicFolder();
        CheckLoggerFile();
        
        DeleteFiles();
        DeleteDirectories();
        //CreateBlogFolder();
    }

    private void CheckLoggerFile()
    {
        const string loggerFolderPath = "log";
        string loggerFilePath = Path.Combine(loggerFolderPath, "aspa.log");
        
        if (!Directory.Exists(loggerFolderPath))
        {
            Directory.CreateDirectory(loggerFolderPath);
            Logger.Information("Create directory: Logger");
        }

        if (File.Exists(loggerFilePath)) 
            return;
        
        File.WriteAllText(loggerFilePath, string.Empty);
        Logger.Information("Create file: Logger");
    }
    
    private void CheckPublicFolder()
    {
        if (Directory.Exists(FilePath.FolderPath)) 
            return;
        
        Logger.Warning("Directory doesn't exist");
    }
    
    private void DeleteFiles()
    {
        string[] allFilesInBasePath = Directory.GetFiles(FilePath.FolderPath);
        foreach (string file in allFilesInBasePath)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception)
            {
                Logger.Warning($"File {file} was not deleted");
            }
        }
    }

    private void DeleteDirectories()
    {
        string[] allDirectoriesInBasePath = Directory.GetDirectories(FilePath.FolderPath);
        foreach (string directoryPath in allDirectoriesInBasePath)
        {
            string directoryName = Path.GetFileName(directoryPath);

            if (string.Equals(directoryName, FolderToKeepAfterClean, StringComparison.OrdinalIgnoreCase)) 
                continue;
            
            try
            {
                Directory.Delete(directoryPath, true); 
            }
            catch (Exception)
            {
                Logger.Warning($"Directory {directoryPath} was not deleted");
            }
        }
    }
    
    private void CreateBlogFolder()
    {
        string basePath = FilePath.FolderPath;
        string blogFolderPath = Path.Combine(basePath, "blog");

        try
        {
            if (!Directory.Exists(blogFolderPath))
            {
                Directory.CreateDirectory(blogFolderPath);
            }
        }
        catch (Exception)
        {
            Logger.Warning($"Directory {blogFolderPath} was not created");
        }
    }
}