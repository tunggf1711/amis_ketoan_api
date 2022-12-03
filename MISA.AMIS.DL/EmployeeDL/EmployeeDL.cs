using Dapper;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using MISA.AMIS.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL.EmployeeDL
{

    /// <summary>
    /// Datalayer xử lý truy xuất database nhân viên
    /// </summary>
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {

    }
}

