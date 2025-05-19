namespace Aspa.html;

public class Builder
{
    private const string FolderPath = "public"; 
    private const string FileName = "index.html"; 

    public Builder()
    {
        SaveFile();
    }

    private void SaveFile()
    {
        string filePath = Path.Combine(FolderPath, FileName);
        File.WriteAllText(filePath, GetContent());
    }

    private string GetContent(bool minified = true)
    {
        if (minified)
        {
            return Template.Content
                .Replace("\r\n", "")
                .Replace("\n", "")
                .Replace("\t", "")
                .Replace(" ", "")
                .Trim();
        }
        return Template.Content;
    }
}