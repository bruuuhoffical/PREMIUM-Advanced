using System;
using Postgrest.Attributes;
using Postgrest.Models;

namespace PREMIUM_6._0.Models
{
    [Table("licensekey")]
    public class LicenseKey : BaseModel
    {
        [PrimaryKey("license_key", false)]
        public string licenseKey { get; set; }
        public int MaxDevices { get; set; }
        public int UsedDevices { get; set; }
        public string DeviceList { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
