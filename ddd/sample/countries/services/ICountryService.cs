using ddd.common;
using ddd.integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.countries.services
{
    public interface ICountryService : IIntegrationService<Country>
    {
        Country FindById(Guid id);

        rules.TaxRuleType GetTaxRule(Guid countryId);
    }
}
