using MISA.AMIS.BL.BaseBL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.DL.DepartmentDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL.DepartmentBL
{
    /// <summary>
    /// Tầng bussiness layer xử lý logic của phòng ban
    /// </summary>
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {

        #region Field
        private IDepartmentDL _departmentDL;
        #endregion


        #region Constructor
        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _departmentDL = departmentDL;
        }
        #endregion
    }
}
