using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebEmoloye.MVC.Models;

namespace WebEmoloye.MVC.Controllers
{
    public class EmploieController : Controller
    {
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmploieDataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // GET: Emploie
        [HttpGet]
        public ActionResult Index()
        {
            DataTable TableEMP = new DataTable();
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * From TableEMP";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                sqlData.Fill(TableEMP);
            }

            return View(TableEMP);
        }
       


        // GET: Emploie/Create
        public ActionResult Create()
        {
            var listb = new List<string>() { "java", "c#", "js", "php" };
            ViewBag.listb = listb;
            var lista = new List<string>() { "A111", "B255", "R366", "R556" };
            ViewBag.lista = lista;
            return View(new EmoloieModel());

           
        }

        // POST: Emploie/Create
        [HttpPost]
        public ActionResult Create(EmoloieModel emp)
        {
            
           
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Insert into TableEMP Values(@EmploieId,@EmploieId,@Name,@Age,@Sen,@section,@position,@Adress,@Tel,@Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmploieId", emp.EmoloieId);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", DateTime.Now.Year-emp.DOB.Year);
                cmd.Parameters.AddWithValue("@Sen", DateTime.Now.Year-emp.DOS.Year);
                cmd.Parameters.AddWithValue("@section", emp.Section);
                cmd.Parameters.AddWithValue("@position", emp.Position);
                cmd.Parameters.AddWithValue("@Adress", emp.Adress);
                cmd.Parameters.AddWithValue("@Tel", emp.Telephon);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: Emploie/Edit/5
        public ActionResult Edit(int id)
        {
              var listb = new List<string>() { "java", "c#", "js", "php" };
            ViewBag.listb = listb;
            var lista = new List<string>() { "A111", "B255", "R366", "R556" };
            ViewBag.lista = lista;
            DataTable TableEMP = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * From TableEMP where EmploieId=@EmploieId";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                sqlData.SelectCommand.Parameters.AddWithValue("@EmploieId", id);
                sqlData.Fill(TableEMP);
                EmoloieModel me = new EmoloieModel();
                if (TableEMP.Rows.Count == 1)
                {
                    me.EmoloieId = Convert.ToInt32(TableEMP.Rows[0][1].ToString());
                    me.Name = TableEMP.Rows[0][2].ToString();
                    //me.DOB = Convert.ToDateTime((DateTime.Now.Year - (TableEMP.Rows[0][3])) / 01 / 01).ToString();
                    //me.DOS = Convert.ToDateTime((me.DOS).ToString());
                    me.Adress = TableEMP.Rows[0][7].ToString();
                    me.Telephon = TableEMP.Rows[0][8].ToString();
                    me.Email = TableEMP.Rows[0][9].ToString();
                    me.Section = TableEMP.Rows[0][5].ToString();
                    me.Position = TableEMP.Rows[0][6].ToString();
                    return View(me);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }

            
        }

        // POST: Emploie/Edit/5
        [HttpPost]
        public ActionResult Edit(EmoloieModel em)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "UpDate TableEMP Set EmploieId=@EmploieId,Name= @Name,Age= @Age,Sen= @Sen,Section= @section," +
                    "Position= @position,Adress= @Adress,Tel= @Tel,Email= @Email where EmploieId=@EmploieId ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmploieId", em.EmoloieId);
                cmd.Parameters.AddWithValue("@Name", em.Name);
                cmd.Parameters.AddWithValue("@Age", DateTime.Now.Year - em.DOB.Year);
                cmd.Parameters.AddWithValue("@Sen", DateTime.Now.Year - em.DOS.Year);
                cmd.Parameters.AddWithValue("@section", em.Section);
                cmd.Parameters.AddWithValue("@position", em.Position);
                cmd.Parameters.AddWithValue("@Adress", em.Adress);
                cmd.Parameters.AddWithValue("@Tel", em.Telephon);
                cmd.Parameters.AddWithValue("@Email", em.Email);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: Emploie/Delete/5
        public ActionResult Delete(int id)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Delete From TableEMP where EmploieId =@EmploieId";
                
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmploieId", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

       
    }
}
