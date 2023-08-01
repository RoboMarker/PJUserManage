using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManageRepository.DataModels.Data;

namespace UserManageRepository.Models.ViewModels
{
    public class PermissionVM : Permission
    {
        public string StatusName
        {
            get
            {
                return (Status == eStatus.active) ? "啟用" : "停用";
            }
        }

    }
}