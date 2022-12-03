using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Entities.DTO
{
    /// <summary>
    /// Dữ liệu trả về khi thực thi các tác vụ ở BL
    /// </summary>
    public class ServiceResponseDTO
    {
        #region Field

        /// <summary>
        /// Trạng thái thực thi tác vụ
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Data trả về
        /// </summary>
        public object Data { get; set; }

        #endregion
    }
}
