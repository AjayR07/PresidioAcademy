using AutoMapper;
using PresidioAcademy.Application.DTO;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.API.Profiles;

public class AssetProfile: Profile
{
    public AssetProfile()
    {
        CreateMap<AssetDTO, Asset>().ReverseMap();
    }
    
}