using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProgrammeringsEksamensprojekt
{
	static class DatabaseInterface
	{
		private static string connString =	"Server=localhost;" +
											"Database=whm_data;" +
											"Uid=root;" +
											"Pwd=;";

		//Method for retreiving data related to a single item, from the item number
		public static void GetItemData(string itemNo, out string item_name, out int item_stock, out int location_id) {
			//Giving the out parameters a default error value
			item_name = "error";
			item_stock = -1;
			location_id = -1;

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be reading the item
				using(MySqlCommand command = new MySqlCommand("SELECT * FROM items WHERE item_no = \"" + itemNo + "\"", conn))
				{
					//Creating a datareader for reading the data in a continous stream
					MySqlDataReader reader = command.ExecuteReader();
					while(reader.Read())
					{
						//Getting the data from the database and saving it to the out parameters
						item_name = reader.GetString(2);
						item_stock = reader.GetInt32(3);
						location_id = reader.GetInt32(4);
					}

					reader.Close();
				}

				conn.Close();
			}
		}

		//Method for getting an array containing all item numbers
		public static string[] GetAllItemNumbers() {
			//Creating the array
			string[] itemNumbers = new string[CountItems()];

			//For storing index
			int index = 0;

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be reading the item
				using(MySqlCommand command = new MySqlCommand("SELECT item_no FROM items", conn))
				{
					//Creating a datareader for reading the data in a continous stream
					MySqlDataReader reader = command.ExecuteReader();
					while(reader.Read())
					{
						itemNumbers[index] = reader.GetString(0);

						index++;
					}
					
					reader.Close();
				}

				conn.Close();
			}

			return itemNumbers;
		}

		public static Item[] GetAllItems() {
			//Creating the array
			Item[] items = new Item[CountItems()];

			//Retreiving all item numbers
			string[] itemNumbers = GetAllItemNumbers();

			//Iterating through each item number and reading the item
			for(int i = 0; i < CountItems(); i++)
			{
				items[i] = new Item(itemNumbers[i]);
			}

			return items;
		}

		//Returns true if item exists
		public static bool DoesItemExist(string itemNo) {
			//creating an int for storing the item id, if this is still -1 by the end, the item doesn't exist
			int item_id = -1;

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be reading the item
				using(MySqlCommand command = new MySqlCommand("SELECT * FROM items WHERE EXISTS (SELECT * FROM items WHERE item_no = @itemNo)", conn))
				{
					command.Parameters.Add(new MySqlParameter("itemNO", itemNo));

					//Creating a datareader for reading the data in a continous stream
					MySqlDataReader reader = command.ExecuteReader();
					while(reader.Read())
					{
						//Getting the item id
						item_id = reader.GetInt32(0);
					}

					reader.Close();
				}

				conn.Close();
			}

			//Checking if an id was read
			if(item_id != -1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void CreateItemInDB(string itemNo, string item_name, int item_stock, int location_id) {
			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be inserting the item into the database
				using(MySqlCommand command = new MySqlCommand("INSERT INTO items (item_no, item_name, Stock, location_id) VALUES (@item_no, @item_name, @item_stock, @location_id)", conn))
				{
					//inserting values in the @parameter fields
					command.Parameters.Add(new MySqlParameter("item_no", itemNo));
					command.Parameters.Add(new MySqlParameter("item_name", item_name));
					command.Parameters.Add(new MySqlParameter("item_stock", item_stock));
					command.Parameters.Add(new MySqlParameter("location_id", location_id));

					command.ExecuteNonQuery();
				}

				conn.Close();
			}
		}

		//Method returning the number of unique items in the database
		public static long CountItems() {
			long count = -1;

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be counting the items in the database
				using(MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM items", conn))
				{
					count = (Int64) command.ExecuteScalar();
				}

				conn.Close();
			}

			return count;
		}

		//Method for removing an item from the database
		public static void RemoveItemFromDB(string itemNo) {
			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be removing the item
				using(MySqlCommand command = new MySqlCommand("DELETE FROM items WHERE item_no = \"" + itemNo + "\"", conn))
				{
					command.ExecuteNonQuery();
				}

				conn.Close();
			}
		}

		//Method for retreiving data related to a single location, from the location ID
		public static void GetLocationData(int location_id, out string location_name) {
			//Giving the out parameters a default error value
			location_name = "error";

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be reading the item
				using(MySqlCommand command = new MySqlCommand("SELECT * FROM locations WHERE location_id = " + location_id.ToString(), conn))
				{
					//Creating a datareader for reading the data in a continous stream
					MySqlDataReader reader = command.ExecuteReader();

					while(reader.Read())
					{
						//Getting the data from the database and saving it to the out parameters
						location_name = reader.GetString(1);
					}

					reader.Close();
				}

				conn.Close();
			}
		}

		//Method for retreiving data related to a single location, from the location name
		public static void GetLocationData(string location_name, out int location_id) {
			//Giving the out parameters a default error value
			location_id = -1;

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be reading the item
				using(MySqlCommand command = new MySqlCommand("SELECT * FROM locations WHERE location_name = \"" + location_name + "\"", conn))
				{
					//Creating a datareader for reading the data in a continous stream
					MySqlDataReader reader = command.ExecuteReader();

					while(reader.Read())
					{
						//Getting the data from the database and saving it to the out parameters
						location_id = reader.GetInt32(0);
					}

					reader.Close();
				}

				conn.Close();
			}
		}

		//Returns true if location exists
		public static bool DoesLocationExist(string location_name) {
			//creating an int for storing the location id, if this is still -1 by the end, the location doesn't exist
			int location_id = -1;

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be reading the item
				using(MySqlCommand command = new MySqlCommand("SELECT * FROM locations WHERE EXISTS (SELECT * FROM locations WHERE location_name = @location_name)", conn))
				{
					command.Parameters.Add(new MySqlParameter("location_name", location_name));

					//Creating a datareader for reading the data in a continous stream
					MySqlDataReader reader = command.ExecuteReader();
					while(reader.Read())
					{
						//Getting the item id
						location_id = reader.GetInt32(0);
					}

					reader.Close();
				}

				conn.Close();
			}

			//Checking if an id was read
			if(location_id != -1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//Method for creating a location in the database
		public static void CreateLocationInDB(string location_name) {
			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be counting the items in the database
				using(MySqlCommand command = new MySqlCommand("INSERT INTO locations (location_name) VALUES (@name)", conn))
				{
					command.Parameters.Add(new MySqlParameter("name", location_name));

					command.ExecuteNonQuery();
				}

				conn.Close();
			}
		}

		//Method returning the number of unique locations in the database
		public static long CountLocations() {
			long count = -1;

			//Creating and opening a connection to the database
			using(MySqlConnection conn = new MySqlConnection(connString))
			{
				conn.Open();

				//Creating the command, that will be counting the items in the database
				using(MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM locations", conn))
				{
					count = (Int64) command.ExecuteScalar();
				}

				conn.Close();
			}

			return count;
		}
	}
}