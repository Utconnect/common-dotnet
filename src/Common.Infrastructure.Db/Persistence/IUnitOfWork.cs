using System.Threading;
using System.Threading.Tasks;

namespace Utconnect.Common.Infrastructure.Db.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}