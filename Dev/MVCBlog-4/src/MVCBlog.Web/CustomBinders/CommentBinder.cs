using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCBlog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Web.CustomBinders
{
    public class CommentBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(CommentDto))
            {
                try
                {
                    var postId = bindingContext.ValueProvider.GetValue("postId").ConvertTo<int>();
                    var text = bindingContext.ValueProvider.GetValue("text").FirstValue;
                    var name = bindingContext.ValueProvider.GetValue("name").FirstValue;
                    var surname = bindingContext.ValueProvider.GetValue("surname").FirstValue;

                    var comment = new CommentDto
                    {
                        PostId = postId,
                        Text = text,
                        Author = $"{name}, {surname}"
                    };

                    bindingContext.Result = ModelBindingResult.Success(comment);
                }
                catch (Exception)
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }
            return Task.CompletedTask;
        }
    }
}
