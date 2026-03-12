using DoorBell.Application.Interfaces;
using DoorBell.Domain.Entities;
using DoorBell.Infrastructure.Persistent;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Infrastructure.Respositories
{
    public class DeviceRespository : IDevice
    {
        private DoorBellDbContext _context;
        public DeviceRespository(DoorBellDbContext context)
        {
            _context = context;
        }
        public async Task<Device> Create(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<List<Device>> GetAllByUser(Guid userId)
        {
            return await _context.Devices.Where(d => d.UserId == userId).ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
                return false;
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Device>> GetAll()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device> GetById(Guid id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task<Device> Update(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
            return device;
        }
    }
}
