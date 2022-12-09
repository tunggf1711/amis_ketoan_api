using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL.BaseBL
{
    /// <summary>
    /// Interface tầng bussiness layer base
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public interface IBaseBL<T>
    {


        #region Method
        /// <summary>
        /// Lấy bản ghi theo Id
        /// </summary>
        /// <param name="recordId">Id bản ghi</param>
        /// <returns>Dữ liệu bản ghi</returns>
        T GetRecordById(Guid recordId);

        /// <summary>
        /// Lấy danh sách toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        IEnumerable<T> GetAllRecord();

        /// <summary>
        /// Lấy mã bản ghi mới
        /// </summary>
        /// <returns>Mã bản ghi mới</returns>
        string GetNewCode();

        /// <summary>
        /// Lấy paging bản ghi và tìm kiếm
        /// </summary>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <param name="pageNumber">Index trang</param>
        /// <param name="keyWord">Từ khoá tìm kiếm</param>
        /// <returns>Dữ liệu paging</returns>
        PagingResultDTO<T> GetPagingAndFilter(int? pageSize, int pageNumber, string? keyWord);

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu bản ghi</param>
        /// <returns>Số bản ghi đã thêm mới</returns>
        ServiceResponseDTO InsertRecord(T record);

        /// <summary>
        /// Update 1 bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu bản ghi</param>
        /// <param name="recordId">Id Bản ghi cần update</param>
        /// <returns>Số bản ghi đã update</returns>
        ServiceResponseDTO UpdateRecord(T record, Guid recordId);

        /// <summary>
        /// Xoá 1 bản ghi
        /// </summary>
        /// <param name="recordId">Id bản ghi cần xoá</param>
        /// <returns>Số bản ghi đã xoá</returns>
        ServiceResponseDTO DeleteRecord(Guid recordId);

        /// <summary>
        /// Xoá nhiều bản ghi
        /// </summary>
        /// <param name="recordIds">id các bản ghi cần xoá</param>
        /// <returns>Dữ liệu xoá thành công hay thất bại</returns>
        ServiceResponseDTO DeleteMultipleRecord(List<Guid> recordIds);
        #endregion
    }
}
