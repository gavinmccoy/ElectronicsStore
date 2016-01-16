﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Entities
{
    // Cart class
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        // add item to cart
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID)
                                          .FirstOrDefault();
            if (line == null) 
            {
                lineCollection.Add(new CartLine { Product = product, 
                                                  Quantity = quantity });
            } 
            
            else 
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product) 
        { 
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }


        public decimal CalculateTotalValue() 
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        
        // clear cart function
        public void Clear() 
        {
            lineCollection.Clear();
        }
        
        public IEnumerable<CartLine> Lines 
        {
            get { return lineCollection; }
        }
    }

    public class CartLine 
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}