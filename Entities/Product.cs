namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class Product
{
    public string Identifiant { get; set; }

    public string Code { get; set; }

    public string Nom { get; set; }


    public string Description { get; set; }


    public string Prix { get; set; }

    public string Date_expiration { get; set; }
}