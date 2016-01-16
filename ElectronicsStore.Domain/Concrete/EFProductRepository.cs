using ElectronicsStore.Domain.Abstract;
using ElectronicsStore.Domain.Entities;
using ElectronicsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Concrete
{
    // services request for the IProductRepository interface
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
