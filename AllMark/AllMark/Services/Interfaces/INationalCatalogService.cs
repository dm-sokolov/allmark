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
    }
}
