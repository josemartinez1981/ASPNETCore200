using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MVCBlog.Crosscutting.Configuration;

namespace MVCBlog.Web.CultureProviders
{
    public class BlogConfigRequestCultureProvider : RequestCultureProvider
    {
        private readonly BlogConfiguration blogConfiguration;

        public BlogConfigRequestCultureProvider(BlogConfiguration blogConfiguration)
        {
            if (blogConfiguration == null)
            {
                throw new ArgumentNullException(nameof(blogConfiguration));
            }

            this.blogConfiguration = blogConfiguration;
        }

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            return Task.FromResult(new ProviderCultureResult(this.blogConfiguration.DefaultCulture));
        }
    }
}
