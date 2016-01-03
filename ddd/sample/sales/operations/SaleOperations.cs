using ddd.common;
using ddd.sample.customers.services;
using ddd.sample.rules;
using ddd.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.sales.operations
{
    public class SaleOperations: ISaleOperations
    {
        public Sale Entity { get; private set; }
        readonly ITaxService _taxService;
        readonly TaxRule _taxRule;
        readonly IEventService _bus;
        readonly ICustomerService _customerService;
        IList<IDisposable> _subscriptions = new List<IDisposable>(); 
        public SaleOperations(Sale entity, ITaxService taxService, TaxRule taxRule, IEventService bus, ICustomerService customerService)
        {
            Entity = entity;
            _taxService = taxService;
            _taxRule = taxRule;
            _bus = bus;
            _customerService = customerService;

            var subscription = _bus.Subscribe<TaxCalculatedEvent>(OnTaxCalculate);
            _subscriptions.Add(subscription);
        }

        private void OnTaxCalculate(TaxCalculatedEvent e)
        {
            
        }

        public bool Calculate()
        {
            try
            {
                if (Entity.Calculated) return false;

                var customer = _customerService.FindById(Entity.CustomerId);

                switch(_taxRule.GetTaxRule(customer.CountryId))
                {
                    case TaxRuleType.Calculated:
                        _taxService.Calculate(Entity, true);
                        break;
                    case TaxRuleType.NotCalculated:
                        _taxService.Calculate(Entity, false);
                        break;
                }
                Entity.Calculated = true;
                
                return true;
            }catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            foreach(var subs in _subscriptions)
            {
                subs.Dispose();
            }
        }
    }
}
