using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Interfaces
{
    public interface IDevice
    {
        Task<List<Device>> GetAll();
        Task<List<Device>> GetAllByUser(Guid userId);
        Task<Device> GetById(Guid id);
        Task<Device> Create(Device device);
        Task<Device> Update(Device device);
        Task<bool> Delete(Guid id);
    }
}
