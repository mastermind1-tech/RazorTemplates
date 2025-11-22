using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using RazorFun.lib;

namespace Microsoft.AspNetCore.Http;

public static partial class HtmlResultsExtensions
{
    extension(Results)
    {
        public static RazorComponentResult Razor(RenderFragment fragment, int? statusCode = null, string? contentType= null)
        {
            return new RazorComponentResult<FragmentComponent>(new FragmentComponent.ParametersDictionary(fragment))
            {
                StatusCode = statusCode,
                ContentType = contentType,
                PreventStreamingRendering = true
            };
        }
    }
}
