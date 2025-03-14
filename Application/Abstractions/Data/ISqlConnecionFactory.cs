
using System.Data;

namespace Application.Abstractions.Behaviors.Data
{
    public interface ISqlConnecionFactory
    {
        IDbConnection CreateConnection();
    }
}