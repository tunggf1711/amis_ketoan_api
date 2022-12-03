using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL.DepartmentBL;
using MISA.AMIS.Common.Entities;

namespace MISA.AMIS.API.Controllers
{
    /// <summary>
    /// Controller Phòng Ban
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        #region Field
        private IDepartmentBL _departmentBL;
        #endregion

        #region Constructor
        public DepartmentsController(IDepartmentBL departmentBL) : base(departmentBL)
        {
            _departmentBL = departmentBL;
        }
        #endregion
    }
}
