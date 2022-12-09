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


        /// <summary>
        /// Xuất khẩu file excel dữ liệu toàn bộ nhân viên
        /// </summary>
        /// <returns>Dữ liệu file excel</returns>
        [HttpGet]
        [Route("export")]
        public IActionResult GetExportExcelEmployee()
        {
            try
            {
                var serviceReponse = _employeeBL.GetExportExcelEmployee();
                if (serviceReponse.IsSuccess)
                {
                    string excelName = $"Employee-{DateTime.Now.ToString("ddMMyyyyHHmmssfff")}.xlsx";
                    return File((MemoryStream)(serviceReponse.Data), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResponseDTO
                    {
                        ErrorCode = ErrorCode.ErrorCode_NotFound,
                        DevMsg = Resources.DevMsg_NotFound,
                        UserMsg = Resources.UserMsg_NotFound,
                        MoreInfo = Resources.MoreInfo,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDTO
                {
                    ErrorCode = ErrorCode.ErrorCode_Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }
    }
}
