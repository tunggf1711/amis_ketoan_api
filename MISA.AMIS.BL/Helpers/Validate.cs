using MISA.AMIS.BL.Constants;
using MISA.AMIS.Common.Atrribute;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL.Helpers
{

    /// <summary>
    /// Xứ lý các validate dữ liệu bản ghi
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public class Validate<T>
    {

        #region Method

        /// <summary>
        /// Xử lý validate Dữ liệu bản ghi bắt buộc nhập
        /// </summary>
        /// <param name="errors">mảng lưu lỗi</param>
        /// <param name="record">dữ liệu bản ghi cần validate</param>
        public static void ValidateRequired(List<string> errors, T record)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var requiredAtribute = (RequiredAttribute)property.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault();

                if (requiredAtribute != null)
                {
                    if (property.GetValue(record) == null)
                    {
                        errors.Add(requiredAtribute.ErrorMessage);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(property.GetValue(record).ToString().Trim()))
                        {
                            errors.Add(requiredAtribute.ErrorMessage);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Xử lý validate dữ liệu mã bản ghi
        /// </summary>
        /// <param name="errors">Mảng lưu lỗi</param>
        /// <param name="record">Dữ liệu bản ghi cần validate</param>
        public static void ValidateRecordCode(List<string> errors, T record)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var validateCodeAtribute = (ValidateCode)property.GetCustomAttributes(typeof(ValidateCode), false).FirstOrDefault();
                if (validateCodeAtribute != null && !string.IsNullOrEmpty(property.GetValue(record).ToString().Trim()))
                {
                    int recordCodePostFix;
                    int prefixRecordCodeLength = (int)typeof(RecordCodeLength).GetField($"PREFIX_{typeof(T).Name.ToUpper()}_CODE_LENGTH").GetValue(null);

                    string prefixRecordCode = (string)typeof(PrefixRecordCode).GetField($"PREFIX_{typeof(T).Name.ToUpper()}").GetValue(null);
                    if (!property.GetValue(record).ToString().Substring(0, prefixRecordCodeLength).Equals(prefixRecordCode))
                    {
                        errors.Add(validateCodeAtribute.ErrorMessage);
                    }
                    int postfixCodeLength = property.GetValue(record).ToString().Length - prefixRecordCodeLength;
                    if (!Int32.TryParse(property.GetValue(record).ToString().Substring(prefixRecordCodeLength, postfixCodeLength), out recordCodePostFix))
                    {
                        errors.Add(validateCodeAtribute.ErrorMessage);
                    }

                }
            }
        }
        #endregion


    }
}
