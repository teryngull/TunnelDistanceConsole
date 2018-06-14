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
					Latitude = 1,
					Longitude = 6,
					Length = 2,
				},
				new Tunnel
				{
					Latitude = 7,
					Longitude = 3,
					Length = 8,
				},
				new Tunnel
				{
					Latitude = 4,
					Longitude = 1,
					Length = 3,
				},
            };

			var tunnelList2 = new List<Tunnel>
			{
				new Tunnel
				{
					Latitude = 1,
					Longitude = 2,
					Length = 9,
				},
				new Tunnel
				{
					Latitude = 8,
					Longitude = 3,
					Length = 4,
				},
				new Tunnel
				{
					Latitude = 2,
					Longitude = 7,
					Length = 5,
				},
			};

            var minimumDistance1 = DistanceHelpers.CalculateShortestPathTotal(7, 2, 1, 8, tunnelList);
            var minimumDistance2 = DistanceHelpers.CalculateShortestPathTotal(7, 2, 1, 8, tunnelList2);
		}
	}
}