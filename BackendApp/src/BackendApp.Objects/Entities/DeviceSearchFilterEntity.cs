using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Objects.Entities
{
    public class DeviceSearchFilterEntity
    {
        public string? DeviceName { get; set; }
        public string? DeviceTypeName { get; set; }
        public int? PageNumber { get; set; }
        public int? RecordsPerPage { get; set; }
        public string PropertyValue { get; set; }
    }
}
