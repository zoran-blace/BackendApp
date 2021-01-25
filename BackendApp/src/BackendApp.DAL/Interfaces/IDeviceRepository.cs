using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Entities;
using BackendApp.Models;

namespace BackendApp.Interfaces
{
    interface IDeviceRepository
    {
        DeviceEntity GetDevice(int id);
        List<DeviceEntity> GetAllDevices();
        void AddDevice(DeviceEntity deviceEntity);
        void AddDevicePropertyValues(DeviceEntity deviceEntity);
        void EditDevice(DeviceEntity deviceEntity);
        void DeleteDevice(int id);
    }
}
