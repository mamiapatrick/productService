namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private IProductService _ProductService;
    private IMapper _mapper;

    public ProductController(
        IProductService ProductService,
        IMapper mapper)
    {
        _ProductService = ProductService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var Products = _ProductService.GetAll();
        return Ok(Products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var Product = _ProductService.GetById(id);
        return Ok(Product);
    }

    [HttpPost]
    public IActionResult Create(Product model)
    {
        _ProductService.Create(model);
        return Ok(new { message = "Product created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product model)
    {
        _ProductService.Update(id, model);
        return Ok(new { message = "Product updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _ProductService.Delete(id);
        return Ok(new { message = "Product deleted" });
    }
}