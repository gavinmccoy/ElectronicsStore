using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ElectronicsStore.Domain.Concrete;
using ElectronicsStore.Domain.Entities;
namespace ProductListService
{
    [ServiceContract]
    public interface IProductListService
    {
        [OperationContract]
        List<Product> GetProductsFromCategory(string category);
    }
}
