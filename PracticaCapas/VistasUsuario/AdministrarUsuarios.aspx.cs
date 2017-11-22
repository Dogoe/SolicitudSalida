using Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaCapas.VistasUsuario
{
    public partial class AdministrarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDummyRow();
            }
            /*if(!IsPostBack)
            {
                N_Usuario nUsuario = new N_Usuario();
                DataSet datosLista = nUsuario.ListaUsuarioUabc();
                if (datosLista.Tables.Count > 0)
                {
                    GridView1.DataSource = datosLista;
                    GridView1.DataBind();
                    Console.Out.Write(datosLista);
                }
                else
                {
                    msj.Text = "Ocurrio un error al intentar cargar los datos de la base de datos.";
                }

            }*/

        }
        //------------------------------------------------
        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("Id");
            dummy.Columns.Add("Correo");
            dummy.Columns.Add("Id_Rol");
            dummy.Rows.Add();
            gvUsuario.DataSource = dummy;
            gvUsuario.DataBind();
        }
        //------------------------------------
        [WebMethod]
        public static string GetUsuario()
        {
            string query = "SELECT Id, Correo, Id_Rol FROM Usuario";
            SqlCommand cmd = new SqlCommand(query);
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        return ds.GetXml();
                    }
                }
            }
        }

        /*[WebMethod]
        public static bool CrearUsuario(string Correo, int Id_Rol)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            try
            {
                //dbSS.AbrirConexion();
                //cmd.Connection = dbSS.Conexion;
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[abcUsuario]";


                cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
                cmd.Parameters.AddWithValue("@Id", -1);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@Id_Rol", Id_Rol);
                //int Id = Convert.ToInt32(cmd.ExecuteScalar());

                dr = cmd.ExecuteReader();

                if (dr.RecordsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error al solicitar los datos del Usuario ", e);
            }
            finally
            {
                //dbSS.CerrarConexion();
                con.Close();
                cmd.Dispose();

            }
            //-------------------
        }*/
        //--------------------------
        [WebMethod]
        public static void UpdateCustomer(int Id, string Correo, int Id_Rol)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Correo = @Correo, Id_Rol = @Id_Rol WHERE Id = @Id"))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.Parameters.AddWithValue("@Id_Rol", Id_Rol);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        [WebMethod]
        public static void DeleteCustomer(int Id)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE Id = @Id"))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}