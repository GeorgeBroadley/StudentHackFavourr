using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DatabaseSingleton
    {
        static DatabaseSingleton DBInstance;

        private static string cur_email;
        private static MySqlConnection connection;

        private DatabaseSingleton()
        {
            
            string server = "helios.csesalford.com";
            string database = "stc905_favourr";
            string uid = "stc905";
            string password = "turtlebrainholocaust";
            connection = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";");
        }

        public static DatabaseSingleton getInstance()
        {
            if(DBInstance==null)
            {
                DBInstance = new DatabaseSingleton();
            }
            return DBInstance;
        }

        public static void setEmail(string email)
        {
            cur_email = email;
        }
        public string getEmail()
        {
            return cur_email;
        }

        public string Login(string email, string password)
        {
            string r;
            if (OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(null, connection);
                command.CommandText = "SELECT email FROM user WHERE email=@email AND password=@password";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    String e = reader.GetString("email");
                    //System.Diagnostics.Debug.WriteLine(e);
                    setEmail(e);
                    r = e;
                }
                else
                {
                    r = "credfail";
                }
            }
            else
            {
                r = "confail";
            }
            CloseConnection();
            return r;
        }

        public string Register(string email, string password, string address, string postcode, string name)
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
            if (OpenConnection())
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
                    dataReader.Close();
                    CloseConnection();
                    if (OpenConnection())
                    {
                        command.Prepare();
                        command.ExecuteNonQuery();
                        r = "success";
                    }else
                    {
                        r = "2noncon";
                    }
                }
                else
                {
                    r = "existingemail";
                }

                //close connection
                CloseConnection();
                return r;
            }
            else
            {
                return "noncon";
            }
        }

        public List<string>[] Select()
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
            if (OpenConnection() == true)
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
                foreach (List<string> l in list)
                {
                    foreach (string s in l)
                    {
                        System.Diagnostics.Debug.WriteLine(s);
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        private static bool CloseConnection()
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

        private static bool OpenConnection()
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

        public void con()
        {
            System.Diagnostics.Debug.WriteLine(" please output: " + Register("kyle@me.com", "supersecure123", "streetplace", "lll111", "guesswho"));
            Select();
            System.Diagnostics.Debug.WriteLine(Login("not", "right"));
            System.Diagnostics.Debug.WriteLine(Login("kyle@me.com", "not"));
            System.Diagnostics.Debug.WriteLine(Login("kyle@me.com", "supersecure123"));
        }
    }
}