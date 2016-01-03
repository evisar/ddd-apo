using ddd.common;
using ddd.integration;
using ddd.sample.countries.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ddd.sample.rules
{
    public enum TaxRuleType
    {
        Calculated,
        NotCalculated
    }
    public class TaxRule: IRule
    {

        readonly ICountryService _countryService;
        public TaxRule(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public TaxRuleType GetTaxRule(Guid countryId)
        {
            return _countryService.GetTaxRule(countryId);
        }
    }
}
