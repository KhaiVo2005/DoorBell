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
    public class DoorBellEventRepository : IDoorBellEvent
    {
        private DoorBellDbContext _context;
        public DoorBellEventRepository(DoorBellDbContext context)
        {
            _context = context;
        }

        public async Task<List<DoorBellEvent>> GetByUser(Guid userId)
        {
            return await _context.DoorBellEvents
                .Include(e => e.Device)
                .Where(e => e.Device.UserId == userId)
                .ToListAsync();
        }
        public async Task<DoorBellEvent> Create(DoorBellEvent doorBellEvent)
        {
            await _context.DoorBellEvents.AddAsync(doorBellEvent);
            await _context.SaveChangesAsync();
            return doorBellEvent;
        }

        public async Task<bool> Delete(Guid id)
        {
            var doorBellEvent = await _context.DoorBellEvents.FindAsync(id);
            if (doorBellEvent == null)
                return false;
            _context.DoorBellEvents.Remove(doorBellEvent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DoorBellEvent>> GetAll()
        {
            return await _context.DoorBellEvents.ToListAsync();
        }

        public async Task<DoorBellEvent> GetById(Guid id)
        {
            return await _context.DoorBellEvents.FindAsync(id);
        }

        public Task<DoorBellEvent> Update(DoorBellEvent doorBellEvent)
        {
            _context.DoorBellEvents.Update(doorBellEvent);
            _context.SaveChanges();
            return Task.FromResult(doorBellEvent);
        }
    }
}
