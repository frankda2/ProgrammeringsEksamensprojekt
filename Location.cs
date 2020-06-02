using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeringsEksamensprojekt
{
	class Location
	{
		int locationId;
		public int LocationId
		{
			get => locationId;
		}

		string name;
		public string Name
		{
			get => name;
		}

		public Location(int location_id) {
			DatabaseInterface.GetLocationData(location_id, out string location_name);

			//Checking that a location with the location ID exists
			if(location_name != "error")
			{
				locationId = location_id;
				name = location_name;
			}
			else
			{
				Console.WriteLine("A location with the location ID: " + location_id + " could not be found");
			}
		}
	}
}
