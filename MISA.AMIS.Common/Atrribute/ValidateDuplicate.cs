using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common.Atrribute
{
    /// <summary>
    /// Atribute dùng để validate mã unique
    /// </summary>
    public class ValidateDuplicate : Attribute
    {

        #region Field
        public string ErrorMessage { get; set; }
        #endregion

        #region Method
        public ValidateDuplicate(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        #endregion
    }
}
