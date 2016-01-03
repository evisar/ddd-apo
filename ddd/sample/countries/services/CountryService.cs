using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.countries.services
{
    public class CountryService: ICountryService
    {
        readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public Country FindById(Guid id)
        {
            return _countryRepository.Query().Where(c => c.Id == id).FirstOrDefault();
        }


        public rules.TaxRuleType GetTaxRule(Guid countryId)
        {
            var country = FindById(countryId);
            return country.Calculate ? rules.TaxRuleType.Calculated : rules.TaxRuleType.NotCalculated;
        }
    }
}
