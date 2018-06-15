using System.Collections.Generic;
using TunnelDistance.Console.Helpers;
using TunnelDistance.Console.Models;

namespace TunnelDistance.Console
{
	internal class Program
	{
		private static void Main()
		{
			// create a test list of tunnel locations
			var tunnelList = new List<Tunnel>
			{
				new Tunnel
				{
					Location = new Location
					{
						Latitude = 1,
						Longitude = 6,
					},
					Length = 2,
				},
				new Tunnel
				{
					Location = new Location
					{
						Latitude = 7,
						Longitude = 3,
					},
					Length = 8,
				},
				new Tunnel
				{
					Location = new Location
					{
						Latitude = 4,
						Longitude = 1,
					},
					Length = 3,
				},
            };

			var startLocation = new Location { Latitude = 7, Longitude = 2 };
			var endLocation = new Location { Latitude = 1, Longitude = 8 };

			var minimumDistance = DistanceHelpers.CalculateShortestPathTotal(startLocation, endLocation, tunnelList);
		}
	}
}