using System.Data;
using Microsoft.AspNetCore.Http;

namespace CTI.Asset.Management.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbConnection Connection { get; private set; }

        protected readonly IHttpContextAccessor httpContextAcessor;

        public UnitOfWork(IDbConnection connection, IHttpContextAccessor httpContextAcessor)
        {
            this.Connection = connection;
            this.httpContextAcessor = httpContextAcessor;
        }

        public long? SessionID => httpContextAcessor?.HttpContext?.GetHashCode();

        public IDbTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }
    }
}