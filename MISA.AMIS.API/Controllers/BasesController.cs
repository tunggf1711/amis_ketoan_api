using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL.BaseBL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.Common.Resources;

namespace MISA.AMIS.API.Controllers
{

    /// <summary>
    /// Controller Base
    /// </summary>
    /// <typeparam name="T">Model</typeparam>

    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field
        private IBaseBL<T> _baseBL;
        #endregion

        #region Constructor
        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy bản ghi theo ID
        /// </summary>
        /// <param name="recordId">ID của bản ghi</param>
        /// <returns>Dữ liệu của bản ghi</returns>
        [HttpGet]
        [Route("{recordId}")]
        public IActionResult GetRecordById([FromRoute] Guid recordId)
        {
            try
            {
                var record = _baseBL.GetRecordById(recordId);
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
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

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Dữ liệu của toàn bộ bản ghi</returns>
        [HttpGet]
        public IActionResult GetAllRecord()
        {
            try
            {
                var records = _baseBL.GetAllRecord();
                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
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

        /// <summary>
        /// Lấy mã bản ghi mới
        /// </summary>
        /// <returns>Mã bản ghi mới</returns>
        [HttpGet]
        [Route("NewCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                var newCode = _baseBL.GetNewCode();
                if (newCode != null)
                {
                    return StatusCode(StatusCodes.Status200OK, newCode);
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

        /// <summary>
        /// Lấy phân trang bản ghi và tìm kiếm bản ghi
        /// </summary>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <param name="pageNumber">Index trang</param>
        /// <param name="keyWord">Từ khoá search bản ghi</param>
        /// <returns>Dữ liệu paging</returns>
        [HttpGet]
        [Route("filter")]
        public IActionResult GetPagingAndFilter([FromQuery] int? pageSize, [FromQuery] int pageNumber, [FromQuery] string? keyWord)
        {
            try
            {
                var pagingResult = _baseBL.GetPagingAndFilter(pageSize, pageNumber, keyWord);
                if (pagingResult != null)
                {
                    return StatusCode(StatusCodes.Status200OK, pagingResult);
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

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu bản ghi</param>
        /// <returns>Số bản ghi đã thêm thành công</returns>
        [HttpPost]
        public IActionResult InsertRecord([FromBody] T record)
        {
            try
            {
                var serviceReponse = _baseBL.InsertRecord(record);
                if (serviceReponse.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, serviceReponse.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponseDTO
                    {
                        ErrorCode = ErrorCode.ErrorCode_Validate,
                        DevMsg = Resources.DevMsg_Validate,
                        UserMsg = Resources.UserMsg_Validate,
                        MoreInfo = serviceReponse.Data,
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

        /// <summary>
        /// Update 1 bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu bản ghi</param>
        /// <param name="recordId">ID Bản ghi cần update</param>
        /// <returns>Số bản ghi đã update</returns>
        [HttpPut]
        [Route("{recordId}")]
        public IActionResult UpdateRecord([FromBody] T record, [FromRoute] Guid recordId)
        {
            try
            {
                var serviceReponse = _baseBL.UpdateRecord(record, recordId);
                if (serviceReponse.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK, serviceReponse.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponseDTO
                    {
                        ErrorCode = ErrorCode.ErrorCode_Validate,
                        DevMsg = Resources.DevMsg_Validate,
                        UserMsg = Resources.UserMsg_Validate,
                        MoreInfo = serviceReponse.Data,
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

        /// <summary>
        /// Xoá 1 bản ghi
        /// </summary>
        /// <param name="recordId">ID Bản ghi cần xoá</param>
        /// <returns>Số bản ghi đã xoá</returns>
        [HttpDelete]
        [Route("{recordId}")]
        public IActionResult DeleteRecord([FromRoute] Guid recordId)
        {
            try
            {
                var serviceReponse = _baseBL.DeleteRecord(recordId);
                if (serviceReponse.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, serviceReponse.Data);
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

        /// <summary>
        /// Xoá nhiều bản ghi
        /// </summary>
        /// <param name="recordIds">Id các bản ghi cần xoá</param>
        /// <returns>Số bản ghi đã xoá thành công</returns>
        [HttpPost]
        [Route("multi-delete")]
        public IActionResult DeleteMultipleRecord([FromBody] List<Guid> recordIds)
        {
            try
            {
                var serviceReponse = _baseBL.DeleteMultipleRecord(recordIds);
                if (serviceReponse.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK, serviceReponse.Data);
                }
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResponseDTO
                {
                    ErrorCode = ErrorCode.ErrorCode_Validate,
                    DevMsg = Resources.DevMsg_Validate,
                    UserMsg = Resources.UserMsg_Validate,
                    MoreInfo = serviceReponse.Data,
                    TraceId = HttpContext.TraceIdentifier
                });
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

        #endregion
    }
}
