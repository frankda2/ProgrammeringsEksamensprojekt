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
				using(MySqlCommand command = new MySqlCommand("SELECT * FROM items WHERE item_no = " + itemNo, conn))
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