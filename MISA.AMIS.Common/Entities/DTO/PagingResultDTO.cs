using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Entities.DTO
{
    /// <summary>
    /// Dữ liệu trả về khi phân trang và search
    /// </summary>
    public class PagingResultDTO<T>
    {
        #region Field

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public long TotalRecord { get; set; }
        /// <summary>
        /// Dữ liệu bản ghi
        /// </summary>
        public List<T> Data { get; set; }

        #endregion
    }
}
