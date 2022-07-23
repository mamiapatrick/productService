namespace Webapi.Models;

using System.ComponentModel.DataAnnotations;


public class Product
{
    [Required]
    public string Identifiant { get; set; }

    [Required]
    public string Code { get; set; }

    public string Nom { get; set; }


    public string Description { get; set; }

    [Required]
    public string Prix { get; set; }

    public string Date_expiration { get; set; }


}