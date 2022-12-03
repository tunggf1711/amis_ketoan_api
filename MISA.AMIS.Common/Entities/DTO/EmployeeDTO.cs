using MISA.AMIS.Common.Enums;

namespace MISA.AMIS.Common.Entities.DTO
{
    /// <summary>
    /// Rút gọn lại dữ liệu nhân viên trước khi trả về
    /// </summary>
    public class EmployeeDTO
    {
        #region Field

        /// <summary>
        /// ID Nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã Nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính của nhân viên
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Số Chứng minh nhân dân
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// ID Phòng ban của nhân viên
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Ngày cấp chứng minh nhân dân
        /// </summary>
        public DateTime IdentityDate { get; set; }

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

        #endregion
    }
}
