using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using CompetitorReg.Entities;
using CompetitorReg.Infrastructure.Abstract;
using DevExpress.Data.PLinq.Helpers;
using Microsoft.Office.Interop.Excel;

namespace CompetitorReg.Models.CompetitorModels
{
    public class CompetitorListModel : CommonListModel<CompetitorModel>
    {
        private string surnameFilter;
        protected readonly ObservableCollection<CompetitorModel> unfilteredData = new ObservableCollection<CompetitorModel>();

        public string SurnameFilter { get { return surnameFilter; } set { surnameFilter = value; NotifyPropertyChanged("SurnameFilter"); FilterData(); } }

        public CompetitorListModel(ISessionHelper sessionHelper) : base(sessionHelper)
        {
        }

        private void FilterData()
        {
            Data.Clear();
            var tmp = unfilteredData
                .Where(x => (surnameFilter == null) || (surnameFilter != null && x.Surname.ToUpper().Contains(surnameFilter.ToUpper())));
            foreach (var competitorModel in tmp)
            {
                Data.Add(competitorModel);
            }
        }

        public override void ReloadData()
        {
            unfilteredData.Clear();
            using (var session = sessionHelper.NewSession())
            {
                var query = session.QueryOver<Competitor>().List();
                foreach (var competitor in query)
                {
                    unfilteredData.Add(new CompetitorModel
                    {
                        Id = competitor.Id,
                        Surname = competitor.Surname,
                        Name = competitor.Name,
                        MiddleName = competitor.MiddleName,
                        ContactPhone = competitor.ContactPhone,
                        BirthDate = competitor.BirthDate,
                        BirthPlace = competitor.BirthPlace,
                        PassportSerial = competitor.PassportSerial,
                        PassportNumber = competitor.PassportNumber,
                        IssuingAuthority = competitor.IssuingAuthority,
                        DepartmentCode = competitor.DepartmentCode,
                        IssueDate = competitor.IssueDate,
                        Nee = competitor.Nee,
                        IncorporationPlace = competitor.IncorporationPlace,
                        ResidencePlace = competitor.ResidencePlace
                    });
                }
            }
            FilterData();
        }

        public override void ReloadFocusedRow()
        {
            if (FocusedRow == null) return;
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Competitor>(FocusedRow.Id);
                var itemGrid = unfilteredData.FirstOrDefault(x => x.Id == FocusedRow.Id);
                if (itemDb == null || itemGrid == null) return;

                var index = unfilteredData.IndexOf(itemGrid);
                unfilteredData[index] = new CompetitorModel
                {
                    Id = itemDb.Id,
                    Surname = itemDb.Surname,
                    Name = itemDb.Name,
                    MiddleName = itemDb.MiddleName,
                    ContactPhone = itemDb.ContactPhone,
                    BirthDate = itemDb.BirthDate
                };
                FilterData();
                FocusedRow = unfilteredData[index]; // must be after filter
            }
        }

        public override void ReloadAfterAdd(int id)
        {
            using (var session = sessionHelper.NewSession())
            {
                var itemDb = session.Get<Competitor>(id);
                var itemGrid = new CompetitorModel
                {
                    Id = itemDb.Id,
                    Surname = itemDb.Surname,
                    Name = itemDb.Name,
                    MiddleName = itemDb.MiddleName,
                    ContactPhone = itemDb.ContactPhone,
                    BirthDate = itemDb.BirthDate
                };
                unfilteredData.Add(itemGrid);
                FilterData();
                FocusedRow = itemGrid; // must be after filter
            }
        }

