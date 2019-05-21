using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace Nitor.WebApp.Helpers
{
    public static class SPAHelper
    {
        private static readonly string HREF_MATCH = " href=\"/";
        private static readonly string HREF_REPLACE = " href=\"/{0}/";
        private static readonly string SRC_MATCH = " src=\"/";
        private static readonly string SRC_REPLACE = " src=\"/{0}/";

        public async static Task<IHtmlContent> RenderReactPage(
            this IHtmlHelper helper,
            string appPath,
            string indexFile = "index.html"
        )
        {
            string indexContents = await File.ReadAllTextAsync(indexFile);

            indexContents = indexContents.Replace(HREF_MATCH, string.Format(HREF_REPLACE, appPath));
            indexContents = indexContents.Replace(SRC_MATCH, string.Format(SRC_REPLACE, appPath));

            return new HtmlString(indexContents);
        }

        public async static Task<IHtmlContent> RenderReactHead(
            this IHtmlHelper helper,
            string appPath,
            string indexFile = "index.html"
        ) => await RenderReactPageTag(helper, appPath, "head", indexFile);

        public async static Task<IHtmlContent> RenderReactBody(
            this IHtmlHelper helper,
            string appPath,
            string indexFile = "index.html"
        ) => await RenderReactPageTag(helper, appPath, "body", indexFile);

        public async static Task<IHtmlContent> RenderReactPageTag(
            this IHtmlHelper helper,
            string appPath,
            string tag,
            string indexFile = "index.html"
        )
        {
            string indexContents = await File.ReadAllTextAsync(indexFile);

            int openIndex = indexContents.IndexOf($"<{tag}>");
            int closeIndex = indexContents.IndexOf($"</{tag}>");
            indexContents = indexContents.Substring(
                                openIndex + tag.Length + 2,
                                closeIndex - openIndex - tag.Length - 2
                            );

            indexContents = indexContents.Replace(HREF_MATCH, string.Format(HREF_REPLACE, appPath));
            indexContents = indexContents.Replace(SRC_MATCH, string.Format(SRC_REPLACE, appPath));

            return new HtmlString(indexContents);
        }
    }
}