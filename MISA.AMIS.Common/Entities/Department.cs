using MISA.AMIS.Common.Atrribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Model phòng ban
    /// </summary>
    public class Department
    {
        #region Field

        /// <summary>
        /// ID phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>

        [Required(ErrorMessage = "Mã phòng ban không được để trống")]
        [ValidateCode("Mã phòng ban phải bắt đầu bằng PB và kết thúc bằng các số")]
        [ValidateDuplicate("Mã phòng ban {0} đã tồn tại trong hệ thống")]
        public string? DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>

        [Required(ErrorMessage = "Tên phòng ban không được để trống")]
        public string? DepartmentName { get; set; }


        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Thời gian chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; }
        #endregion
    }
}
