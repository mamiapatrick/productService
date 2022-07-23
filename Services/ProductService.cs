namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;


public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product GetById(int identifiant);
    void Create(Product model);
    void Update(int id, Product model);
    void Delete(int id);
}

public class ProductService : IProductService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public ProductService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products;
    }

    public Product GetById(int id)
    {
        return getProduct(id);
    }

    public void Create(Product model)
    {
        // validate
        if (_context.Products.Any(x => x.Identifiant == model.Identifiant))
            throw new Exception("Product avec l'identifiant '" + model.Identifiant + "' existant ");

        // map model to new Product object
        var Product = _mapper.Map<Product>(model);

        // save Product
        _context.Products.Add(Product);
        _context.SaveChanges();
    }

    public void Update(int id, Product model)
    {
        var Product = getProduct(id);

        // validate
        if (model.Identifiant != Product.Identifiant && _context.Products.Any(x => x.Identifiant == model.Identifiant))
            throw new Exception("cet identifiant'" + model.Identifiant + "' existe dejà ");


        // copy model to Product and save
        _mapper.Map(model, Product);
        _context.Products.Update(Product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var Product = getProduct(id);
        _context.Products.Remove(Product);
        _context.SaveChanges();
    }

    // helper methods

    private Product getProduct(int id)
    {
        var Product = _context.Products.Find(id);
        if (Product == null) throw new KeyNotFoundException("Product not found");
        return Product;
    }
}