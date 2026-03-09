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
    public class CallSessionRespository: ICallSession
    {
        private DoorBellDbContext _context;
        public CallSessionRespository(DoorBellDbContext context)
        {
            _context = context;
        }

        public async Task<CallSession> Create(CallSession callSession)
        {
            await _context.CallSessions.AddAsync(callSession);
            await _context.SaveChangesAsync();
            return callSession;
        }

        public async Task<bool> Delete(Guid id)
        {
            var callSession = await _context.CallSessions.FindAsync(id);
            if (callSession == null)
                return false;
            _context.CallSessions.Remove(callSession);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<CallSession>> GetAll()
        {
            return await _context.CallSessions.ToListAsync();
        }

        public async Task<CallSession> GetById(Guid id)
        {
            return await _context.CallSessions.FindAsync(id);
        }

        public async Task<CallSession> Update(CallSession callSession)
        {
            _context.CallSessions.Update(callSession);
            await _context.SaveChangesAsync();
            return callSession;
        }
    }
}
