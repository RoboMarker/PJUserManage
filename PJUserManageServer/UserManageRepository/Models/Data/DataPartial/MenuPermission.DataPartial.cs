using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManageRepository.Models.Data
{

    [MetadataType(typeof(MenuPermissionMetadata))]
    public partial class MenuPermission
    {
        [NotMapped]
        public string? MenuPermissionsTypeEnum { get; set; }
    }
    public enum eMenuPermissionsType {
        Permissions=1,
        User=2
    }

    public  class MenuPermissionMetadata
    {
        //[Required(ErrorMessage = "This field is required.")]
    }
}
