using AutoMapper;
using DoorBell.Application.DTOs.UserDTOs;
using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.UserUsecase
{
    public class GetUsecase
    {
        IUser _user;
        IMapper _mapper;

        public GetUsecase(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(Guid id)
        {
            var user = await _user.GetById(id);
            return _mapper.Map<GetDTO>(user);
        }
    }
}
