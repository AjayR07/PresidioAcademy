using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresidioAcademy.Application.Interfaces;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.API.Controllers;
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AssetController: ControllerBase
{
    private readonly IAssetService _assetService;
    
    public AssetController(IAssetService assetService)
    {
        _assetService = assetService;
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<List<Asset>> GetAllAssets()
    {
        return Ok(_assetService.GetAllAssets());
    }
    
    [HttpGet]
    public ActionResult<Asset> GetAssetById(string macAddr)
    {
        return Ok(_assetService.GetAssetByMacAddr(macAddr));
    }
    
    [HttpPost]
    public ActionResult<Asset> AddAsset(Asset asset)
    {
        _assetService.AddNewAsset(asset);
        return Ok(asset);
    }
    
    [HttpDelete]
    public ActionResult<string> DeleteAsset(string macAddr)
    {
        _assetService.RemoveAsset(macAddr);
        return Ok("Deleted Successfully");
    }

    [HttpPut]
    public ActionResult<string> UpdateAsset(Asset asset)
    {
        _assetService.UpdateAsset(asset);
        return Ok("Updated Successfully");
    }


}