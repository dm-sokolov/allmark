using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllMark.Core.Models;
using AllMark.Repository;
using AllMark.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate.Linq;

namespace AllMark.HostedServices
{
    public class CategoryUpdate : IHostedService, IDisposable
    {
        private readonly IServiceProvider _services;
        private Timer _timer;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="services"></param>
        public CategoryUpdate(IServiceProvider services)
        {
            _services = services;
        }

        private async void DoWork(object state)
        {
            using var scope = _services.CreateScope();
            var provider = scope.ServiceProvider;
            var categoryRepository = provider.GetRequiredService<IRepository<Category>>();
            var nationalCatalogService = provider.GetRequiredService<INationalCatalogService>();
            var emailService = provider.GetRequiredService<IEmailService>();

            try
            {
                var categories = await nationalCatalogService.GetCategories();
                var categoryIds = categories.Select(i => i.Id);
                var existingCategories = await categoryRepository.Query()
                    .Where(i => categoryIds.Contains(i.CategoryId))
                    .ToListAsync();
                var newCategories = categories.Where(i => existingCategories.All(c => c.CategoryId != i.Id))
                    .OrderBy(i => i.Level)
                    .ToList();
                var count = 0;
                foreach (var newCategory in newCategories)
                {
                    var category = new Category
                    {
                        CategoryId = newCategory.Id,
                        Level = newCategory.Level,
                        Name = newCategory.Name,
                        ParentId = newCategory.ParentId
                    };
                    await categoryRepository.SaveAsync(category);

                    count++;
                    if (count % 25 == 0)
                        await categoryRepository.FlushAsync();
                }

                await categoryRepository.FlushAsync();
            }
            catch (Exception exception)
            {
                await emailService.SendEmailAsync("markirovschik@yandex.ru", $"Exception in {nameof(CategoryUpdate)}", $"{exception.Message} \n{exception.InnerException?.Message}");
                await StopAsync(default);
                await Task.Delay(10000);
                await StartAsync(default);

            }
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(new TimerCallback(DoWork), null, TimeSpan.Zero,
                                TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose() => _timer?.Dispose();
    }
}
