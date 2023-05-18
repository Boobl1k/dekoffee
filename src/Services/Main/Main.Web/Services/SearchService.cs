using System.Linq.Expressions;
using System.Reflection;
using Main.Application.Interfaces.Services;
using Main.Application.Models;

namespace Main.Services;

public class SearchService : ISearchService, ISearchBuilder
{
    private IEnumerable<Product> _products = null!;
    private readonly List<Expression<Func<Product, bool>>> _filters;
    private string _keyword = null!;
    private readonly ParameterExpression _parameter = Expression.Parameter(typeof(Product), "p");

    public SearchService() => _filters = new List<Expression<Func<Product, bool>>>();

    public ISearchBuilder CreateSearchBuilder(IEnumerable<Product> products, string keyword)
    {
        _products = products.OrderBy(p => p.Title).ThenBy(p => p.Country).ThenBy(p => p.Description);
        _keyword = keyword;
        return this;
    }

    public ISearchBuilder InTitle()
    {
        _filters.Add(CreateFilterExpression<Product>(_parameter, p => p.Title, _keyword));
        return this;
    }

    public ISearchBuilder InCountry()
    {
        _filters.Add(CreateFilterExpression<Product>(_parameter, p => p.Country, _keyword));
        return this;
    }

    public ISearchBuilder InDescription()
    {
        _filters.Add(CreateFilterExpression<Product>(_parameter, p => p.Description ?? "", _keyword));
        return this;
    }

    public IEnumerable<Product> SearchProducts() =>
        _filters.Count == 0 ? _products : _products.Where(CombineExpressions(_filters.ToArray()).Compile());

    private static Expression<Func<T, bool>> CombineExpressions<T>(params Expression<Func<T, bool>>[] filters)
    {
        var parameter = Expression.Parameter(typeof(T), "p");
        Expression? body = null;

        foreach (var filter in filters)
            if (body == null)
                body = Expression.Invoke(filter, parameter);
            else
                body = Expression.OrElse(body, Expression.Invoke(filter, parameter));

        return Expression.Lambda<Func<T, bool>>(body!, parameter);
    }

    private static Expression<Func<T, bool>> CreateFilterExpression<T>(ParameterExpression parameter,
        Expression<Func<T, string>> propertySelector, string keyword)
    {
        var methodInfo =
            typeof(SearchService).GetMethod(nameof(ContainsKeyword), BindingFlags.NonPublic | BindingFlags.Static);

        var expression = Expression.Invoke(propertySelector, parameter);
        return Expression.Lambda<Func<T, bool>>(
            Expression.Call(methodInfo!, expression, Expression.Constant(keyword)), parameter);
    }

    private static bool ContainsKeyword(string data, string keyword) =>
        NormalizeData(data).Contains(NormalizeData(keyword));

    private static string NormalizeData(string data) =>
        string.Concat(data.ToLower()
            .Where(c => !char.IsWhiteSpace(c)));
}