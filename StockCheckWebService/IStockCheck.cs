using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace StockCheckWebService
{
    [ServiceContract(Namespace = "StockCheckWebService")]
    public interface IStockCheck
    {
        [OperationContract]
        String CheckStock(String Category);

        [OperationContract]
        String CheckStock();
    }
}
