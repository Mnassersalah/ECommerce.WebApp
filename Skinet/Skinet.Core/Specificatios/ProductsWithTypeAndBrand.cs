using Skinet.Core.Entities;

namespace Skinet.Core.Specificatios
{
    public class ProductsWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandSpecification()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        public ProductsWithTypeAndBrandSpecification(int id) : this()
        {
            Criteria = p => p.Id == id;
        }
    }
}
