using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.NationalCatalog.Models;

namespace AllMark.Services.Interfaces
{
    public interface INationalCatalogService
    {
        /// <summary>
        /// Возвращает список атрибутов как публичных так и приватных для запрашивающего аккаунта.
        /// </summary>
        /// <param name="categoryId">(необязательный, обязателен если указан attr_type) идентификатор категории, к которой относятся атрибуты. Если не указан, возвращается полный список атрибутов доступных для запрашивающего аккаунта.</param>
        /// <param name="attributeType">(необязательный) возможные значения параметра
        /// a — (используется по-умолчанию) вернуть все атрибуты
        /// m — вернуть только обязательные атрибуты
        /// r — вернуть только рекомендуемые атрибуты
        /// o — вернуть только опциональные атрибуты
        /// </param>
        /// <returns></returns>
        Task<IEnumerable<CatalogAttribute>> GetAttributes(int? categoryId, string attributeType = null);

        /// <summary>
        /// Используется для получения списка торговых марок
        /// </summary>
        /// <param name="partyId">идентификатор торговой сети (необязательный)</param>
        /// <returns></returns>
        Task<IEnumerable<CatalogBrand>> GetBrands(int? partyId = null);

        /// <summary>
        /// Метод возвращает краткую или полную информацию о продукте (товаре). Требует обязательного указания одного из следующих параметров: идентификатор товара, GTIN (штрих-код), LTIN или SKU с указанием идентификатора торговой сети, который относится к запрашиваемому аккаунту.
        /// </summary>
        /// <param name="goodId">при указании, возвращается товар с соответствующим идентификатором или ошибка 404. При этом GTIN, LTIN и SKU игнорируются.</param>
        /// <param name="gtin">при указании, возвращается товар с соответствующим GTIN или ошибка 404. При этом LTIN и SKU игнорируются.</param>
        /// <param name="ltin">при указании, возвращается товар с соответствующим LTIN или ошибка 404. При этом SKU игнорируется.</param>
        /// <param name="sku">при указании, возвращается товар с соответствующим SKU или ошибка 404.</param>
        /// <param name="product_name">название продукта (необязательный; используется при запросе на поиск отсутствующего товара)</param>
        /// <param name="catId">идентификатор категории (необязательный; используется при запросе на поиск отсутствующего товара)</param>
        /// <returns></returns>
        Task<List<CatalogProduct>> GetProducts(int? goodId = null, long? gtin = null, int? ltin = null, int? sku = null, string product_name = null, int? catId = null);

        /// <summary>
        /// Используется для получения дерева категорий, корень дерева не возвращается.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CatalogCategory>> GetCategories();

        /// <summary>
        /// Метод возвращает краткую или полную информацию о продукте (товаре). Требует обязательного указания одного из следующих параметров: 
        /// идентификатор товара, GTIN (штрих-код), LTIN или SKU с указанием идентификатора торговой сети, который относится к запрашиваемому аккаунту.
        /// </summary>
        /// <param name="goodId">при указании, возвращается товар с соответствующим идентификатором или ошибка 404.При этом GTIN, LTIN и SKU игнорируются.</param>
        /// <param name="gtin">при указании, возвращается товар с соответствующим GTIN или ошибка 404.При этом LTIN и SKU игнорируются.</param>
        /// <param name="ltin">при указании, возвращается товар с соответствующим LTIN или ошибка 404.При этом SKU игнорируется.</param>
        /// <param name="sku">при указании, возвращается товар с соответствующим SKU или ошибка 404.</param>
        /// <param name="productName">название продукта(необязательный; используется при запросе на поиск отсутствующего товара)</param>
        /// <param name="categoryId">идентификатор категории(необязательный; используется при запросе на поиск отсутствующего товара)</param>
        /// <returns></returns>
        Task<IEnumerable<CatalogShortProduct>> GetShortProduct(int? goodId = null, long? gtin = null, long? ltin = null, long? sku = null, string productName = null, int? categoryId = null);

        /// <summary>
        /// Метод возвращает XML товаров для подписи по goodId или GTIN
        /// </summary>
        /// <param name="goodIds">массив ID товаров</param>
        /// <param name="gtins">массив строк GTIN</param>
        /// <returns></returns>
        Task<NationalCatalogXmlResponse> FeedProductDocument(IEnumerable<int> goodIds, IEnumerable<string> gtins);

        /// <summary>
        /// Метод принимает массив объектов, в объектах содержатся ID товара и подписанный XML для этого товара, количество принимаемых данных ограничено 25
        /// </summary>
        /// <param name="xmlResult"></param>
        /// <returns></returns>
        Task<NationalCatalogSignResponse> FeedProductSign(IEnumerable<NationalCatalogXmlResult> xmlResult);
    }
}
