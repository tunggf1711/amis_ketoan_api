using MISA.AMIS.BL.BaseBL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Entities.DTO;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.Common.Resources;
using MISA.AMIS.DL.EmployeeDL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace MISA.AMIS.BL.EmployeeBL
{
    /// <summary>
    /// Bussiness Layer xử lý logic của nhân viên
    /// </summary>
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Field
        private IEmployeeDL _employeeDL;
        #endregion

        #region Constructor
        public EmployeeBL(IEmployeeDL employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }

        /// <summary>
        /// Xuất khẩu file excel dữ liệu nhân viên
        /// </summary>
        /// <returns>Dữ liệu file excel nhân viên</returns>
        public ServiceResponseDTO GetExportExcelEmployee()
        {
            var result = _employeeDL.GetAllRecord();
            if (result == null || result.Count() <= 0)
            {
                return new ServiceResponseDTO
                {
                    IsSuccess = false,
                    Data = Resources.DevMsg_NotFound
                };
            }

            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                string listColName = "ABCDEFGHI";
                var workSheet = package.Workbook.Worksheets.Add(Resources.Excel_Employee_Title);

                #region Style cho các ô header
                workSheet.Cells.Style.Font.SetFromFont("Times New Roman", 11);
                workSheet.Cells["A1:I1"].Merge = true;
                workSheet.Cells["A2:I2"].Merge = true;
                workSheet.Cells["A1"].Value = Resources.Excel_Employee_Title;
                workSheet.Cells["A1"].Style.Font.SetFromFont("Arial", 16, true);
                workSheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["A3:I3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A3:I3"].Style.Fill.BackgroundColor.SetColor(OfficeOpenXml.Drawing.eThemeSchemeColor.Accent3);
                workSheet.Cells["A3:I3"].Style.Font.SetFromFont("Arial", 10, true);
                workSheet.Cells["A3:I3"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["A3:I3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                #endregion

                #region Đặt chiều rộng các cột 
                workSheet.Column(1).Width = 5;
                workSheet.Column(2).Width = 15;
                workSheet.Column(3).Width = 26;
                workSheet.Column(4).Width = 12;
                workSheet.Column(5).Width = 15;
                workSheet.Column(6).Width = 26;
                workSheet.Column(7).Width = 26;
                workSheet.Column(8).Width = 16;
                workSheet.Column(9).Width = 26;
                #endregion

                #region Header các cột

                workSheet.Cells["A3"].Value = Resources.Excel_Display_Index;
                workSheet.Cells["B3"].Value = Resources.Excel_Display_EmployeeCode;
                workSheet.Cells["C3"].Value = Resources.Excel_Display_EmployeeName;
                workSheet.Cells["D3"].Value = Resources.Excel_Display_Gender;
                workSheet.Cells["E3"].Value = Resources.Excel_Display_DateOfBirth;
                workSheet.Cells["F3"].Value = Resources.Excel_Display_Position;
                workSheet.Cells["G3"].Value = Resources.Excel_Display_DepartmentName;
                workSheet.Cells["H3"].Value = Resources.Excel_Display_BankAccountNumber;
                workSheet.Cells["I3"].Value = Resources.Excel_Display_BankName;
                workSheet.Cells["A3:I3"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                #endregion

                #region render bản ghi
                int rowStart = 3;
                foreach (var text in listColName)
                {
                    workSheet.Cells[$"{text}{rowStart}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    workSheet.Cells[$"{text}{rowStart}"].Style.WrapText = true;
                }
                foreach (var val in result.Select((value, i) => new { i, value }))
                {
                    for (int col = 1; col <= 9; col++)
                    {
                        workSheet.Cells[val.i + 1 + rowStart, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        workSheet.Cells[val.i + 1 + rowStart, col].Style.WrapText = true;
                        if (col == 5)
                        {
                            workSheet.Cells[val.i + 1 + rowStart, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }
                    }

                    workSheet.Cells[val.i + 1 + rowStart, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    workSheet.Cells[val.i + 1 + rowStart, 1].Value = val.i + 1;
                    workSheet.Cells[val.i + 1 + rowStart, 2].Value = val.value.EmployeeCode.ToString();
                    workSheet.Cells[val.i + 1 + rowStart, 3].Value = val.value.EmployeeName.ToString();
                    workSheet.Cells[val.i + 1 + rowStart, 4].Value = val.value.Gender == Gender.Male ? Resources.Excel_Display_Male : val.value.Gender == Gender.Female ? Resources.Excel_Display_Female : Resources.Excel_Display_Other;
                    workSheet.Cells[val.i + 1 + rowStart, 5].Value = val.value.DateOfBirth == null ? "" : val.value.DateOfBirth?.ToString("dd/MM/yyyy");
                    workSheet.Cells[val.i + 1 + rowStart, 6].Value = val.value.PostionName == null ? "" : val.value.PostionName.ToString();
                    workSheet.Cells[val.i + 1 + rowStart, 7].Value = val.value.DepartmentName == null ? "" : val.value.DepartmentName.ToString();
                    workSheet.Cells[val.i + 1 + rowStart, 8].Value = val.value.BankAccountNumber == null ? "" : val.value.BankAccountNumber.ToString();
                    workSheet.Cells[val.i + 1 + rowStart, 9].Value = val.value.BankName == null ? "" : val.value.BankName.ToString();

                }
                package.SaveAs(stream);
                #endregion
            }
            stream.Position = 0;
            return new ServiceResponseDTO
            {
                IsSuccess = true,
                Data = stream
            };
        }
        #endregion


    }
}