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
    public class UpdateUsecase
    {
        IUser _user;
        IMapper _mapper;

        public UpdateUsecase(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(Guid id, UpdateDTO entityDTO)
        {
            var user = await _user.GetById(id);
            if (user == null)
                throw new Exception("User not found");
            _mapper.Map(entityDTO, user);
            var entityUpdate = await _user.Update(user);
            return _mapper.Map<GetDTO>(entityUpdate);
        }
    }
}
