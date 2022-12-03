using MISA.AMIS.BL.Constants;
using MISA.AMIS.BL.Helpers;
using MISA.AMIS.Common.Atrribute;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using MISA.AMIS.Common.Resources;
using MISA.AMIS.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL.BaseBL
{
    /// <summary>
    /// Tầng Bussiness Layer Base xử lý logic
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field
        private IBaseDL<T> _baseDL;
        #endregion


        #region Constructor
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion


        #region Method
        /// <summary>
        /// Xoá 1 bản ghi
        /// </summary>
        /// <param name="recordId">Id bản ghi cần xoá</param>
        /// <returns>Số bản ghi đã xoá</returns>
        public ServiceResponseDTO DeleteRecord(Guid recordId)
        {
            var recorDelete = _baseDL.GetRecordById(recordId);
            if (recorDelete == null)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = Resources.UserMsg_NotFound
                };
            }
            var numberOfDeleteRow = _baseDL.DeleteRecord(recordId);
            if (numberOfDeleteRow != 1)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = Resources.UserMsg_Exception
                };
            }
            return new ServiceResponseDTO
            {
                IsSuccess = true,
                Data = numberOfDeleteRow
            };

        }

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi </returns>
        public IEnumerable<T> GetAllRecord()
        {
            return _baseDL.GetAllRecord();

        }

        /// <summary>
        /// Lấy mã bản ghi mới
        /// </summary>
        /// <returns>Mã bản ghi mới</returns>
        public string GetNewCode()
        {
            var maxCode = _baseDL.GetMaxCode();
            int newCode;
            int preFixRecordCodeLength = (int)typeof(RecordCodeLength).GetField($"PREFIX_{typeof(T).Name.ToUpper()}_CODE_LENGTH").GetValue(null);
            int postFixRecordCodeLength = (int)typeof(RecordCodeLength).GetField($"POSTFIX_{typeof(T).Name.ToUpper()}_CODE_LENGTH").GetValue(null);
            Int32.TryParse(maxCode.Substring(preFixRecordCodeLength, postFixRecordCodeLength), out newCode);
            return (string)typeof(PrefixRecordCode).GetField($"PREFIX_{typeof(T).Name.ToUpper()}").GetValue(null) + (newCode + 1).ToString().PadLeft(postFixRecordCodeLength, '0');
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
            return _baseDL.GetPagingAndFilter(pageSize, pageNumber, keyWord);
        }

        /// <summary>
        /// Lấy 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordId">Id bản ghi</param>
        /// <returns>Dữ liệu bản ghi</returns>
        public T GetRecordById(Guid recordId)
        {
            return _baseDL.GetRecordById(recordId);
        }

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu bản ghi</param>
        /// <returns>Số bản ghi đã thêm mới</returns>
        public ServiceResponseDTO InsertRecord(T record)
        {
            List<string> validateErrors = new List<string>();
            Validate<T>.ValidateRequired(validateErrors, record);
            Validate<T>.ValidateRecordCode(validateErrors, record);
            if (validateErrors.Count > 0)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = validateErrors
                };
            }


            ValidateDuplicateCode(validateErrors, record);
            if (validateErrors.Count > 0)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = validateErrors
                };
            }
            int numberOfInsertRow = _baseDL.InsertRecord(record);
            if (numberOfInsertRow != 1)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = Resources.UserMsg_Exception
                };
            }


            return new ServiceResponseDTO
            {
                IsSuccess = true,
                Data = numberOfInsertRow
            };


        }

        /// <summary>
        /// Update 1 bản ghi
        /// </summary>
        /// <param name="record">Dữ liệu bản ghi</param>
        /// <param name="recordId">Id bản ghi cần update</param>
        /// <returns>Số bản ghi đã update</returns>
        public ServiceResponseDTO UpdateRecord(T record, Guid recordId)
        {
            var recordUpdate = _baseDL.GetRecordById(recordId);
            if (recordUpdate == null)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = Resources.UserMsg_NotFound
                };
            }

            List<string> validateErrors = new List<string>();
            Validate<T>.ValidateRequired(validateErrors, record);
            Validate<T>.ValidateRecordCode(validateErrors, record);
            if (validateErrors.Count > 0)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = validateErrors
                };
            }
            var recordUpdateCode = typeof(T).GetProperty($"{typeof(T).Name}Code").GetValue(recordUpdate).ToString();
            var recordCode = typeof(T).GetProperty($"{typeof(T).Name}Code").GetValue(record).ToString();
            if (!string.Equals(recordUpdateCode, recordCode))
            {
                ValidateDuplicateCode(validateErrors, record);
                if (validateErrors.Count > 0)
                {
                    return new ServiceResponseDTO
                    {
                        IsSuccess = false,
                        Data = validateErrors
                    };
                }
            }
            int numberOfUpdateRow = _baseDL.UpdateRecord(record, recordId);
            if (numberOfUpdateRow != 1)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = Resources.UserMsg_Exception
                };
            }

            return new ServiceResponseDTO
            {
                IsSuccess = true,
                Data = numberOfUpdateRow
            };
        }

        /// <summary>
        /// Validate trùng mã bản ghi
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="errors">Danh sách lỗi</param>
        /// <param name="record">Dữ liệu bản ghi cần validate</param>
        public void ValidateDuplicateCode<T>(List<string> errors, T record)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var validateDuplicateCodeAtribute = (ValidateDuplicate)property.GetCustomAttributes(typeof(ValidateDuplicate), false).FirstOrDefault();
                if (validateDuplicateCodeAtribute != null)
                {
                    string recordCode = typeof(T).GetProperty($"{typeof(T).Name}Code").GetValue(record).ToString();
                    var recorDuplicate = _baseDL.GetRecordByRecordCode(recordCode);
                    if (recorDuplicate != null)
                    {
                        errors.Add(string.Format(validateDuplicateCodeAtribute.ErrorMessage, recordCode));
                    }
                }
            }
        }
        #endregion
    }
}
