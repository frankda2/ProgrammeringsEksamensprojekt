using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
	class DatabaseInterface
	{
		//The connection string for connecting to the database
		private string connString = "Server=(local);" + //Server name here ex. (local) for local hosted DB
									"Database=whm_data;" +  //Database name, DO NOT CHANGE
									"Trusted_Connection=true";

		//Method for reading an item from the database, using the item number
		public Item GetItem(int itemNo) {
			//Opening a connection to the database
			using(SqlConnection conn = new SqlConnection(connString))
			{
				Item newItem; //For storing the created "item"

				//Creating the commmand
				SqlCommand command = new SqlCommand("", conn);

				conn.Open();

				
				

				//Returning the item read from the database
				return newItem;
			}
		}
	}
}
