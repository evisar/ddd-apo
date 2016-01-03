using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ddd.services;
using Ninject;
using Moq;
using System.Linq;
using ddd.common;
using Ninject.Parameters;
using System.Collections.Generic;
using Castle.DynamicProxy;
using ddd.sample.rules;
using ddd.integration;
using Ninject.Extensions.Conventions;
using ddd.extensions;
using ddd.sample.sales.operations;
using ddd.sample.sales;
using ddd.sample.customers;
using ddd.sample.countries;
using ddd.sample.customers.services;
using ddd.sample.countries.services;
using ddd.infrastructure;
using System.Threading;


namespace ddd.tests
{
    [TestClass]
    public class dddaop_tests
    {

        IKernel _kernel;
        ProxyGenerator _proxy;
        IEventService _bus;
        Sale _sale;
        Country _country;
        Customer _customer;

        [TestInitialize]
        public void init()
        {
            //arrange
            _proxy = new ProxyGenerator();
            _kernel = new StandardKernel();
            _bus = new EventService();

            _kernel.Bind<IEventService>().ToConstant(_bus);

            _kernel.Bind(x => x
                .FromAssembliesMatching("*")
                .SelectAllClasses()
                .Where( t=> t != typeof(EventService) )
                .BindDefaultInterface());

            //arrange
            _sale = new Sale();
            _country = new Country { Id = Guid.NewGuid(), Name = "Netherlands" };
            _customer = new Customer { Id = Guid.NewGuid(), Name = "Visar" };
            _customer.CountryId = _country.Id;
            _sale.CustomerId = _customer.Id;

            var countryRepo = _kernel.Get<ICountryRepository>();
            countryRepo.Save(_country);

            var custRepo = _kernel.Get<ICustomerRepository>();
            custRepo.Save(_customer);

            _kernel.Bind<Sale>().ToMethod<Sale>(x => _sale).InTransientScope();      
        }


        [TestMethod]
        public void Test_If_SaleOperation_TaxCalculatedEventIsFired()
        {
            //arrange                  
            var taxCaluclatedEventFired = false;
            _bus.Subscribe<TaxCalculatedEvent>(t =>
                {
                    if(_sale == t.Sale)
                    {
                        taxCaluclatedEventFired = true;
                    }
                });


            //act
            var op = _kernel.Get<ISaleOperations>();
            op.Calculate();


            //assert
            Assert.IsTrue(_sale.Calculated);
            Assert.IsTrue(taxCaluclatedEventFired);
        }

        [TestMethod]
        public void Test_IfInfrastructure_IsLoading()
        {
            //arrange
            var op = _kernel.Get<ISaleOperations>();
            var logger = _kernel.Get<ILogger>();
            var logged = false;
            var logging = new MethodInterceptor<ILogger>(logger, (x, i) => 
                {
                    x.Log(i.Proxy, i.Method.Name, i.Arguments);
                    logged = true;
                });
            var auth = _kernel.Get<IAuthentication>();
            var authenticated = false;
            var authentication = new MethodInterceptor<IAuthentication>(auth, (x, i) =>
            {
                x.Authenticate(Thread.CurrentPrincipal, i.Proxy, i.Method.Name, i.Arguments);
                authenticated = true;
            });
            var proxiedOp = _proxy.CreateInterfaceProxyWithTarget<ISaleOperations>(op, logging, authentication);

            //act
            proxiedOp.Calculate();

            //assert
            Assert.IsTrue(logged);
            Assert.IsTrue(authenticated);
        }


    }
}
