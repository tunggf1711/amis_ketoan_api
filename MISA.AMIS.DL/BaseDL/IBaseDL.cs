using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL.BaseDL
{
    /// <summary>
    /// Interface tầng datalayer xử lý truy xuất database
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public interface IBaseDL<T>
    {

        #region Method

        /// <summary>
        /// Lấy 1 bản ghi theo Id
        /// </summary>
        /// <param name="recordId">Id bản ghi cần lấy</param>
        /// <returns>Dữ liệu bản ghi</returns>
        T GetRecordById(Guid recordId);

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Dữ liệu toàn bộ bản ghi</returns>
        IEnumerable<T> GetAllRecord();

        /// <summary>
        /// Lấy mã bản ghi lớn nhất
        /// </summary>
        /// <returns>Mã bản ghi lớn nhất</returns>
        int GetMaxCode();

        /// <summary>
        /// Lấy paging bản ghi và tìm kiếm bản ghi
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
        int InsertRecord(T record);

        /// <summary>
        /// Lấy bản ghi theo mã
        /// </summary>
        /// <param name="recordCode">mã bản ghi</param>
        /// <returns>Dữ liệu bản ghi</returns>
        T GetRecordByRecordCode(string recordCode);

        /// <summary>
        /// Update dữ liệu bản ghi theo ID
        /// </summary>
        /// <param name="record">dữ liệu bản ghi</param>
        /// <param name="recordId">Id bản ghi cần update</param>
        /// <returns>Số bản ghi đã update</returns>
        int UpdateRecord(T record, Guid recordId);

        /// <summary>
        /// Xoá 1 bản ghi theo Id
        /// </summary>
        /// <param name="recordId">Id bản ghi cần xoá</param>
        /// <returns>Số bản ghi đã xoá</returns>
        int DeleteRecord(Guid recordId);

        /// <summary>
        /// Xoá nhiều bản ghi
        /// </summary>
        /// <param name="recordIds">Id các bản ghi cần xoá</param>
        /// <returns>Số bản ghi đã xoá</returns>
        int DeleteMultipleRecord(List<Guid> recordIds);
        #endregion
    }
}
