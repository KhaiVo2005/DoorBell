using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorBell.Application.Interfaces
{
    public interface IDetectPersonService
    {
        bool HasPerson(byte[] imageBytes);
    }
}
