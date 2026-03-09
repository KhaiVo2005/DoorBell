using AutoMapper;
using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.DoorBellEventUsecase
{
    public class DeleteUsecase
    {
        IDoorBellEvent _entity;
        IMapper _mapper;

        public DeleteUsecase(IDoorBellEvent entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<bool> Execute(Guid id)
        {
            var status = await _entity.Delete(id);
            return status;
        }
    }
}
