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

		public Item(string item_no) {
			DatabaseInterface.GetItemData(item_no, out string item_name, out int item_stock, out int location_id) ;

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
	}
}
