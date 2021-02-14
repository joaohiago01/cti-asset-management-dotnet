using System.ComponentModel.DataAnnotations.Schema;
using CTI.Asset.Management.Domain.Entities;

namespace CTI.Asset.Management.Infrastructure.Repositories.Models
{
    [Table("software_license", Schema = "management")]
    public class SoftwareLicenseModel
    {
        [Column]
        public string Id { get; set; }
        [Column]
        public string ActivationKey { get; set; }

        private SoftwareLicenseModel()
        {
            
        }

        public static SoftwareLicenseModel ToModel(SoftwareLicense softwareLicense)
        {
            return new SoftwareLicenseModel
            {
                Id = softwareLicense.SoftwareLicenseId.Id.ToString(),
                ActivationKey = softwareLicense.SoftwareLicenseActivationKey.ActivationKey
            };
        }
    }
}