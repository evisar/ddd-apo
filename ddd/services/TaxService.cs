using ddd.common;
using ddd.sample.sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.services
{
    public class TaxCalculatedEvent: IEvent
    {
        public Sale Sale { get; private set; }
        public TaxCalculatedEvent(Sale sale)
        {
            this.Sale = sale;
        }

    }
    public class TaxService: ITaxService
    {
        readonly IEventService _bus;
        public TaxService(IEventService bus)
        {
            _bus = bus;
        }
        public void Calculate(Sale sale, bool inprice)
        {
            _bus.Publish<TaxCalculatedEvent>(new TaxCalculatedEvent(sale));
        }
    }
}
