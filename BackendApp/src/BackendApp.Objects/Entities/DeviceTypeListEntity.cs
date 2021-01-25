using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApp.Entities
{
    public class DeviceTypeListEntity
    {
        public DeviceType DeviceType { get; set; }
        public List<DeviceTypeListEntity>? SubTypes { get; set; }
    }
}
