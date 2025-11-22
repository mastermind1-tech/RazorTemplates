using Microsoft.AspNetCore.Components.Web;
using RazorFun.lib;

namespace Microsoft.AspNetCore.Components;

public static class RenderFragmentExtensions
{
    extension(RenderFragment fragment)
    {
        public async Task<string> RenderAsync(IServiceProvider services)
        {
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            using var renderer = new HtmlRenderer(services, loggerFactory);
            var parameters = new FragmentComponent.ParametersDictionary(fragment);
            var parameterView = ParameterView.FromDictionary(parameters);
            var root = await renderer.Dispatcher.InvokeAsync(() => renderer.RenderComponentAsync<FragmentComponent>(parameterView));
            await root.QuiescenceTask;
            return await renderer.Dispatcher.InvokeAsync(root.ToHtmlString);
        }
    }
}
