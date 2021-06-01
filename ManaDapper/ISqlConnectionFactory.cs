using System;
using System.Data;

namespace ManaDapper
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
