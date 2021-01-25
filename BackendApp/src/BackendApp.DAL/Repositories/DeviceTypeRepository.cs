using Microsoft.EntityFrameworkCore;
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
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private AppDbContext _context;

        public DeviceTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public DeviceTypeEntity GetDeviceType(int id)
        {
            var item = new DeviceTypeEntity();
            var deviceType = _context.DeviceTypes.Where(x => x.Id == id).FirstOrDefault();
            item.Id = deviceType.Id;
            item.Name = deviceType.Name;
            item.DeviceTypePropertyEntities = new List<DeviceTypePropertyEntity>();

            // check if selected Device Type is sub type of other Device Type
            if (deviceType.ParentId == null)
            {
                item.DeviceTypePropertyEntities = GetDeviceTypePropertyEntities(deviceType.Id);
            }
            else
            {
                while (true) // get all Device Type Properties for all sub type Device Types
                {
                    item.DeviceTypePropertyEntities.AddRange(GetDeviceTypePropertyEntities(deviceType.Id));
                    deviceType = _context.DeviceTypes.Where(x => x.Id == deviceType.ParentId).FirstOrDefault();

                    if (deviceType == null)
                        break;
                }
            }

            return item;
        }

        public List<DeviceTypeListEntity> GetAllDeviceTypes()
        {
            // TO BE DONE 

            return null;
        }

        public void AddDeviceType(DeviceTypeEntity deviceTypeEntity)
        {
            // add new Device Type
            var deviceType = new DeviceType
            {
                Name = deviceTypeEntity.Name,
                ParentId = deviceTypeEntity.ParentId
            };
            _context.DeviceTypes.Add(deviceType);
        }

        public void AddDeviceTypeProperties(DeviceTypeEntity deviceTypeEntity)
        {
            if (deviceTypeEntity.DeviceTypePropertyEntities != null && deviceTypeEntity.DeviceTypePropertyEntities.Count() > 0)
            {
                var newId = _context.DeviceTypes.Max(x => x.Id);

                // add Device Type Properties depending on if Device Type is sub type or not
                foreach (var deviceTypePropertyEntity in deviceTypeEntity.DeviceTypePropertyEntities)
                {
                    if (deviceTypeEntity.ParentId == null)
                    {
                        var newDeviceTypeProperty = new DeviceTypeProperty
                        {
                            DeviceTypeId = newId,
                            Name = deviceTypePropertyEntity.Name
                        };
                        _context.DeviceTypeProperties.Add(newDeviceTypeProperty);
                    }
                    else
                    {
                        var deviceTypeProperty = _context.DeviceTypeProperties.Any(x => x.Name == deviceTypePropertyEntity.Name);
                        if (!deviceTypeProperty)
                        {
                            var newDeviceTypeProperty = new DeviceTypeProperty
                            {
                                DeviceTypeId = newId,
                                Name = deviceTypePropertyEntity.Name
                            };
                            _context.DeviceTypeProperties.Add(newDeviceTypeProperty);
                        }
                    }
                }
            }
        }

        public void EditDeviceType(DeviceTypeEntity deviceTypeEntity)
        {
            var deviceType = _context.DeviceTypes.Where(x => x.Id == deviceTypeEntity.Id).SingleOrDefault();

            // change in Device Type name
            deviceType.Name = deviceTypeEntity.Name;
            // parent change (type/sub type)
            deviceType.ParentId = deviceTypeEntity.ParentId;

            // check for changes in Device Type Properties names
            var deviceTypeProperties = _context.DeviceTypeProperties.Where(x => x.DeviceTypeId == deviceType.Id).ToList();
            if (deviceTypeEntity.DeviceTypePropertyEntities != null && deviceTypeEntity.DeviceTypePropertyEntities.Count() > 0)
            {
                foreach (var deviceTypePropertyEntity in deviceTypeEntity.DeviceTypePropertyEntities)
                {
                    var deviceTypeProperty = deviceTypeProperties.Where(x => x.Id == deviceTypePropertyEntity.Id).SingleOrDefault();
                    deviceTypeProperty.Name = deviceTypePropertyEntity.Name;
                }
            }

            _context.DeviceTypes.Update(deviceType);
        }

        public bool DeleteDeviceType(int id)
        {
            var devicesCount = _context.Devices.Count(x => x.DeviceTypeId == id);
            // check if Device Type has any attached Devices
            if (devicesCount == 0)
            {
                // deleting Device Type Properties and proprietary Device Property Values
                var deviceTypeProperties = _context.DeviceTypeProperties.Where(x => x.DeviceTypeId == id).ToList();
                foreach (var deviceTypeProperty in deviceTypeProperties)
                {
                    var devicePropertyValue = _context.DevicePropertyValues.Where(x => x.DeviceTypePropertyId == deviceTypeProperty.Id);
                    _context.DevicePropertyValues.RemoveRange(devicePropertyValue);
                }

                // removing ParentId's from all sub types
                var childDeviceTypes = _context.DeviceTypes.Where(x => x.ParentId == id && x.Id != id).ToList();
                foreach (var childDeviceType in childDeviceTypes)
                {
                    childDeviceType.ParentId = null;
                    _context.DeviceTypes.Update(childDeviceType);
                }

                // deleting Device Type
                var deviceType = _context.DeviceTypes.SingleOrDefault(x => x.Id == id);
                _context.DeviceTypes.Remove(deviceType);

                return true;
            }
            else
            {
                return false;
            }
        }

        private List<DeviceTypePropertyEntity> GetDeviceTypePropertyEntities(int id)
        {
            var deviceTypePropertyEntities = new List<DeviceTypePropertyEntity>();
            var deviceTypeProperties = _context.DeviceTypeProperties.Where(x => x.DeviceTypeId == id).ToList();

            foreach (var deviceTypeProperty in deviceTypeProperties)
            {
                var deviceTypePropertyEntity = new DeviceTypePropertyEntity
                {
                    Id = deviceTypeProperty.Id,
                    Name = deviceTypeProperty.Name
                };
                deviceTypePropertyEntities.Add(deviceTypePropertyEntity);
            }

            return deviceTypePropertyEntities;
        }
    }
}
