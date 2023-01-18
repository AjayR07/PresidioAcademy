using System.Data.SqlClient;

namespace PresidioAcademy.Infrastructure.DbContext;

public interface IADOContext
{
    SqlConnection connection { get; }
}