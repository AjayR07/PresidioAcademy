using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.Services;

public class AssetService: IAssetService
{
    private readonly IAssetRepository _assetRepository;

    public AssetService(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }
    public IEnumerable<Asset> GetAllAssets()
    {
        return _assetRepository.GetAll();
    }

    public Asset? GetAssetByMacAddr(string macAddr)
    {
        return _assetRepository.GetByMacAddr(macAddr);
    }

    public void AddNewAsset(Asset asset)
    {
        _assetRepository.Add(asset);
    }

    public void RemoveAsset(string macAddr)
    {
        var asset = GetAssetByMacAddr(macAddr);
        if(asset!=null) 
            _assetRepository.Delete(asset);
    }

    public void UpdateAsset(Asset asset)
    {
        _assetRepository.Update(asset);
    }
}