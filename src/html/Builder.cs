using System.Text.RegularExpressions;

public class Builder
{
    private const string FOLDER_PATH = "public"; 
    private const string FILE_NAME = "index.html"; 

    public Builder()
    {
        SaveFile();
    }

    public void SaveFile()
    {
        string filePath = Path.Combine(FOLDER_PATH, FILE_NAME);

        File.WriteAllText(filePath, GetContent());
    }

    public string GetContent(bool minified = true)
    {
        return minified ? Regex.Replace(Template.Content, @"\s+", "") : Template.Content;
    }
}