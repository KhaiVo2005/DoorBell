using AutoMapper;
using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.UserUsecase
{
    public class DeleteUsecase
    {
        IUser _user;
        IMapper _mapper;

        public DeleteUsecase(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<bool> Execute(Guid id)
        {
            var status = await _user.Delete(id);
            return status;
        }
    }
}
