using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewRecord(string Firstname, string MiddleName, string Lastname, string Mobile, string Email, string Pancard, string Pincode, string Amount)
        {
            if (MiddleName == null)
            {
                MiddleName = " NULL ";
            }
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-LMQ0KHGA;Initial Catalog=MyDb;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False;"))
                {
                    con.Open();

                    // Declare and initialize the SqlCommand object with parameters
                    string query = "INSERT INTO [Dta] (Firstname, Midname, Lastname, Mobile, Email, Pancard, Pincode, Amount) " +
                                   "VALUES (@Firstname, @Midname, @Lastname, @Mobile, @Email, @Pancard, @Pincode, @Amount)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    // cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Midname", MiddleName);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Pancard", Pancard);
                    cmd.Parameters.AddWithValue("@Pincode", Pincode);
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(Amount));

                    cmd.ExecuteNonQuery();

                    con.Close();

                    TempData["Message"] = "Data inserted successfully.";
                    return RedirectToAction("Ram", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error: " + ex.Message;
                return RedirectToAction("Ram", "Home");
            }

        }
        public IActionResult Ram()
        {
            List<MyDbModel> list = new List<MyDbModel>();
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-LMQ0KHGA;Initial Catalog=MyDb;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False;"))
                {
                    con.Open();

                    string query = "select * from [Dta] ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    MyDbModel model;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model = new MyDbModel();
                            model.Id = int.Parse(reader[0].ToString());
                            model.Firstname = reader[1].ToString();
                            model.Middlename = reader[2].ToString();
                            model.Lastname = reader[3].ToString();
                            model.Mobile = reader[4].ToString();
                            model.Email = reader[5].ToString();
                            model.Pancard = reader[6].ToString();
                            model.Pincode = reader[7].ToString();
                            model.Amount = Convert.ToDecimal(reader[8].ToString());
                            list.Add(model);
                        }
                    }
                    reader.Close();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
            }

            return View(list);
        }

    }

}

 

