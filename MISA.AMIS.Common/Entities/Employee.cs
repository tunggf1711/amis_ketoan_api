using MISA.AMIS.Common.Enums;
using MISA.AMIS.Common.Resources;
using System.ComponentModel.DataAnnotations;
using MISA.AMIS.Common.Atrribute;

namespace MISA.AMIS.Common.Entities
{

    /// <summary>
    /// Model nhân viên
    /// </summary>
    public class Employee
    {
        #region Field

        /// <summary>
        /// ID Nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã Nhân viên
        /// </summary>
        [Required(ErrorMessage = "Mã nhân viên không được để trống")]
        [ValidateCode("Mã nhân viên phải bắt đầu bằng NV và kết thúc bằng các số")]
        [ValidateDuplicate("Mã nhân viên {0} đã tồn tại trong hệ thống")]
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính của nhân viên
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Số Chứng minh nhân dân
        /// </summary>
        public string? IdentityNumber { get; set; }


        /// <summary>
        /// ID Phòng ban của nhân viên
        /// </summary>
        [Required(ErrorMessage = "ID phòng ban không được để trống")]
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Ngày cấp chứng minh nhân dân
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nới cấp chứng minh nhân dân
        /// </summary>
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Vị trí làm việc của nhân viên
        /// </summary>
        public string? PostionName { get; set; }

        /// <summary>
        /// Địa chỉ của nhân viên
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động của nhân viên
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại bàn của nhân viên
        /// </summary>
        public string? TelephoneNumber { get; set; }

        /// <summary>
        /// Email của nhân viên
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh ngấn hàng
        /// </summary>
        public string? BankBranchName { get; set; }

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

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        #endregion
    }
}
