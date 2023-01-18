using System.Data;
using System.Data.SqlClient;
using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;
using PresidioAcademy.Infrastructure.DbContext;

namespace PresidioAcademy.Infrastructure.Repositories;

public class AssetRepository: GenericRepository<Asset>, IAssetRepository
{
    private readonly PresidioAcademyContext _context;
    private readonly SqlConnection _con;

    public AssetRepository(PresidioAcademyContext context,IADOContext sqlContext) : base(context)
    {
        _context = context;
        _con = sqlContext.connection;
    }

    public Asset? GetByMacAddr(string macAddr)
    {
        // return _context.Assets.Find(macAddr);
        Asset asset = new Asset();
        try
        {
            using (_con)
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from Asset where MacAddress like '" + macAddr + "'", _con);
                // cmd.CommandType == CommandType.StoredProcedure
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    asset.MacAddress = rdr["MacAddress"].ToString();
                    Console.WriteLine(asset.MacAddress);
                }

       
                return asset;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _con.Close();
        }
    }
}