using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApp.Models
{
    public class DeviceType
    {
        [Key, Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual List<DeviceType> DeviceTypes { get; set; }

        public List<Device> Devices { get; set; }
        public List<DeviceTypeProperty> DeviceTypeProperties { get; set; }
    }
}
