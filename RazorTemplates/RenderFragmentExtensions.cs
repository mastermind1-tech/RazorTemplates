using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorTemplates;

namespace Microsoft.AspNetCore.Components;

public static class RenderFragmentExtensions
{
    extension(RenderFragment fragment)
    {
        public async Task<string> RenderAsync(IServiceProvider services, HtmlRenderer renderer)
        {
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            return await RenderImpl(fragment, renderer);
        }

        public async Task<string> RenderAsync(IServiceProvider services)
        {
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            using var renderer = new HtmlRenderer(services, loggerFactory);
            return await RenderImpl(fragment, renderer);
        }
    }

    private static async Task<string> RenderImpl(RenderFragment fragment, HtmlRenderer renderer)
    {
        var parameters = new FragmentComponent.ParametersDictionary(fragment);
        var parameterView = ParameterView.FromDictionary(parameters);
        var root = await renderer.Dispatcher.InvokeAsync(() => renderer.RenderComponentAsync<FragmentComponent>(parameterView));
        await root.QuiescenceTask;
        return await renderer.Dispatcher.InvokeAsync(root.ToHtmlString);
    }
}
