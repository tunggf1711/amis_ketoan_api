using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL.EmployeeBL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.Common.Resources;
using MISA.AMIS.DL.EmployeeDL;

namespace MISA.AMIS.API.Controllers
{
    /// <summary>
    /// Controller Nhân viên
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BasesController<Employee>
    {
        #region Field
        private IEmployeeBL _employeeBL;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        #endregion


    }
}
