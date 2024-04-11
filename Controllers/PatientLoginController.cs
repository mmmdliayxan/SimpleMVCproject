using MVCprojectHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCprojectHealthCare.Controllers
{
    public class PatientLoginController : Controller
    {
        public ActionResult Index(PatientLogin pl)
        {
            string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connection);
            string sqlQuery = "select email,password from [dbo].[patients] where email=@email and password=@password";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
            if (pl.Email != null)
            {
                cmd.Parameters.AddWithValue("@email", pl.Email);
            }
            else
            {
                cmd.Parameters.AddWithValue("@email", DBNull.Value);
            }
            if (pl.Email != null)
            {
                cmd.Parameters.AddWithValue("@password", pl.Password);
            }
            else
            {
                cmd.Parameters.AddWithValue("@password", DBNull.Value);
            }

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["email"] = pl.Email.ToString();
                return RedirectToAction("welcome");
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed";
            }
            sqlConnection.Close();
            return View();
        }
        public ActionResult welcome()
        {
            return View();

        }
    }
}