using ddd.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.countries.services
{
    public interface ICountryRepository: IRepositoryService<Country>
    {
        
    }
}
