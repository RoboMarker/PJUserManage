
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManageRepository.Models.Data
{

    [MetadataType(typeof(MenuMetadata))]
    public partial class Menu
    {
        [NotMapped]
        public eStatus? StatusEnum
        {
            get
            {
                return (eStatus?)Status;
            }
            set
            {
                StatusEnum = value;
            }
        }
        [NotMapped]
        public eMenuType? MenuTypeEnum
        {
            get
            {
                return (eMenuType?)Status;
            }
            set
            {
                MenuTypeEnum = value;
            }
        }

    }
    public enum eStatus
    {
        active = 1,
        close = 0
    }

    public enum eMenuType
    {
        generally = 1,//一般
        manage = 0//管理類
    }

    public class MenuMetadata
    {
        // [Required(ErrorMessage = "Name is required.")]
        // [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string? MenuName { get; set; }

    }
}
