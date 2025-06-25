using Aspa.Html.Layout;

namespace UnitTest.Html;

public sealed class ModelTest
{
  [Fact]
  public void ShouldHaveMinifiedTrueByDefault()
  {
    // Arrange & Act
    Model model = new();
    
    // Assert
    Assert.True(model.Minified);
  }

    [Fact]
    public void ShouldInitializeDefaultHeadAndBodyContent()
  {
    // Arrange & Act
    string expectedTitle  = "Aspa";
    string expectedMain  = $"<h1> Lorem ipsum </h1> \n        <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. </p>";
    Model model = new();
    
    // Assert
    Assert.True(model.Minified);
    Assert.Equal(expectedTitle, model.Title);
    Assert.Equal(expectedMain, model.Main);
  }
}