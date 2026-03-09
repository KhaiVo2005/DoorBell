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
    public class GetByMailUsecase
    {
        IUser _user;
        IMapper _mapper;

        public GetByMailUsecase(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(string mail)
        {
            var user = await _user.GetByEmail(mail);
            return _mapper.Map<GetDTO>(user);
        }
    }
}
