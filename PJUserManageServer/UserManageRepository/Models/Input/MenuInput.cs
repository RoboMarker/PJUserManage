using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManageRepository.Models.Input
{
    public class MenuInput: BaseInput
    {
        public string? MenuName { get; set; }
        public int? PermissionsId { get; set; }

    }
}
