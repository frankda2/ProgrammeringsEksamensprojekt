using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
	class Item
	{
		string itemNo; //The item number
		public string ItemNo
		{
			get => itemNo;
		}

		string name;
		public string Name
		{
			get => name;
		}

		int stock;
		public int Stock
		{
			get => stock;
		}

		int locationId; //The id of the items location in the database
		public int LocationId
		{
			get => locationId;
		}

		//For creating an Item by reading from the database	
		public Item(string item_no) {
			DatabaseInterface.GetItemData(item_no, out string item_name, out int item_stock, out int location_id);

			//Checking that the item number exists
			if(item_name != "error")
			{
				itemNo = item_no;
				name = item_name;
				stock = item_stock;
				locationId = location_id;
			}
			else
			{
				Console.WriteLine("An item with the item number: " + item_no + " could not be found");
			}
		}

		//For creating a new item in the database
		public Item(string item_no, string item_name, int item_stock, string location_name) {
			//Int for storing the location id
			int location_id = -1;

			//Check if item number is available
			if(!DatabaseInterface.DoesItemExist(item_no))
			{
				//Checking if the location exists
				//If a location with the given name doesn't exist 
				if(!DatabaseInterface.DoesLocationExist(location_name))
				{
					//The location is created
					DatabaseInterface.CreateLocationInDB(location_name);
				}

				//And the id is fetched
				DatabaseInterface.GetLocationData(location_name, out location_id);

				//Setting the objects variables
				itemNo = item_no;
				name = item_name;
				stock = item_stock;
				locationId = location_id;

				//Creating the item in the database
				DatabaseInterface.CreateItemInDB(item_no, item_name, item_stock, location_id);
			}
			else
			{
				Console.WriteLine("An item with the item number: " + item_no + " does already exist");
			}
		}

		public string GetLocationName() {
			string location_name;

			DatabaseInterface.GetLocationData(locationId, out location_name);

			return location_name;
		}

		public void RemoveFromDB() {
			DatabaseInterface.RemoveItemFromDB(itemNo);
		}
	}
}
