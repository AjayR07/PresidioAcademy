using System.ComponentModel.DataAnnotations;

namespace PresidioAcademy.Application.DTO;

public class AssetDTO
{
    [Key]
    // [RegularExpression("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})|([0-9a-fA-F]{4}\\.[0-9a-fA-F]{4}\\.[0-9a-fA-F]{4})$")]
    public string MacAddress { get; set; } = null!;

    public string SerialNo { get; set; } = null!;

    public string ModelName { get; set; } = null!;

    public string Os { get; set; } = null!;
}