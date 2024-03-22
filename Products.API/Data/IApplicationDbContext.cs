using MongoDB.Driver;
using Products.API.Entities;

namespace Products.API.Data;

public interface IApplicationDbContext
{
    IMongoCollection<Product> Products { get; }
}
