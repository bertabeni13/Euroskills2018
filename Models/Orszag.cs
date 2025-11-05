using System.ComponentModel.DataAnnotations;

namespace Euroskills2018.Razor.Models;

public class Orszag
{
    [Key]
    [StringLength(2)]
    public string Id { get; set; } = default!;

    [Required, StringLength(31)]
    public string OrszagNev { get; set; } = default!;

    public ICollection<Versenyzo> Versenyzok { get; set; } = new List<Versenyzo>();
}

