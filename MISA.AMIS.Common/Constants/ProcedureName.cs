using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Constants
{
    /// <summary>
    /// Chứa các tên của procedure truy xuất vào database
    /// </summary>
    public class ProcedureName
    {

        #region Field

        /// <summary>
        /// Proc lấy mã bản ghi theo ID
        /// </summary>
        public static string PROC_GET_RECORD_BY_ID = "Proc_{0}_GetById";

        /// <summary>
        /// Proc lấy tất cả bản ghi
        /// </summary>
        public static string PROC_GET_ALL_RECORD = "Proc_{0}_GetAll";

        /// <summary>
        /// Proc lấy mã bản ghi lớn nhất
        /// </summary>
        public static string PROC_GET_MAXCODE = "Proc_{0}_GetMaxCode";

        /// <summary>
        /// Proc lấy paging và tìm kiếm
        /// </summary>
        public static string PROC_GETPAGING_AND_FILTER = "Proc_{0}_GetPaging";

        /// <summary>
        /// Proc thêm mới bản ghi
        /// </summary>
        public static string PROC_INSERT_RECORD = "Proc_{0}_Insert";

        /// <summary>
        /// Proc lấy bản ghi theo mã
        /// </summary>
        public static string PROC_GET_RECORD_BY_CODE = "Proc_{0}_GetByCode";

        /// <summary>
        /// Proc update bản ghi
        /// </summary>
        public static string PROC_UPDATE_RECORD = "Proc_{0}_Update";

        /// <summary>
        /// Proc xoá bản ghi theo ID
        /// </summary>
        public static string PROC_DELETE_RECORD_BY_ID = "Proc_{0}_Delete";
        #endregion
    }
}
