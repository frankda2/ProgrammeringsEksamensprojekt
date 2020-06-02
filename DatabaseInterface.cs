using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
	static class DatabaseInterface
	{
		//The connection string for connecting to the database
		private static string connString = "Server=(local), 3306;" + //Server name here ex. (local) for local hosted DB
											"User ID=programmering;" +
											"Password=iL6UvbPlxS9TS5KZ;" +
											"Database=whm_data;"; //Database name, DO NOT CHANGE;

		//Method for reading an item from the database, using the item number
		public static void GetItem(string itemNo) {
			Console.WriteLine("In here");

			//Opening a connection to the database
			using(SqlConnection conn = new SqlConnection(connString))
			{
				//Item newItem; //For storing the created "item"
				conn.Open();

				Console.WriteLine("conn open");

				using(SqlCommand command = new SqlCommand("SELECT * FROM items WHERE item_no = " + itemNo, conn))
				{
					SqlDataReader reader = command.ExecuteReader();
					while(reader.Read())
					{
						string item_no = reader.GetString(1);
						string item_name = reader.GetString(2);

						Console.WriteLine(item_no);
						Console.WriteLine(item_name);
					}
				}

				//Returning the item read from the database
				//return newItem;
			}
		}
	}
}