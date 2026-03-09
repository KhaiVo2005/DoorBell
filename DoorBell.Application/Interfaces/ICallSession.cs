using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Interfaces
{
    public interface ICallSession
    {
        Task<List<CallSession>> GetAll();
        Task<CallSession> GetById(Guid id);
        Task<CallSession> Create(CallSession callSession);
        Task<CallSession> Update(CallSession callSession);
        Task<bool> Delete(Guid id);
    }
}
