using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Interfaces
{
    public interface IDoorBellEvent
    {
        Task<List<DoorBellEvent>> GetAll();
        Task<List<DoorBellEvent>> GetByUser(Guid userId);
        Task<DoorBellEvent> GetById(Guid id);
        Task<DoorBellEvent> Create(DoorBellEvent doorBellEvent);
        Task<DoorBellEvent> Update(DoorBellEvent doorBellEvent);
        Task<bool> Delete(Guid id);
    }
}
