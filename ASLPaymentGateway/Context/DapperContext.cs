using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ASLPaymentGateway.Context
{
    public class DapperContext:DbContext,IDisposable
    {
       // DatabaseFacade Database { get; }
        public IDbConnection Connection => Database.GetDbConnection();

        public DapperContext(DbContextOptions<DapperContext> options) : base(options)
        {
       
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return (await Connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public override void Dispose()
        {
         
            GC.SuppressFinalize(this);
        }
    }
}
