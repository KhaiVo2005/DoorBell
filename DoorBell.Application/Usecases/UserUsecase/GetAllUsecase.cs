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
    public class GetAllUsecase
    {
        IUser _user;
        IMapper _mapper;

        public GetAllUsecase(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<List<GetDTO>> Execute()
        {
            var users = await _user.GetAll();
            return _mapper.Map<List<GetDTO>>(users);
        }
    }
}