using MISA.AMIS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Entities.DTO
{
    /// <summary>
    /// Đối tượng thông báo lỗi trả về cho người dùng
    /// </summary>
    public class ErrorResponseDTO
    {
        #region Field

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Thông báo lỗi cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Thông báo lỗi cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Trang liên hệ khi gặp lỗi
        /// </summary>
        public object MoreInfo { get; set; }

        /// <summary>
        /// Trace Id để rà soát lỗi
        /// </summary>
        public string TraceId { get; set; }

        #endregion
    }
}
