using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ISession = NHibernate.ISession;

namespace AllMark.Middlewares
{
    public class CloseSessionMiddleware
    {
        private readonly RequestDelegate _next;

        public CloseSessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ISession session)
        {
            await _next(context);
            await CloseSession(session);
        }

        private async Task CloseSession(ISession session)
        {
            try
            {
                if (session.Transaction?.IsActive ?? false)
                    await session.Transaction.CommitAsync();
            }
            catch
            {
                if (session.Transaction?.IsActive ?? false)
                    await session.Transaction.RollbackAsync();

                throw;
            }
            finally
            {
                session.Dispose();
            }

        }
    }
}
