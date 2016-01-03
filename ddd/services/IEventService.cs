using ddd.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.services
{
    public interface IEventService: IService
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
        IDisposable Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent;
    }
}
