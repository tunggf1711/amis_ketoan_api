using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Enums
{
    /// <summary>
    /// Các Mã Lỗi
    /// </summary>
    public enum ErrorCode
    {
        #region Field
        /// <summary>
        /// Mã lỗi khi gặp exception
        /// </summary>
        ErrorCode_Exception = 1,

        /// <summary>
        /// Mã lỗi khi không tìm thấy
        /// </summary>
        ErrorCode_NotFound = 2,

        /// <summary>
        /// Mã lỗi khi validate dữ liệu đầu vào
        /// </summary>
        ErrorCode_Validate = 3,
        #endregion
    }
}
