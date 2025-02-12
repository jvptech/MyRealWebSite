using BlazorApp.Components.Layout;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;

namespace BlazorAppTests.Components.Layout;

public class ModalDialogComponentTests : TestContext
{
    private readonly Mock<IJSRuntime> _jsRuntimeMock = new();
    private readonly IRenderedComponent<ModalDialog> cut;

    public ModalDialogComponentTests()
    {
        Services.AddSingleton<IJSRuntime>(_jsRuntimeMock.Object);
        cut = RenderComponent<ModalDialog>();
    }

    [Fact]
    public void DefaultState_ShouldShowModalDialog()
    {
        // Arrange & Act & Assert
        Assert.Contains("modal-dialog", cut.Markup);
    }

    [Fact]
    public void ModalDialog__ShouldRender_CorrectH4()
    {
        // Arrange & Act
        var heading = cut.Find("h4");

        // Assert
        heading.GetAttribute("value").Should().Equals("Choose you langue");
    }

    [Fact]
    public void Button_ShouldDisplayCurrentCulture()
    {
        // Arrange & Act
        var button = cut.Find("button");

        // Assert
        button.GetAttribute("value").Should().Equals("Close");
    }
}
