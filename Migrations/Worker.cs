using System.Threading;
using System.Threading.Tasks;
using SecurityDevelopment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Migrations
{
    public class Worker : IHostedService
    {
        private readonly ApplicationContext _context;

        public Worker(ApplicationContext context)
        {
            _context = context;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _context.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}