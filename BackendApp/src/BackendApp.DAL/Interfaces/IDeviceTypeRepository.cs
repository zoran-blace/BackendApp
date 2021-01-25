using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Entities;
using BackendApp.Models;

namespace BackendApp.Interfaces
{
    interface IDeviceTypeRepository
    {
        DeviceTypeEntity GetDeviceType(int id);
        List<DeviceTypeListEntity> GetAllDeviceTypes();
        void AddDeviceType(DeviceTypeEntity deviceTypeEntity);
        void AddDeviceTypeProperties(DeviceTypeEntity deviceTypeEntity);
        void EditDeviceType(DeviceTypeEntity deviceTypeEntity);
        bool DeleteDeviceType(int id);
    }
}
