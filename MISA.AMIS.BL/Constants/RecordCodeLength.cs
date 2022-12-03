using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL.Constants
{
    /// <summary>
    /// Độ dài mã hiệu trong mã bản ghi
    /// </summary>
    public class RecordCodeLength
    {

        #region Field

        /// <summary>
        /// Độ dài mã hiệu trước mã nhân viên
        /// </summary>
        public static int PREFIX_EMPLOYEE_CODE_LENGTH = 2;

        /// <summary>
        /// Độ dài mã hiệu trước mã phòng ban
        /// </summary>
        public static int PREFIX_DEPARTMENT_CODE_LENGTH = 2;

        /// <summary>
        /// Độ dài mã hiệu sau mã nhân viên
        /// </summary>
        public static int POSTFIX_EMPLOYEE_CODE_LENGTH = 5;

        /// <summary>
        /// Độ dài mã hiệu sau mã phòng ban
        /// </summary>
        public static int POSTFIX_DEPARTMENT_CODE_LENGTH = 3;
        #endregion
    }
}
