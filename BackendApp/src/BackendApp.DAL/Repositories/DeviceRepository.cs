using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Context;
using BackendApp.Entities;
using BackendApp.Interfaces;
using BackendApp.Models;
using BackendApp.Objects.Entities;

namespace BackendApp.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        public DeviceEntity GetDevice(int id)
        {
            // get Device
            var entity = new DeviceEntity();
            var device = _context.Devices.Where(x => x.Id == id).FirstOrDefault();
            entity.Id = id;
            entity.Name = device.Name;
            entity.DevicePropertyValuesEntities = new List<DevicePropertyValueEntity>();

            // get all Device property values
            var devicePropertyValues = _context.DevicePropertyValues.Where(x => x.DeviceId == device.Id).ToList();
            foreach (var devicePropertyValue in devicePropertyValues)
            {
                var devicePropertiesValueEntity = new DevicePropertyValueEntity();
                devicePropertiesValueEntity.Name = _context.DeviceTypeProperties
                                                        .Where(x => x.Id == devicePropertyValue.DeviceTypePropertyId)
                                                        .Select(x => x.Name)
                                                        .ToList()[0];
                devicePropertiesValueEntity.Value = devicePropertyValue.Value;

                entity.DevicePropertyValuesEntities.Add(devicePropertiesValueEntity);
            }

            return entity;
        }

        public List<DeviceEntity> GetAllDevices()
        {
            var deviceEntities = new List<DeviceEntity>();
            var deviceIds = _context.Devices.Select(x => x.Id).ToList();

            foreach (var deviceId in deviceIds)
            {
                deviceEntities.Add(GetDevice(deviceId));
            }

            return deviceEntities;
        }

        public List<DeviceEntity> FindDevicesByFilter(DeviceSearchFilterEntity searchFilter)
        {
            // TO BE DONE
            return null;
        }

        public void AddDevice(DeviceEntity deviceEntity)
        {
            // add new Device
            var device = new Device
            {
                Name = deviceEntity.Name,
                DeviceTypeId = deviceEntity.DeviceTypeId
            };
            _context.Devices.Add(device);
        }

        public void AddDevicePropertyValues(DeviceEntity deviceEntity)
        {
            if (deviceEntity.DevicePropertyValuesEntities != null && deviceEntity.DevicePropertyValuesEntities.Count() > 0)
            {
                var newId = _context.Devices.Max(x => x.Id);

                // add Device property Values
                foreach (var devicePropertyEntity in deviceEntity.DevicePropertyValuesEntities)
                {
                    var newDevicePropertyValue = new DevicePropertyValue
                    {
                        DeviceId = newId,
                        Value = devicePropertyEntity.Value
                    };
                    _context.DevicePropertyValues.Add(newDevicePropertyValue);
                }
            }
        }

        public void EditDevice(DeviceEntity deviceEntity)
        {
            var device = _context.Devices.Where(x => x.Id == deviceEntity.Id).SingleOrDefault();

            // change in Device name
            device.Name = deviceEntity.Name;
            // Device type change
            device.DeviceTypeId = deviceEntity.DeviceTypeId;

            // check for changes in Device property Values
            var devicePropertyValues = _context.DevicePropertyValues.Where(x => x.DeviceId == deviceEntity.Id).ToList();
            if (deviceEntity.DevicePropertyValuesEntities != null && deviceEntity.DevicePropertyValuesEntities.Count() > 0)
            {
                foreach (var devicePropertyValueEntity in deviceEntity.DevicePropertyValuesEntities)
                {
                    var devicePropertyValue = devicePropertyValues.Where(x => x.Id == deviceEntity.Id).SingleOrDefault();
                    devicePropertyValue.Value = devicePropertyValue.Value;
                }
            }

            _context.Devices.Update(device);
        }

        public void DeleteDevice(int id)
        {
            // delete all Device property Values
            var devicePropertyValues = _context.DevicePropertyValues.Where(x => x.DeviceId == id).ToList();
            _context.DevicePropertyValues.RemoveRange(devicePropertyValues);

            // delete Device
            var device = _context.Devices.SingleOrDefault(x => x.Id == id);
            _context.Devices.Remove(device);
        }
    }
}
