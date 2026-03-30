using AutoMapper;
using DoorBell.Application.DTOs.DeviceDTOs;
using DoorBell.Application.Interfaces;
using DoorBell.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.DeviceUsecase
{
    public class CreateUsecase
    {
        IDevice _entity;
        IMapper _mapper;

        public CreateUsecase(IDevice entity, IMapper mapper)
        {
            _entity = entity;
            _mapper = mapper;
        }

        public async Task<GetDTO> Execute(CreateDTO createDTO)
        {
            var existingDevices = await _entity.GetByApiKey(createDTO.ApiKey);

            Device entity;


            if (existingDevices != null && existingDevices.Any())
            {
                // 2. Nếu đã tồn tại, lấy device đầu tiên và update
                entity = existingDevices.First();

                // Map dữ liệu mới vào entity cũ
                _mapper.Map(createDTO, entity);
                entity.UpdatedAt = DateTime.UtcNow;

                var updatedEntity = await _entity.Update(entity);
                return _mapper.Map<GetDTO>(updatedEntity);
            }
            else
            {
                // 3. Nếu chưa tồn tại, tạo mới
                entity = _mapper.Map<Device>(createDTO);
                entity.CreatedAt = DateTime.UtcNow;
                entity.UpdatedAt = DateTime.UtcNow;

                var createdEntity = await _entity.Create(entity);
                return _mapper.Map<GetDTO>(createdEntity);
            }
        }
    }
}
