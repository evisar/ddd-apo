using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.countries.services
{
    public interface ICountryService
    {
        Country FindById(Guid id);

        rules.TaxRuleType GetTaxRule(Guid countryId);
    }
}
