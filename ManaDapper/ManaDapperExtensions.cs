using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ManaDapper
{
    public static class ManaDapperExtensions
    {
        public static async Task<IEnumerable<T>> QueryToList<T>(this IDbConnection db, string sql, CommandType type = CommandType.TableDirect, object parameters = null)
            where T : class
        {
            var result = await db.QueryAsync<T>(sql, parameters, commandType: type);
            return result.ToList();
        }
        public static async Task<T> QueryFirstOrDefault<T>(this IDbConnection db, string sql, CommandType type = CommandType.TableDirect, object parameters = null)
            where T : class
        {
            var result = await db.QueryAsync<T>(sql, parameters, commandType: type);
            return result.FirstOrDefault();
        }
        public static async Task<T> QueryLastOrDefault<T>(this IDbConnection db, string sql, CommandType type = CommandType.TableDirect, object parameters = null)
            where T : class
        {
            var result = await db.QueryAsync<T>(sql, parameters, commandType: type);
            return result.LastOrDefault();
        }
    }
}
