using Dapper;
using MISA.AMIS.Common.Constants;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using MISA.AMIS.DL.EmployeeDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL.BaseDL
{
    /// <summary>
    /// Tầng data layer base xử lý truy xuất database base
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public class BaseDL<T> : IBaseDL<T>
    {

        #region Method

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Dữ liệu toàn bộ bản ghi</returns>
        public IEnumerable<T> GetAllRecord()
        {
            // Chuẩn bị tên stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_GET_ALL_RECORD, typeof(T).Name);
            //Chuẩn bị connection string
            string connectionString = DatabaseContext.ConnectionString;
            IEnumerable<T> records;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                records = mySqlConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            }
            return records;

        }

        /// <summary>
        /// Lấy bản ghi theo mã
        /// </summary>
        /// <param name="recordCode">mã bản ghi</param>
        /// <returns>Dữ liệu bản ghi</returns>
        public T GetRecordByRecordCode(string recordCode)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_GET_RECORD_BY_CODE, typeof(T).Name);
            //Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}Code", recordCode);

            //Khới tạo kết nối đến Database
            string connectionString = DatabaseContext.ConnectionString;

            T record;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                record = mySqlConnection.QueryFirstOrDefault<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
            return record;
        }

        /// <summary>
        /// Lấy mã bản ghi lớn nhất
        /// </summary>
        /// <returns>Mã bản ghi lớn nhất</returns>
        public string GetMaxCode()
        {
            //Chuẩn bị stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_GET_MAXCODE, typeof(T).Name);

            //Khởi tạo kết nối đến database
            string connectionString = DatabaseContext.ConnectionString;
            string maxCode;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                maxCode = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            }
            return maxCode;

        }

        /// <summary>
        /// Lấy paging bản ghi và tìm kiếm bản ghi
        /// </summary>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <param name="pageNumber">Index trang</param>
        /// <param name="keyWord">Từ khoá tìm kiếm</param>
        /// <returns>Dữ liệu paging</returns>
        public PagingResultDTO<T> GetPagingAndFilter(int? pageSize, int pageNumber, string? keyWord)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_GETPAGING_AND_FILTER, typeof(T).Name);
            //Khởi tạo các tham số
            var parameters = new DynamicParameters();
            parameters.Add("v_Limit", pageSize);
            parameters.Add("v_Offset", (pageNumber - 1) * pageSize);
            parameters.Add("v_Where", $"{typeof(T).Name}Name LIKE '%{keyWord}%' OR {typeof(T).Name}Code LIKE '%{keyWord}%'");
            parameters.Add("v_Sort", null);
            //Khởi tạo kết nối đến database
            string connectionString = DatabaseContext.ConnectionString;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                var pagingResult = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return new PagingResultDTO<T>
                {
                    Data = pagingResult.Read<T>().ToList(),
                    TotalRecord = pagingResult.ReadSingle<long>()
                };
            }
        }

        /// <summary>
        /// Lấy 1 bản ghi theo Id
        /// </summary>
        /// <param name="recordId">Id bản ghi cần lấy</param>
        /// <returns>Dữ liệu bản ghi</returns>
        public T GetRecordById(Guid recordId)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_GET_RECORD_BY_ID, typeof(T).Name);
            // Khởi tạo tham số
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}Id", recordId);
            //Khởi tạo kết nối đến database
            string connectionString = DatabaseContext.ConnectionString;
            T record;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                record = mySqlConnection.QueryFirstOrDefault<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return record;

        }

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu bản ghi</param>
        /// <returns>Số bản ghi đã thêm mới</returns>
        public int InsertRecord(T record)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_INSERT_RECORD, typeof(T).Name);
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            //Khởi tạo các tham số
            foreach (var property in properties)
            {
                if (string.Equals(property.Name, $"{typeof(T).Name}Id"))
                {
                    parameters.Add($"@{typeof(T).Name}Id", Guid.NewGuid());
                }
                else if (string.Equals(property.Name, "CreatedDate"))
                {
                    parameters.Add("@CreatedDate", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else if (string.Equals(property.Name, "ModifiedDate"))
                {
                    parameters.Add("@ModifiedDate", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else
                {
                    parameters.Add($"@{property.Name}", property.GetValue(record));
                }
            }
            string connectionString = DatabaseContext.ConnectionString;
            int numberOfInsertRow;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                numberOfInsertRow = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return numberOfInsertRow;
        }

        /// <summary>
        /// Update dữ liệu bản ghi theo ID
        /// </summary>
        /// <param name="record">dữ liệu bản ghi</param>
        /// <param name="recordId">Id bản ghi cần update</param>
        /// <returns>Số bản ghi đã update</returns>
        public int UpdateRecord(T record, Guid recordId)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_UPDATE_RECORD, typeof(T).Name);
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            //Khởi tạo các tham số
            foreach (var property in properties)
            {
                if (string.Equals(property.Name, $"{typeof(T).Name}Id"))
                {
                    parameters.Add($"@{typeof(T).Name}Id", recordId);
                }
                else if (string.Equals(property.Name, "ModifiedDate"))
                {
                    parameters.Add("@ModifiedDate", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else
                {
                    parameters.Add($"@{property.Name}", property.GetValue(record));
                }
            }
            string connectionString = DatabaseContext.ConnectionString;
            int numberOfUpdateRow;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                numberOfUpdateRow = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return numberOfUpdateRow;

        }

        /// <summary>
        /// Xoá 1 bản ghi theo Id
        /// </summary>
        /// <param name="recordId">Id bản ghi cần xoá</param>
        /// <returns>Số bản ghi đã xoá</returns>
        public int DeleteRecord(Guid recordId)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = string.Format(ProcedureName.PROC_DELETE_RECORD_BY_ID, typeof(T).Name);
            var parameters = new DynamicParameters();
            //Khởi tạo tham số
            parameters.Add($"@{typeof(T).Name}Id", recordId);
            string connectionString = DatabaseContext.ConnectionString;
            int numberOfDeleteRow;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                numberOfDeleteRow = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return numberOfDeleteRow;

        }
        #endregion
    }
}
