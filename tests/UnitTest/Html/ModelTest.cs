using Aspa.Html.Constants;
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
    const string expectedTitle  = LoremIpsum.Title;
    const string expectedMain = LoremIpsum.Main;
    Model model = new();
    
    // Assert
    Assert.True(model.Minified);
    Assert.Equal(expectedTitle, model.Title);
    Assert.Equal(expectedMain, model.Main);
  }
}