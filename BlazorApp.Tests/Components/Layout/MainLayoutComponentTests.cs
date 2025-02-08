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
    private readonly IRenderedComponent<MainLayout> cut;

    public MainLayoutComponentTests()
    {
        Services.AddSingleton<IJSRuntime>(_jsRuntimeMock.Object);
         cut = RenderComponent<MainLayout>();
    }

    [Fact]
    public void ClickingButton_ShouldShowModalDialog()
    {
        // Arrange & Act
        var button = cut.Find("button");
        button.Click();

        // Assert
        Assert.Contains("myModal", cut.Markup);
    }

    [Fact]
    public void DefaultState_ShouldNotShowModalDialog()
    {
        // Arrange & Act & Assert
        Assert.DoesNotContain("myModal", cut.Markup);
    }

    [Fact]
    public void Button_ShouldDisplayCurrentCulture()
    {
        // Arrange & Act
        var button = cut.Find("button");

        // Assert
        Assert.Contains(CultureInfo.CurrentCulture.DisplayName, button.TextContent);
    }

    [Fact]
    public void OnOpenDialog_ShouldSetShowModalDialogToTrue()
    {
        // Arrange & Act
        cut.InvokeAsync(() => cut.Instance.OnOpenDialog());

        // Assert
        Assert.True(cut.Instance.ShowModalDialog);
    }

    [Fact]
    public void OnCloseDialog_ShouldSetShowModalDialogToFalse()
    {
        // Arrange
        cut.Instance.ShowModalDialog = true;

        // Act
        cut.InvokeAsync(() => cut.Instance.OnCloseDialog());

        // Assert
        Assert.False(cut.Instance.ShowModalDialog);
    }
}
