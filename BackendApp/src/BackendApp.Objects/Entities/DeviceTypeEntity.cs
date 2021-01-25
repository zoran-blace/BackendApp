using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Models;
using BackendApp.Objects.Entities;

namespace BackendApp.Entities
{
    public class DeviceTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DeviceTypePropertyEntity>? DeviceTypePropertyEntities { get; set; }
        public int? ParentId { get; set; }
    }
}   
