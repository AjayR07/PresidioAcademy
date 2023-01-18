using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
namespace PresidioAcademy.Infrastructure.DbContext;

public class ADOContext: IADOContext
{
  
    public SqlConnection connection { get; private set; }
    public ADOContext(IConfiguration configuration)
    {
        connection = new SqlConnection(configuration.GetConnectionString("SSMS-DB"));
    }

}