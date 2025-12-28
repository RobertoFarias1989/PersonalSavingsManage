using System.ComponentModel.DataAnnotations;

namespace PersonalSavingsManage.Infrastructure.Settings;

public class JwtOptions
{
    [Required(ErrorMessage = "Issuer is mandatory.")]
    public string Issuer { get; init; }

    [Required(ErrorMessage = "Audience is mandatory.")]
    public string Audience { get; init; }

    [Required(ErrorMessage = "Key is mandatory.")]
    public string Key { get; init; }
}
