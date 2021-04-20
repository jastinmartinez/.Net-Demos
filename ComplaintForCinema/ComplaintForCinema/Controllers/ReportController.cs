using ComplaintForCinema.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComplaintForCinema.Controllers
{
    public class ReportController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();
        // GET: Report
        public ActionResult OpenComplaint()
        {
            IQueryable<Report> query = GetAllComplaints().Where(x => x.ComplaintStatusDescription == "Abierto");

            return View(query.AsEnumerable());
        }
        public ActionResult PendingComplaint()
        {
            IQueryable<Report> query = GetAllComplaints().Where(x => x.ComplaintStatusDescription == "Pendiente");

            return View(query.AsEnumerable());
        }
        public ActionResult CloseComplaint()
        {
            IQueryable<Report> query = GetAllComplaints().Where(x => x.ComplaintStatusDescription == "Cerrado");

            return View(query.AsEnumerable());
        }
        public ActionResult Complaints()
        {
            IQueryable<Report> query = GetAllComplaints();

            return View(query.AsEnumerable());
        }

        public void DownloadOpenComplaint()
        {
            DownloadExcel("SolicitudesAbiertas", GetAllComplaints().Where(x => x.ComplaintStatusDescription == "Abierto"));
        }
        public void DownloadCloseComplaint()
        {
            DownloadExcel("SolicitudesCerradas", GetAllComplaints().Where(x => x.ComplaintStatusDescription == "Cerrado"));
        }
        public void DownloadPendingComplaint()
        {
            DownloadExcel("SolicitudesPendientes", GetAllComplaints().Where(x => x.ComplaintStatusDescription == "Pendiente"));
        }
        public void DownloadComplaint()
        {
            DownloadExcel("Solicitudes", GetAllComplaints());
        }

        private void DownloadExcel(String reportName, IEnumerable<Report> query)
        {
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "ID";
            Sheet.Cells["B1"].Value = "Tipo de Solicitud";
            Sheet.Cells["C1"].Value = "Titulo";
            Sheet.Cells["D1"].Value = "Descripcion";
            Sheet.Cells["E1"].Value = "Usuario";
            Sheet.Cells["F1"].Value = "Producto";
            Sheet.Cells["G1"].Value = "Fecha";
            Sheet.Cells["H1"].Value = "Estado";
            Sheet.Cells["I1"].Value = "Ubicacion";
            Sheet.Cells["J1"].Value = "Comentario";
            int row = 2;
            foreach (var item in query)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.ComplaintID;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.ComplaintTypeDescription;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.ComplaintTitle;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.ComplaintDescription;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Email;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.ComplaintProductDescription;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.ComplaintDate;
                Sheet.Cells[string.Format("G{0}", row)].Style.Numberformat.Format = "dd-MM-yyyy HH:mm:ss";
                Sheet.Cells[string.Format("H{0}", row)].Value = item.ComplaintStatusDescription;
                Sheet.Cells[string.Format("I{0}", row)].Value = item.ComplaintLocationDescription;
                Sheet.Cells[string.Format("J{0}", row)].Value = item.ComplaintCommets;

                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + $"{reportName}.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }

        private IQueryable<Report> GetAllComplaints()
        {
            return from c in db.Complaints
                   join ct in db.ComplaintTypes on c.ComplaintTypeID equals ct.ComplaintTypeID
                   join cp in db.ComplaintProducts on c.ComplaintProductID equals cp.ComplaintProductID
                   join cl in db.ComplaintLocations on c.ComplaintLocationID equals cl.ComplaintLocationID
                   join cs in db.ComplaintStatus on c.ComplaintStatusID equals cs.ComplaintStatusID
                   join cu in db.AspNetUsers on c.UserID equals cu.Id
                   select new Report
                   {
                       ComplaintID = c.ComplaintID,
                       ComplaintTypeDescription = ct.ComplaintTypeDescription,
                       ComplaintTitle = c.ComplaintTitle,
                       ComplaintDescription = c.ComplaintDescription,
                       Email = cu.Email,
                       ComplaintProductDescription = cp.ComplaintProductDescription,
                       ComplaintDate = c.ComplaintDate,
                       ComplaintStatusDescription = cs.ComplaintStatusDescription,
                       ComplaintLocationDescription = cl.ComplaintLocationDescription,
                       ComplaintCommets = c.ComplaintCommets
                   };
        }
    }
}