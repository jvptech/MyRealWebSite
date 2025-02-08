using BlazorApp.Components.Pages;
using Bunit;
using System.Globalization;

namespace BlazorAppTests.Components.Pages;

public class HomeComponentTests : TestContext
{
    private readonly IRenderedComponent<Home> cut;

    public HomeComponentTests()
    {
        cut = RenderComponent<Home>();
    }

    [Fact]
    public void HomePage_ShouldRender_CorrectH1()
    {
        // Arrange & Act
           var heading = cut.Find("h1");

        // Assert
        heading.MarkupMatches("<h1>Hello, world!</h1>");
    }

    [Fact]
    public void HomePage_ShouldRender_CorrectH3()
    {
        // Arrange & Act
        var heading = cut.Find("h3");

        // Assert
        heading.MarkupMatches("<h3>Culture Client</h3>");
    }

    [Fact]
    public void HomePage_ShouldRender_CorrectCultureInfo()
    {
        // Arrange
        var expectedCulture = CultureInfo.CurrentCulture.ToString();
        var expectedUICulture = CultureInfo.CurrentUICulture.ToString();

        // Act
        var heading = cut.Find("ul");

        // Assert
        heading.MarkupMatches($@"
            <ul>
                <li><b>CurrentCulture</b>: {expectedCulture}</li>
                <li><b>CurrentUICulture</b>: {expectedUICulture}</li>
            </ul>
        ");
    }
}
