using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
namespace TMFadmin.Models
{
    public class SettingsManager {
        //private string connectionString = "Server=localhost;Database=tmf-capstone;Uid=fuzzbox;Pwd=threejams;SslMode=none;";
        
        private string connectionString = "Server=localhost;Database=dbTMF;Uid=root;Pwd=;SslMode=none;";
        private MySqlConnection dbConnection;
        private MySqlCommand dbCommand;
		private MySqlDataReader dbReader;
		private HttpContext context;
        public string currentUser {get; set;}
        public List<string> users {get; set;}
        public List<int> userIds {get; set;}
        public List<string> userRoles {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        public string role {get; set;}
        public int userId {get; set;}
        //get the user info
        public void getUsers(HttpContext myHttpContext) {
            context = myHttpContext;
            currentUser = context.Session.GetString("user");
            users = new List<string>();
            userRoles = new List<string>();
            userIds = new List<int>();
            try {
				dbConnection = new MySqlConnection(connectionString);
				dbConnection.Open();
				dbCommand = new MySqlCommand("SELECT * FROM login", dbConnection);
				dbReader = dbCommand.ExecuteReader();
				//username exists?
				if (!dbReader.HasRows) {
					dbConnection.Close();
				} else {
                    while(dbReader.Read()) {
                        userIds.Add(Convert.ToInt32(dbReader["id"]));
                        users.Add(dbReader["username"].ToString());
                        userRoles.Add(dbReader["role"].ToString());
                    }
                }
			} finally {
				dbConnection.Close();
			}
        }
        public void getUser(HttpContext myHttpContext, int id) {
            context = myHttpContext;
            try {
				dbConnection = new MySqlConnection(connectionString);
				dbConnection.Open();
				dbCommand = new MySqlCommand("SELECT role, username FROM login WHERE id=?id", dbConnection);
                dbCommand.Parameters.AddWithValue("?id", id);
				dbReader = dbCommand.ExecuteReader();
				if (!dbReader.HasRows) {
                    Console.WriteLine("\n\n\nFailed!");
					dbConnection.Close();
				} else {
                    dbReader.Read();
                    userId = id;
                    username = dbReader["username"].ToString();
                    role = dbReader["role"].ToString();
                }
				
                
			} finally {
				dbConnection.Close();
			}
        }
        public void updateUser(HttpContext myHttpContext, int id) {
            context = myHttpContext;
            Console.WriteLine("\n\n\nid: " + id);
            Console.WriteLine("\n\n\nUsername: " + username);
            Console.WriteLine("\n\n\nRole: " + role);
            Console.WriteLine("\n\n\nPassword: " + password);
            try {
				dbConnection = new MySqlConnection(connectionString);
				dbConnection.Open();
                if (password == "" || password == null) {
                    //update everything but password
                    dbCommand = new MySqlCommand("Update login SET username=?username, role=?role WHERE id=?id", dbConnection);
                }
				else {
                    //update password
                    WebLogin webLogin = new WebLogin(connectionString, context);
                    string salt = webLogin.getMySalt();
                    string hash = webLogin.changePassword(password, salt);
                    dbCommand = new MySqlCommand("Update login SET username=?username, role=?role, password=?password, salt=?salt WHERE id=?id", dbConnection);
                    dbCommand.Parameters.AddWithValue("?password", hash);
                    dbCommand.Parameters.AddWithValue("?salt", salt);
                }
                dbCommand.Parameters.AddWithValue("?id", id);
                dbCommand.Parameters.AddWithValue("?username", username);
                dbCommand.Parameters.AddWithValue("?role", role);
				dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();
			} finally {
				dbConnection.Close();
			}

        }
        public void addUser(HttpContext myHttpContext) {
            context = myHttpContext;
            WebLogin webLogin = new WebLogin(connectionString, context);
            webLogin.password = password;
            string salt = webLogin.getMySalt();
            string hash = webLogin.addUser(salt);
            try {
				dbConnection = new MySqlConnection(connectionString);
				dbConnection.Open();
                dbCommand = new MySqlCommand("INSERT INTO login (username,role,password,salt) VALUES (?username,?role,?password,?salt)", dbConnection);
                dbCommand.Parameters.AddWithValue("?password", hash);
                dbCommand.Parameters.AddWithValue("?salt", salt);    
                dbCommand.Parameters.AddWithValue("?username", username);
                dbCommand.Parameters.AddWithValue("?role", role);
				dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();
			} finally {
				dbConnection.Close();
			}
        }
        public bool delete(int id) {
            if (id == 0) {
                return false;
            } else {
                try {
                    // open connection
                    dbConnection = new MySqlConnection(connectionString);
                    dbConnection.Open();
                    string sqlString = "DELETE FROM login WHERE id = ?id";
                    // Populate Command Object
                    dbCommand = new MySqlCommand(sqlString,dbConnection);
                    dbCommand.Parameters.AddWithValue("?id", id);
                    dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                } finally {
                    dbConnection.Close();
                }
                return true;
            }
        }
    }
}