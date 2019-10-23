using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.NationalCatalog.Models;

namespace AllMark.Services.Interfaces
{
    public interface INationalCatalogService
    {
        Task<ICollection<CatalogAttribute>> GetAttributes(int? categoryId, string attributeType = null);

        Task<ICollection<CatalogBrand>> GetBrands(int? partyId = null);

        Task<ICollection<CatalogProduct>> GetProducts(int? goodId = null, long? gtin = null, int? ltin = null, int? sku = null, string product_name = null, int? catId = null);
    }
}
