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

        public int getPoint(string email)
        {
            int point = 0;
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText =
           "SELECT point FROM user WHERE email=@email";
            command.Parameters.AddWithValue("@email", email);
            if (OpenConnection() == true)
            {
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    point = reader.GetInt32("point");

                }
                reader.Close();
                CloseConnection();
            }
            return point;
        }

        public void changePoint(string email,int num)
        {
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText =
           "UPDATE user SET point=@point WHERE email=@email";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@point", getPoint(email)+num);
            //open connection
            if (OpenConnection() == true)
            {
                command.Prepare();
                command.ExecuteNonQuery();
                //close connection
                CloseConnection();
            }
        }

        public string getCurCounty()
        {
            string r = "";
            MySqlCommand cmd = new MySqlCommand(null, connection);
            cmd.CommandText = "SELECT county FROM user WHERE email=@email";
            cmd.Parameters.AddWithValue("@email", cur_email);
            if (OpenConnection())
            {
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();;
                if (reader.Read())
                {
                    r = reader.GetString("county");
                    
                }
                else
                {
                    r = "nocounty";
                }
                CloseConnection();
            }else
            {
                r = "noncon";
            }
            return r;
        }

        public string CreateFavour(string email, string favourname, int claimed, string category, string description, string claimed_by)
        {
            
                MySqlCommand command = new MySqlCommand(null, connection);
                command.CommandText =
               "INSERT INTO favour VALUES (@email, @favourname, @claimed, @category, @description, @claimed_by, @county)";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@favourname", favourname);
                command.Parameters.AddWithValue("@claimed", claimed);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@claimed_by", claimed_by);
                command.Parameters.AddWithValue("@county", getCurCounty());

                //open connection
                if (OpenConnection() == true)
                {
                    String r = "success";
                    command.Prepare();
                    r = command.ExecuteNonQuery().ToString();
                    //close connection
                    CloseConnection();
                    return r;
                }
                else
                {
                    return "noncon";
                }
            

           
        }

        public List<string>[] DisplayFavours()
        {
            string query = "SELECT favourname, description, category, email FROM favour WHERE claimed=0";
            return parseSql(query);
        }
        public List<string>[] DisplayCountyFavours(string county)
        {
            string query = "SELECT favourname, description, category, email FROM favour WHERE claimed=0 AND county='"+county+"'";
            return parseSql(query);
        }
        public List<string>[] DisplayCatFavours(string county,string cat)
        {
            string query = "SELECT favourname, description, category, email FROM favour WHERE claimed=0 AND category='" + cat + "'";
            if (county != "All")
            {
                query += "AND county = '" + county + "'";
            }
            return parseSql(query);
        }
        
        private List<string>[] parseSql(string query)
        {
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

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
                    list[0].Add(dataReader.GetString("favourname"));
                    list[1].Add(dataReader.GetString("description"));
                    list[2].Add(dataReader.GetString("category"));
                    list[3].Add(dataReader.GetString("email"));
                }

                System.Diagnostics.Debug.WriteLine("Enter loop de loop");
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
        public List<string>[] CurrentUserFavours()
        {
            string query = "SELECT favourname, description, category FROM favour WHERE email=@cur_email";

            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@cur_email", cur_email);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine(dataReader.FieldCount);
                // System.Diagnostics.Debug.WriteLine(dataReader.);
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader.GetString("favourname"));
                    list[1].Add(dataReader.GetString("description"));
                    list[2].Add(dataReader.GetString("category"));
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

        public List<string> getUserDetails()
        {
            string query = "SELECT fullname, address, postcode FROM user WHERE email='"+DatabaseSingleton.getInstance().getEmail()+"'";

            List<string> list = new List<string>();

            //Open connection
            if (OpenConnection())
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
                    list.Add(dataReader.GetString("fullname"));
                    list.Add(dataReader.GetString("address"));
                    list.Add(dataReader.GetString("postcode"));
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

        public List<UserData> getUserLeaders()
        {
            string query = "SELECT fullname, email, point, county FROM user WHERE point > 0 ORDER BY point DESC";

            List<UserData> list = new List<UserData>();

            //Open connection
            if (OpenConnection())
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
                    list.Add(new UserData(dataReader.GetString("fullname"), dataReader.GetString("email"), dataReader.GetString("county"), dataReader.GetInt32("point")));
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

        public List<string>[] displayClaimedFavours()
        {
            string query = "SELECT favourname, description, category FROM favour WHERE claimed_by=@email";

            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            //Open connection
            if (OpenConnection() == true && cur_email != null)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(null, connection);
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@email", cur_email);
                cmd.Prepare();
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine(dataReader.FieldCount);
                // System.Diagnostics.Debug.WriteLine(dataReader.);
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader.GetString("favourname"));
                    list[1].Add(dataReader.GetString("description"));
                    list[2].Add(dataReader.GetString("category"));
                    list[3].Add(dataReader.GetString("claimed_by"));
                }
                foreach (List<string> l in list)
                {
                    foreach (string s in l)
                    { System.Diagnostics.Debug.WriteLine(s); }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            { return list; }
        }

        public bool favourExists(string email, string favourname)
        {
            bool r = false;
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText =
           "SELECT favourname FROM favour WHERE email=@email AND favourname=@favourname";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@favourname", favourname);
            if (OpenConnection())
            {
                command.Prepare();
                MySqlDataReader reader =  command.ExecuteReader();
                if (reader.Read())
                {
                    r= true;
                }
            }
            CloseConnection();
            return r;
        }

        public string claimFavour(string email, string favourname, bool myLock)
        {
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText =
           "UPDATE favour SET claimed=1, claimed_by=@claimed_by WHERE email=@email AND favourname=@favourname";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@favourname", favourname);
            command.Parameters.AddWithValue("@claimed_by", cur_email);
            //open connection
            if (OpenConnection() == true)
            {
                String r = "success";
                command.Prepare();
                command.ExecuteNonQuery();
                //close connection
                CloseConnection();
                changePoint(cur_email,1);
                changePoint(email, -1);
                return r;
            }
            else
            {
                return "noncon";
            }
        }

        public static void setEmail(string email)
        {
            cur_email = email;
        }
        public string getEmail()
        {
            return cur_email;
        }

        public string getUserWelcome()
        {
            string r;
            if (OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(null, connection);
                command.CommandText = "SELECT fullname, address FROM user WHERE email=@email";
                command.Parameters.AddWithValue("@email", cur_email);
                command.Prepare();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    String e = "Hello " + reader.GetString("fullname") + " at " + reader.GetString("address");
                    r = e;
                }
                else
                {
                    r = "There was a problem verifying your email try loging in again.";
                }
            }
            else
            {
                r = "There was a problem with our server, please contact our maintanance team: wewilldifinetlyfixthat@lies.com";
            }
            CloseConnection();
            return r;
        }


        public string DeleteFavour(string favourname)
        {
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText =
           "DELETE FROM favour WHERE email=@email AND favourname=@favourname";
            command.Parameters.AddWithValue("@favourname", favourname);
            command.Parameters.AddWithValue("@email", cur_email);
            //open connection
            if (OpenConnection() == true)
            {
                String r = "success";
                command.Prepare();
                command.ExecuteNonQuery();
                //close connection
                CloseConnection();
                return r;
            }
            else
            {
                return "noncon";
            }
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

        public void Logout()
        {
            cur_email = null;
        }

        public string editDetails(string name, string address, string postcode)
        {
            if (name != null && address != null && postcode != null)
            {
                MySqlCommand cmd = new MySqlCommand(null, connection);
                cmd.CommandText =
                "UPDATE user SET fullname=@name, address = @address, postcode=@postcode WHERE email=@cur_email";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@postcode", postcode);
                cmd.Parameters.AddWithValue("@cur_email", cur_email);

                if (OpenConnection())
                {
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine("successfully updated details");
                    CloseConnection();
                    return "success";
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("failed to update details");
                    return "fail";
                }
            }
            else
            {
                return "args err";
            }
        }

        public string Register(string email, string password, string address, string postcode, string name, string county)
        {
            MySqlCommand command = new MySqlCommand(null, connection);
            command.CommandText =
           "INSERT INTO user VALUES (@email, @fullname, @address, @point, @postcode, @password, @county)";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@fullname", name);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@point", 0);
            command.Parameters.AddWithValue("@postcode", postcode);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@county", county);

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
                        cur_email = email;
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
    }
}