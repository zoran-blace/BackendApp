using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApp.Entities
{
    public class DeviceEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int DeviceTypeId { get; set; }
        public List<DevicePropertyValueEntity> DevicePropertyValuesEntities { get; set; }
    }
}
