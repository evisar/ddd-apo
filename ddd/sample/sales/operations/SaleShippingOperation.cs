using ddd.common;
using ddd.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.sales.operations
{
    public class SaleShippingOperation: ISaleShippingOperation
    {
        public Sale Entity { get; private set; } 
        readonly IShippingService _shippingService;
        public SaleShippingOperation(Sale entity, IShippingService shippingService)
        {
            Entity = entity;
            _shippingService = shippingService;
        }

        public decimal CalculateShipping()
        {
            return _shippingService.CalculateShipping(Entity.Weight, Entity.Size);
        }

        public void Dispose()
        {
            
        }
    }
}
