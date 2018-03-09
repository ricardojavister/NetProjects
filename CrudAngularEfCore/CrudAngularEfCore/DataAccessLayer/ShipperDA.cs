using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CrudAngularEfCore.Models

namespace CrudAngularEfCore.DataAccessLayer
{
    public class ShipperDA
    {
        string connectionString = "Put Your Connection string here";
        //To View all employees details  
        public IEnumerable<Shipper> GetAllShipper()
        {
            try
            {
                List<Shipper> lstemployee = new List<Shipper>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllShipper", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Shipper shipper = new Shipper();

                        shipper.ShipperID = Convert.ToInt32(rdr["ShipperID"]);
                        shipper.CompanyName = rdr["CompanyName"].ToString();
                        shipper.Phone = rdr["Phone"].ToString();
                        
                        lstemployee.Add(shipper);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record   
        public int AddShipper(Shipper shipper)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertShipper", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CompanyName", shipper.CompanyName);
                    cmd.Parameters.AddWithValue("@Phone", shipper.Phone);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee  
        public int UpdateShipper(Shipper shipper)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateShipper", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ShipperID", shipper.ShipperID);
                    cmd.Parameters.AddWithValue("@CompanyName", shipper.CompanyName);
                    cmd.Parameters.AddWithValue("@Phone", shipper.Phone);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee  
        public Shipper GetShipper(int id)
        {
            try
            {
                Shipper employee = new Shipper();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetShipperByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ShipperID", id);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.ShipperID = Convert.ToInt32(rdr["ShipperID"]);
                        employee.CompanyName = rdr["CompanyName"].ToString();
                        employee.Phone = rdr["Phone"].ToString();
                    }
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular employee  
        public int DeleteShipper(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteShipper", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ShipperID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

    }
}
