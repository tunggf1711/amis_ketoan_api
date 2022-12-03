using MISA.AMIS.BL.BaseBL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using MISA.AMIS.Common.Resources;
using MISA.AMIS.DL.EmployeeDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL.EmployeeBL
{
    /// <summary>
    /// Bussiness Layer xử lý logic của nhân viên
    /// </summary>
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Field
        private IEmployeeDL _employeeDL;
        #endregion

        #region Constructor
        public EmployeeBL(IEmployeeDL employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }
        #endregion


    }
}