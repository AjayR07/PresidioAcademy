using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.Interfaces;

public interface IAssetService
{
    IEnumerable<Asset> GetAllAssets();

    Asset? GetAssetByMacAddr(string macAddr);

    void AddNewAsset(Asset asset);

    void RemoveAsset(string macAddr);

    void UpdateAsset(Asset asset);
}