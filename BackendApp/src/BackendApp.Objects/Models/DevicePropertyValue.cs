using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApp.Models
{
    public class DevicePropertyValue
    {
        [Key, Required]
        public int Id { get; set; }
        public string Value { get; set; }

        public int? DeviceTypePropertyId { get; set; }
        [ForeignKey("DeviceTypePropertyId")]
        public virtual DeviceTypeProperty DeviceTypeProperty { get; set; }

        public int? DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }
    }
}
