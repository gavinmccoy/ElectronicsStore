using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore.Domain.Entities;

namespace ElectronicsStore.Domain.Abstract
{
    // Interface for emailing orders (the cart contents and shipping details) to the administrator
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
