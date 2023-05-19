using Main.Application.Models;

namespace Main.Application.Interfaces.Services;

public interface ISearchService
{
    ISearchBuilder CreateSearchBuilder(IEnumerable<Product> products, string keyword);
}

public interface ISearchBuilder
{
    ISearchBuilder InTitle();
    ISearchBuilder InCountry();
    ISearchBuilder InDescription();
    IEnumerable<Product> SearchProducts();
}