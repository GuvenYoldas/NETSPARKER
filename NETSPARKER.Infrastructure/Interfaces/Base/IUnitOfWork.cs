using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETSPARKER.Infrastructure.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}
