using BlazorApp.Components.Layout;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using System.Globalization;

namespace BlazorAppTests.Components.Layout;

public class MainLayoutComponentTests : TestContext
{
    private readonly Mock<IJSRuntime> _jsRuntimeMock = new();

    [Fact]
    public void ClickingButton_ShouldShowModalDialog()
    {
        // Arrange
        Services.AddSingleton<IJSRuntime>(_jsRuntimeMock.Object);
        var cut = RenderComponent<MainLayout>();

        // Act
        var button = cut.Find("button");
        button.Click();

        // Assert
        Assert.Contains("myModal", cut.Markup);
    }

    [Fact]
    public void DefaultState_ShouldNotShowModalDialog()
    {
        // Arrange & Act
        var cut = RenderComponent<MainLayout>();

        // Assert
        Assert.DoesNotContain("myModal", cut.Markup);
    }

    [Fact]
    public void Button_ShouldDisplayCurrentCulture()
    {
        // Arrange
        var cut = RenderComponent<MainLayout>();

        // Act
        var button = cut.Find("button");

        // Assert
        Assert.Contains(CultureInfo.CurrentCulture.DisplayName, button.TextContent);
    }
}
