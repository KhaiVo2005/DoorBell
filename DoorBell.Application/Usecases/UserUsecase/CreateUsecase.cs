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
    public class CreateUsecase
    {
        IUser _user;
        IMapper _mapper;

        public CreateUsecase(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(CreateDTO createDTO)
        {
            var userEntity = _mapper.Map<Domain.Entities.User>(createDTO);
            var createdUser = await _user.Create(userEntity);
            return _mapper.Map<GetDTO>(createdUser);
        }
    }
}
