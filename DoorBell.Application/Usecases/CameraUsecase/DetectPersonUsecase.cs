using DoorBell.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Usecases.CameraUsecase
{
    public class DetectPersonUsecase
    {
        private readonly IDetectPersonService _detectService;

        public DetectPersonUsecase(IDetectPersonService detectService)
        {
            _detectService = detectService;
        }

        public bool Execute(byte[] imageBytes)
        {
            return _detectService.HasPerson(imageBytes);
        }
    }
}
