using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore.Domain.Entities;

namespace ElectronicsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        // gets a list of Products
        IEnumerable<Product> Products { get; }
    }
}