        public void ExportToExcel()
        {
            var excelApp = new Application {Visible = false};
            var workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = workbook.Sheets[1];

            #region Шапка
            worksheet.Range["A:A"].EntireColumn.ColumnWidth = 5;
            worksheet.Range["B:B"].EntireColumn.ColumnWidth = 5;
            worksheet.Range["C:C"].EntireColumn.ColumnWidth = 10.14;
            worksheet.Range["D:D"].EntireColumn.ColumnWidth = 20.43;
            worksheet.Range["E:E"].EntireColumn.ColumnWidth = 16.86;
            worksheet.Range["F:F"].EntireColumn.ColumnWidth = 13.14;
            worksheet.Range["G:G"].EntireColumn.ColumnWidth = 31.43;
            worksheet.Range["H:H"].EntireColumn.ColumnWidth = 23.57;
            worksheet.Range["I:I"].EntireColumn.ColumnWidth = 23.43;
            worksheet.Range["J:J"].EntireColumn.ColumnWidth = 14.29;
            worksheet.Range["K:K"].EntireColumn.ColumnWidth = 14;

            worksheet.Range["A1:K1"].Merge();
            worksheet.Range["A1"].Value2 = "Список №__";
            worksheet.Range["A1"].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter; 
            worksheet.Range["A1"].Cells.Font.Size = 18;
            worksheet.Range["A1"].Cells.Font.Bold = true;

            worksheet.Range["A2:K2"].Merge();
            worksheet.Range["A2"].Value2 = "кандидатов на замещение вакантных должностей ";
            worksheet.Range["A2"].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            worksheet.Range["A3:K3"].Merge();
            worksheet.Range["A3"].Value2 = "от \"10\" октября 2014 года";
            worksheet.Range["A3"].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            worksheet.Range["A4:K4"].Cells.Font.Bold = true;
            worksheet.Range["A4:K4"].Cells.WrapText = true;
            worksheet.Range["A4:K4"].EntireRow.RowHeight = 45;

            worksheet.Range["A4:K5"].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            worksheet.Range["A4:K5"].Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            worksheet.Range["A4:K5"].Cells.Font.Size = 9;
            worksheet.Range["A4:K5"].Cells.Interior.Color = Color.FromArgb(0, 221, 217, 195);
            worksheet.Range["A4:K5"].Cells.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Range["A4:K5"].Cells.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Range["A4:K5"].Cells.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Range["A4:K5"].Cells.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Range["A4:K5"].Cells.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Range["A4:K5"].Cells.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;

            worksheet.Range["A4"].Value2 = "№ п/п";
            worksheet.Range["B4"].Value2 = "№ТК/Офис";
            worksheet.Range["C4"].Value2 = "Дата списка";
            worksheet.Range["D4"].Value2 = "Должность (вакансии)";
            worksheet.Range["E4"].Value2 = "Ф.И.О\n(полностью)";
            worksheet.Range["F4"].Value2 = "Дата и место рождения";
            worksheet.Range["G4"].Value2 = "№ и серия паспорта, кем и когда выдан";
            worksheet.Range["H4"].Value2 = "Место регистрации";
            worksheet.Range["I4"].Value2 = "Фактическое место жительства";
            worksheet.Range["J4"].Value2 = "Результат проверки";
            worksheet.Range["K4"].Value2 = "Заключение по проверке";

            worksheet.Range["A5"].Value2 = "1";
            worksheet.Range["B5"].Value2 = "2";
            worksheet.Range["C5"].Value2 = "3";
            worksheet.Range["D5"].Value2 = "4";
            worksheet.Range["E5"].Value2 = "5";
            worksheet.Range["F5"].Value2 = "6";
            worksheet.Range["G5"].Value2 = "7";
            worksheet.Range["H5"].Value2 = "8";
            worksheet.Range["I5"].Value2 = "9";
            worksheet.Range["J5"].Value2 = "10";
            worksheet.Range["K5"].Value2 = "11";
            #endregion

            int index = 0;
            foreach (var competitor in Data.OrderBy(x=>x.Surname))
            {

                var row = index++ + 6;
                worksheet.Range["A" + row].Value2 = index;
                worksheet.Range["B" + row].Value2 = 148;
                worksheet.Range["C" + row].Value2 = DateTime.Now.ToShortDateString();
                worksheet.Range["D" + row].Value2 = "";
                worksheet.Range["E" + row].Value2 = competitor.Nee == null
                    ? string.Format("{0} {1} {2}", competitor.Surname, competitor.Name, competitor.MiddleName)
                    : string.Format("{0} ({1}) {2} {3}", competitor.Surname, competitor.Nee, competitor.Name, competitor.MiddleName);
                worksheet.Range["F" + row].Value2 = string.Format("{0}\n{1}", competitor.BirthDate.ToShortDateString(), competitor.BirthPlace);
                worksheet.Range["G" + row].Value2 = string.Format("{0} № {1} {2}, {3}, код подразделения {4}",
                    competitor.PassportSerial, competitor.PassportNumber, competitor.IssuingAuthority,
                    competitor.IssueDate.ToShortDateString(), competitor.DepartmentCode);
                worksheet.Range["H" + row].Value2 = competitor.IncorporationPlace;
                worksheet.Range["I" + row].Value2 = competitor.ResidencePlace;

                worksheet.Range["A" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Range["B" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Range["C" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                worksheet.Range["D" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                worksheet.Range["E" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                worksheet.Range["F" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                worksheet.Range["G" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                worksheet.Range["H" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                worksheet.Range["I" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                worksheet.Range["J" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                worksheet.Range["K" + row].Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;

                worksheet.Range["A" + row + ":K" + row].Cells.Font.Size = 9;
                worksheet.Range["A" + row + ":K" + row].Cells.WrapText = true;
                worksheet.Range["A" + row + ":K" + row].Cells.VerticalAlignment = XlVAlign.xlVAlignTop;
                worksheet.Range["A" + row + ":K" + row].Cells.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Range["A" + row + ":K" + row].Cells.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Range["A" + row + ":K" + row].Cells.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Range["A" + row + ":K" + row].Cells.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Range["A" + row + ":K" + row].Cells.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Range["A" + row + ":K" + row].Cells.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            }
            excelApp.Visible = true;
        }
    }
}
