using System;
using System.Collections.Generic;

namespace UserManageRepository.DataModels.Data
{
    public partial class MenuPermission
    {
        public int MenuPermissionsId { get; set; }
        public string? MenuPermissionsName { get; set; }
        public int? MenuId { get; set; }
        public int? PermissionsId { get; set; }

        public virtual Menu? Menu { get; set; }
    }
}
