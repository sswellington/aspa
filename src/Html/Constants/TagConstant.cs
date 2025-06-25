namespace Aspa.Html.Constants;

public enum TagLevel
{
  None = 0,
  Is1 = 1,
  Is2 = 2,
  Is3 = 3,
  Is4 = 4,
  Is5 = 5,
  Is6 = 6
}

public static class TagConstant
{
  public static char Heading => 'h';
  public static char Paragraph => 'p';
  public static string Title => "title";
  public static string Main => "main";
}