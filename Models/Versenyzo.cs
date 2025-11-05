using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euroskills2018.Razor.Models;

public class Versenyzo
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(31)]
    public string Nev { get; set; } = default!;

    [Required, StringLength(2)]
    public string SzakmaId { get; set; } = default!;

    [ForeignKey(nameof(SzakmaId))]
    public Szakma? Szakma { get; set; }

    [Required, StringLength(2)]
    public string OrszagId { get; set; } = default!;

    [ForeignKey(nameof(OrszagId))]
    public Orszag? Orszag { get; set; }

    [Required]
    public int Pont { get; set; }
}

