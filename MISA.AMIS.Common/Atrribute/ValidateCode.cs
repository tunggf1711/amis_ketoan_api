using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Atrribute
{

    /// <summary>
    /// Atribute dùng để validate mã bản ghi
    /// </summary>
    public class ValidateCode : Attribute
    {

        #region Field
        public string ErrorMessage { get; set; }
        #endregion


        #region Constructor
        public ValidateCode(string error)
        {
            ErrorMessage = error;
        }
        #endregion
    }
}
