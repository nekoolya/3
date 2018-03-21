using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Uppgift3
{
    class Program
    {
        static void Main(string[] args)
        {
            City Amsterdam = new City("null", 0, 0, 0, 0, 0); // object
            City Boston = new City("null", 0, 0, 0, 0, 0); // object
            City Barcelona = new City("null", 0, 0, 0, 0, 0); // object

            City[] stader = new City[]
            {
                new City("Amsterdam",0,0,0,0,0),
                new City("Barcelona",0,0,0,0,0),
                new City("Boston",0,0,0,0,0),
                };

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=LAPTOP-OBD0K6JL;Initial Catalog=airbnbtest;Integrated Security=True";
           
            string[] lista = new string[] { "Amsterdam2", "Boston2", "Barcelona2" };

            for (int i = 0; i < 3; i++)
            {
                string bigCity= lista[i];

            try

            {
                conn.Open();

                SqlCommand myQuery = new SqlCommand("SELECT * FROM " + bigCity, conn); //same name as in Boston2 i SQL
                SqlDataReader myReader = myQuery.ExecuteReader();

                while (myReader.Read())

                {

                    int host_id = (int)myReader["host_id"];  // Reading all variables from database.
                    string room_type = (string)myReader["room_type"].ToString();
                    int room_id = (int)myReader["room_id"];
                    string borough; //= (string)myReader["borough"];

                    if (myReader["borough"] is String)
                    {

                        borough = (string)myReader["borough"];
                    }

                    else

                    {

                        borough = "";
                    }

                    string neighborhood = (string)myReader["neighborhood"];
                    int reviews = (int)myReader["Reviews"];

                    string var1 = (string)myReader["Overall_satisfaction"];
                    double Overall_satisfaction;
                    double.TryParse(var1, out Overall_satisfaction); //Overall_satisfaction får värdet som skickas ut i out
                    int accomodates = (int)myReader["accommodates"];

                    var1 = (string)myReader["Bedrooms"];
                    double d_bedrooms;
                    double.TryParse(var1, out d_bedrooms);
                    int bedrooms = (int)Math.Round(d_bedrooms);

                    var1 = (string)myReader["Price"];
                    double d_price;
                    double.TryParse(var1, out d_price);
                    int price = (int)Math.Round(d_price);

                    var1 = myReader["minstay"].ToString();
                    double m_minstay;
                    double.TryParse(var1, out m_minstay);
                    int minstay = (int)Math.Round(m_minstay);

                    var1 = (string)myReader["latitude"];
                    double l_latitude;
                    double.TryParse(var1, out l_latitude);
                    int latitude = (int)Math.Round(l_latitude);

                    var1 = (string)myReader["Longitude"];
                    double l_longitude;
                    double.TryParse(var1, out l_longitude);
                    int longitude = (int)Math.Round(l_longitude);
                
                    string last_modified = (string)myReader["last_modified"].ToString();

                    Accommondation getAccommondation = new Accommondation(room_id, host_id, room_type, borough, neighborhood, reviews, Overall_satisfaction,
                    accomodates, bedrooms, price, minstay, latitude, longitude, last_modified);
                        stader[i].addAccomm(getAccommondation);
                       // Amsterdam.addAccomm(getAccommondation);

                 
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                conn.Close();
                
                Console.ReadLine();
            }

        }
        }
        //method 


        public static void GetAllAccomodations(SqlConnection conn)
            {

                SqlCommand myQuery = new SqlCommand("SELECT * FROM Boston2", conn);   // Same query name as in Boston2 in SQL.
                SqlDataReader myReader = myQuery.ExecuteReader();
                List<Accommondation> accomList = new List<Accommondation>();
                 

            }

        }


    }

    