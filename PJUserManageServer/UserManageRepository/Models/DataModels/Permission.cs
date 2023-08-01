using System;
using System.Collections.Generic;

namespace UserManageRepository.DataModels.Data
{
    public partial class Permission
    {
        public int PermissionsId { get; set; }
        public string? PermissionsName { get; set; }
        public byte? Status { get; set; }
    }
}
