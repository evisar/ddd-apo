using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.countries.services
{
    public class CountryRepository: ICountryRepository
    {
        static List<Country> _customers = new List<Country>();
        public void Save(Country entity)
        {
            _customers.Add(entity);
        }

        public void Delete(Country entity)
        {
            _customers.Remove(entity);
        }

        public IQueryable<Country> Query()
        {
            return _customers.AsQueryable();
        }
    }
}
