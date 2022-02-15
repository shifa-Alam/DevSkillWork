using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
