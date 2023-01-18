using FluentValidation;
using PresidioAcademy.Domain.Models;

namespace PresidioAcademy.Application.Validators;

public class AssetValidator: AbstractValidator<Asset>
{
    public AssetValidator()
    {
        RuleFor(asset => asset.MacAddress).NotNull().Length(17);
        RuleFor(asset => asset.SerialNo).NotNull().Length(1, 256).WithMessage("Serial No is Mandatory");
        RuleFor(asset => asset.Employee).InjectValidator();
    }
}