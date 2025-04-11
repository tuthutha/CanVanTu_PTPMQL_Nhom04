using System.ComponentModel.DataAnnotations;
using DemoMVC.Models;
public class HeThongPhanPhoi
{
    [Key]
    public string MaHTPP { get; set; }

    public string TenHTPP { get; set; }

    public List<DaiLy>? DaiLys { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public HeThongPhanPhoi()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        MaHTPP = GenerateMaHTPP();
    }

    private string GenerateMaHTPP()
    {
        return "HTPP-" + Guid.NewGuid().ToString("N").Substring(6).ToUpper();
    }
}