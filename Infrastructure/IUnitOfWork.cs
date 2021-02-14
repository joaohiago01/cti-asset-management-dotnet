using System.Data;

namespace CTI.Asset.Management.Infrastructure
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
        long? SessionID { get; }
        IDbTransaction BeginTransaction();
    }
}