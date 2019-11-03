using AllMark.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AllMark.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEmailService _emailService;

        public ExceptionMiddleware(RequestDelegate next, IEmailService emailService)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _emailService = emailService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                if (context.Response.HasStarted)
                    throw;
                var str = new StringBuilder();
                str.AppendLine($"Message {exception.Message}");
                str.AppendLine($"Stack trace {exception.StackTrace}");
                var ex = exception.InnerException;
                while(ex != null)
                {
                    str.AppendLine("Inner exception");
                    str.AppendLine($"Message {ex.Message}");
                    str.AppendLine($"Stack trace {ex.StackTrace}");
                    ex = ex.InnerException;
                }
                await _emailService.SendEmailAsync("esaulkovNikolay@yandex.ru", "Exception", str.ToString());
                context.Response.Clear();
                context.Response.Redirect("/Home/Error");
                return;
            }
        }
    }
}
