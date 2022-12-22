// using Microsoft.AspNetCore.Mvc;
// using MySql.Data.MySqlClient;
// using Newtonsoft.Json;
// using newCubeBackend.Connection;
// using System.Data;
// using newCubeBackend.UserModel;


// // Define name of space. 
// namespace newCubeBackend.CustomerOrderControllers
// {
//     // method Route it's the link of API endpoint.
//     [Route("api/CustomerOrder")]
//     [ApiController]
//     // Creating a child class UserController of ControllerBase
//     public class CustomerOrderController : ControllerBase
//     {
//         private readonly IConfiguration _configuration;
//         public CustomerOrderController(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }

//         // This method it's used for requests HTTP of type Get.
//         [HttpGet]
//         public String Get()
//         {
//             // Create query in string with SQL command inside.
//             string query = "SELECT * FROM customerOrder";

//             // Create object table with the method new DataTable() of type DataTable.
//             DataTable table = new DataTable();
//             // Create object named myReader of type MySqlDataReader. This method myReader it's used after.
//             MySqlDataReader myReader;
//             // Create connection nammed conn of MySqlConnection. he use DBConnect.GetDBConnection(). this method it's Define on ../Controllers/DBConnect.cs
//             MySqlConnection conn = DBConnect.GetDBConnection();

//             // Open the conn define line above
//             conn.Open();

//             // Create the variable cmd of type MySqlCommand. He create a new MySqlCommand with paramaters the query (it's the SQL command define above) and (conn it's the connection of DB).
//             // For use MySqlCommand, you need to use using MySql.Data.MySqlClient; at up of the file.
//             MySqlCommand cmd = new MySqlCommand(query, conn);

//             //  With myReader use cmd define above for ExecuteReader(); 
//             myReader = cmd.ExecuteReader();
//             // From table load the data of myReader.
//             table.Load(myReader);

//             // After have Load the data in table we can close the reader and the conn.
//             myReader.Close();
//             conn.Close();

//             // Use JsonConvert.SerializeObject() for the module Newtonsoft.Json; with parameter table define above and Formatting.Indented it's for do not see line of data.
//             // this method it's save in json of type string
//             string json = JsonConvert.SerializeObject(table, Formatting.Indented);

//             // return it's the last command of the method Get(). he return the json define above.
//             return json;
//         }


//         [HttpGet("{id}")]
//         public String GetById(int id)
//         {
//             string query = "SELECT * FROM customerOrder WHERE id = @Id";

//             DataTable table = new DataTable();
//             MySqlDataReader myReader;
//             MySqlConnection conn = DBConnect.GetDBConnection();

//             conn.Open();
//             MySqlCommand cmd = new MySqlCommand(query, conn);

//             cmd.Parameters.AddWithValue("@Id", id);

//             myReader = cmd.ExecuteReader();
//             table.Load(myReader);

//             myReader.Close();
//             conn.Close();

//             string json = JsonConvert.SerializeObject(table, Formatting.Indented);

//             return json;
//         }

//         [HttpPost]
//         public JsonResult Post(User user)
//         {
//             // string query = @"INSERT INTO cubeSQL.userTable(authMail, authPassword) VALUES(@Mail, @Password)";
//             string query = @"INSERT INTO cubeSQL.customerOrder(first_name, last_name, email, user_password, address, postal_code, town, phone_number, admin) 
//                             VALUES (@FirstName, @LastName, @Email, @UserPassword, @Address, @PostalCode, @Town, @PhoneNumber, @Admin)";

//             DataTable table = new DataTable();
//             MySqlDataReader myReader;
//             MySqlConnection conn = DBConnect.GetDBConnection();

//             conn.Open();
//             MySqlCommand cmd = new MySqlCommand(query, conn);

//             cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
//             cmd.Parameters.AddWithValue("@LastName", user.LastName);
//             cmd.Parameters.AddWithValue("@Email", user.Email);
//             cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
//             cmd.Parameters.AddWithValue("@Address", user.Address);
//             cmd.Parameters.AddWithValue("@PostalCode", user.PostalCode);
//             cmd.Parameters.AddWithValue("@Town", user.Town);
//             cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
//             cmd.Parameters.AddWithValue("@Admin", user.Admin);

//             myReader = cmd.ExecuteReader();
//             table.Load(myReader);

//             myReader.Close();
//             conn.Close();

//             return new JsonResult("Added Successfully");
//         }

//         [HttpDelete("{id}")]
//         public JsonResult Delete(int id)
//         {
//             string query = @"delete from userTable where id = @Id;";

//             DataTable table = new DataTable();
//             MySqlDataReader myReader;
//             MySqlConnection conn = DBConnect.GetDBConnection();

//             conn.Open();
//             MySqlCommand cmd = new MySqlCommand(query, conn);

//             cmd.Parameters.AddWithValue("@Id", id);

//             myReader = cmd.ExecuteReader();
//             table.Load(myReader);

//             myReader.Close();
//             conn.Close();

//             return new JsonResult("Deleted Successfully");
//         }

//         [HttpPut("{id}")]
//         public JsonResult Put(int id, User user)
//         {
//             var sql = @"UPDATE userTable
//                         SET first_name = @FirstName,  
//                         last_name = @LastName, 
//                         email = @Email, 
//                         user_password = @Password, 
//                         address = @Address, 
//                         postal_code = @PostalCode, 
//                         town = @Town, 
//                         phone_number = @PhoneNumber 
//                         WHERE id = @Id";

//             DataTable table = new DataTable();
//             MySqlDataReader myReader;
//             MySqlConnection conn = DBConnect.GetDBConnection();

//             conn.Open();
//             MySqlCommand cmd = new MySqlCommand(sql, conn);

//             cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
//             cmd.Parameters.AddWithValue("@LastName", user.LastName);
//             cmd.Parameters.AddWithValue("@Email", user.Email);
//             cmd.Parameters.AddWithValue("@Password", user.UserPassword);
//             cmd.Parameters.AddWithValue("@Address", user.Address);
//             cmd.Parameters.AddWithValue("@PostalCode", user.PostalCode);
//             cmd.Parameters.AddWithValue("@Town", user.Town);
//             cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

//             cmd.Parameters.AddWithValue("@Id", id);

//             myReader = cmd.ExecuteReader();
//             table.Load(myReader);

//             myReader.Close();
//             conn.Close();

//             return new JsonResult("Updated Successfully");

//         }
//     }
// }


