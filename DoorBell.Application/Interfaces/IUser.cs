using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<bool> Delete(Guid id);
        Task<User> GetByEmail(string email);
    }
}
