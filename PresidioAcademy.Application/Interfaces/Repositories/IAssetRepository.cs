using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.Interfaces;

public interface IAssetRepository: IGenericRepository<Asset>
{
    Asset? GetByMacAddr(string macAddr);
}