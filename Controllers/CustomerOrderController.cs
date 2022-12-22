using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using newCubeBackend.Connection;
using System.Data;
using newCubeBackend.CustomerOrderModel;


// Define name of space. 
namespace newCubeBackend.CustomerOrderController
{
    // method Route it's the link of API endpoint.
    [Route("api/CustomerOrder")]
    [ApiController]
    // Creating a child class UserController of ControllerBase
    public class CustomerOrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CustomerOrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method it's used for requests HTTP of type Get.
        [HttpGet]
        public String Get()
        {
            // Create query in string with SQL command inside.
            string query = "SELECT * FROM customerOrder";

            // Create object table with the method new DataTable() of type DataTable.
            DataTable table = new DataTable();
            // Create object named myReader of type MySqlDataReader. This method myReader it's used after.
            MySqlDataReader myReader;
            // Create connection nammed conn of MySqlConnection. he use DBConnect.GetDBConnection(). this method it's Define on ../Controllers/DBConnect.cs
            MySqlConnection conn = DBConnect.GetDBConnection();

            // Open the conn define line above
            conn.Open();

            // Create the variable cmd of type MySqlCommand. He create a new MySqlCommand with paramaters the query (it's the SQL command define above) and (conn it's the connection of DB).
            // For use MySqlCommand, you need to use using MySql.Data.MySqlClient; at up of the file.
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //  With myReader use cmd define above for ExecuteReader(); 
            myReader = cmd.ExecuteReader();
            // From table load the data of myReader.
            table.Load(myReader);

            // After have Load the data in table we can close the reader and the conn.
            myReader.Close();
            conn.Close();

            // Use JsonConvert.SerializeObject() for the module Newtonsoft.Json; with parameter table define above and Formatting.Indented it's for do not see line of data.
            // this method it's save in json of type string
            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            // return it's the last command of the method Get(). he return the json define above.
            return json;
        }


        [HttpGet("{id}")]
        public String GetById(int id)
        {
            string query = "SELECT * FROM customerOrder WHERE id_customer_order = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            string json = JsonConvert.SerializeObject(table, Formatting.Indented);

            return json;
        }

        [HttpPost]
        public JsonResult Post(CustomerOrder customer_order)
        {
            // string query = @"INSERT INTO cubeSQL.userTable(authMail, authPassword) VALUES(@Mail, @Password)";
            string query = @"INSERT INTO customerOrder(number_item_customer, order_customer, price_customer, price_without_tcc_customer, order_date_customer, discount_customer, delivery_cost_customer, order_item_id_customer) 
                            VALUES (@NumberItemCustomer, @OrderCustomer, @PriceCustomer, @PriceWithoutTccCustomer, @OrderDateCustomer, @DiscountCustomer, @DeliveryCostCustomer, @OrderItemIdCustomer)";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@NumberItemCustomer", customer_order.NumberItemCustomer);
            cmd.Parameters.AddWithValue("@OrderCustomer", customer_order.OrderCustomer);
            cmd.Parameters.AddWithValue("@PriceCustomer", customer_order.PriceCustomer);
            cmd.Parameters.AddWithValue("@PriceWithoutTccCustomer", customer_order.PriceWithoutTccCustomer);
            cmd.Parameters.AddWithValue("@OrderDateCustomer", customer_order.OrderDateCustomer);
            cmd.Parameters.AddWithValue("@DiscountCustomer", customer_order.DiscountCustomer);
            cmd.Parameters.AddWithValue("@DeliveryCostCustomer", customer_order.DeliveryCostCustomer);
            cmd.Parameters.AddWithValue("@OrderItemIdCustomer", customer_order.OrderItemIdCustomer);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from customerOrder where id_customer_order = @Id;";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Deleted Successfully");
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, CustomerOrder customer_order)
        {
            var sql = @"UPDATE customerOrder
                        SET number_item_customer = @NumberItemCustomer,  
                        order_customer = @OrderCustomer, 
                        price_customer = @PriceCustomer, 
                        price_without_tcc_customer = @PriceWithoutTccCustomer, 
                        order_date_customer = @OrderDateCustomer, 
                        discount_customer = @DiscountCustomer, 
                        delivery_cost_customer = @DeliveryCostCustomer, 
                        order_item_id_customer = @OrderItemIdCustomer 
                        WHERE id_customer_order = @Id";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            MySqlConnection conn = DBConnect.GetDBConnection();

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@NumberItemCustomer", customer_order.NumberItemCustomer);
            cmd.Parameters.AddWithValue("@OrderCustomer", customer_order.OrderCustomer);
            cmd.Parameters.AddWithValue("@PriceCustomer", customer_order.PriceCustomer);
            cmd.Parameters.AddWithValue("@PriceWithoutTccCustomer", customer_order.PriceWithoutTccCustomer);
            cmd.Parameters.AddWithValue("@OrderDateCustomer", customer_order.OrderDateCustomer);
            cmd.Parameters.AddWithValue("@DiscountCustomer", customer_order.DiscountCustomer);
            cmd.Parameters.AddWithValue("@DeliveryCostCustomer", customer_order.DeliveryCostCustomer);
            cmd.Parameters.AddWithValue("@OrderItemIdCustomer", customer_order.OrderItemIdCustomer);

            cmd.Parameters.AddWithValue("@Id", id);

            myReader = cmd.ExecuteReader();
            table.Load(myReader);

            myReader.Close();
            conn.Close();

            return new JsonResult("Updated Successfully");

        }
    }
}


