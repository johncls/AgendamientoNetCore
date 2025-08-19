
using System.Data;

namespace Application.Abstractions.Behaviors.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}