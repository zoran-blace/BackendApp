using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Models;

namespace BackendApp.Entities
{
    public class DevicePropertyValueEntity
    {
        public int? DeviceId { get; set; }
        public int? DeviceTypePropertyId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
