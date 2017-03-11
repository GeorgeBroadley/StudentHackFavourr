using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            con();
        }

        public string Login(MySqlConnection connection, string email, string password)
        {
            string r;
            if (OpenConnection(connection)){
                MySqlCommand command = new MySqlCommand(null, connection) ;
                command.CommandText = "SELECT email FROM user WHERE email=@email AND password=@password";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    String e = reader.GetString("email");
                    //System.Diagnostics.Debug.WriteLine(e);
                    r=e;
                }else
                {
                    r="credfail";
                }
            }else
            {
                r="confail";
            }
            CloseConnection(connection);
            return r;
        }

        public string Register(MySqlConnection connection, string email, string password, string address, string postcode, string name)
        {
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText =
           "INSERT INTO user VALUES (@email, @fullname, @address, @point, @postcode, @password)";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@fullname", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@point", 0);
            command.Parameters.AddWithValue("@postcode", postcode);
            command.Parameters.AddWithValue("@password", password);

            //open connection
            if (OpenConnection(connection) == true)
            {
                MySqlCommand cmd = new MySqlCommand(null, connection);
                cmd.CommandText = "SELECT email FROM user WHERE email=@email";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Prepare();
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                string r;
                if (!dataReader.Read())
                {
                    command.Prepare();
                    r = "success";
                }
                else
                {
                    r = "existingemail";
                }

                //close connection
                CloseConnection(connection);
                return r;
            }
            else
            {
                return "noncon";
            }
        }

        public List<string>[] Select(MySqlConnection connection)
        {
            string query = "SELECT * FROM user";

            //Create a list to store the result
            List<string>[] list = new List<string>[6];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();

            //Open connection
            if (OpenConnection(connection) == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine(dataReader.FieldCount);
               // System.Diagnostics.Debug.WriteLine(dataReader.);
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader.GetString("email"));
                    list[1].Add(dataReader.GetString("fullname"));
                    list[2].Add(dataReader.GetString("address"));
                    list[3].Add(dataReader.GetString("point"));
                    list[4].Add(dataReader.GetString("postcode"));
                    list[5].Add(dataReader.GetString("password"));
                }
                foreach(List<string> l in list)
                {
                    foreach (string s in l) {
                        System.Diagnostics.Debug.WriteLine(s);
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection(connection);

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        private bool CloseConnection(MySqlConnection connection)
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private bool OpenConnection(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Con opened");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        System.Diagnostics.Debug.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        System.Diagnostics.Debug.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con();
        }

        public void con()
        {
            var server = "helios.csesalford.com";
            var database = "stc905_favourr";
            var uid = "stc905";
            var password = "turtlebrainholocaust";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            var connection = new MySqlConnection(connectionString);
            System.Diagnostics.Debug.WriteLine(" please output: " + Register(connection, "kyle@me.com", "supersecure123", "streetplace", "lll111", "guesswho"));
            Select(connection);
            System.Diagnostics.Debug.WriteLine(Login(connection, "not", "right"));
            System.Diagnostics.Debug.WriteLine(Login(connection, "kyle@me.com", "not"));
            System.Diagnostics.Debug.WriteLine(Login(connection, "kyle@me.com", "supersecure123"));
        }
    }
}