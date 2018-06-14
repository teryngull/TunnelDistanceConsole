using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            var minimumDistance1 = CalculateShortestPathTotal(7, 2, 1, 8, tunnelList);
            var minimumDistance2 = CalculateShortestPathTotal(7, 2, 1, 8, tunnelList2);
		}

        private static int CalculateShortestPathTotal(int startLat, int startLong, int endLat, int endLong, List<Tunnel> tunnelList)
		{
			// calculate the above ground distance for comparison
            var aboveGroundDistance = CalculateManhattanDistance(startLat, startLong, endLat, endLong);
			Debug.WriteLine($"Above Ground Distance = {aboveGroundDistance}");

			// calculate the distance for each tunnel
            var shortestDistanceViaTunnel = CalculateDistanceForEachTunnelPath(startLat, startLong, endLat, endLong, tunnelList);
			Debug.WriteLine($"Shortest Distance Via Tunnel = {shortestDistanceViaTunnel}");

            return Math.Min(aboveGroundDistance, shortestDistanceViaTunnel);
		}

        private static int CalculateDistanceForEachTunnelPath(int startLat, int startLong, int endLat, int endLong, List<Tunnel> tunnels)
		{
            int shortestDistance = 100;

            foreach (Tunnel tunnelEntrance in tunnels)
			{
				// calculate the distance to the tunnel entrances from the start location
				var distanceToTunnelEntrance = CalculateManhattanDistance(startLat, startLong, tunnelEntrance.Latitude, tunnelEntrance.Longitude);
                Debug.WriteLine($"Distance To Tunnel (Lat: {tunnelEntrance.Latitude}, Long: {tunnelEntrance.Longitude}) Entrance = {distanceToTunnelEntrance}");
                    
                // calculate the distance to the junction from the start location
				var distanceToJunction = distanceToTunnelEntrance + tunnelEntrance.Length;
                Debug.WriteLine($"Distance To Tunnel (Lat: {tunnelEntrance.Latitude}, Long: {tunnelEntrance.Longitude}) Junction (from entrance) = {distanceToJunction}");

                foreach (Tunnel tunnelExit in tunnels)
                {
					// calculate the distance from the tunnel exit to the end location
					var distanceFromTunnelExit = CalculateManhattanDistance(endLat, endLong, tunnelExit.Latitude, tunnelExit.Longitude);
                    Debug.WriteLine($"Distance From Tunnel (Lat: {tunnelExit.Latitude}, Long: {tunnelExit.Longitude}) Exit = {distanceFromTunnelExit}");

                    // calculate the distance from the junction to the end location
					var distanceFromJunction = distanceFromTunnelExit + tunnelExit.Length;
                    Debug.WriteLine($"Distance From Tunnel (Lat: {tunnelExit.Latitude}, Long: {tunnelExit.Longitude}) Junction (to exit) = {distanceFromJunction}");

                    // add up the totals to get the total distance from start location to end location
                    var totalDistance = distanceToJunction + distanceFromJunction;
                    Debug.WriteLine($"Total distance from Start (Lat: {startLat}, Long: {startLong}) to End ((Lat{endLat}, Long{endLong})= {totalDistance}");

                    if (totalDistance < shortestDistance)
                    {
                        shortestDistance = totalDistance;
                    }
				}
			}

            return shortestDistance;
		}

		/// <summary>
		/// Calculates the Manhattan distance between the two points.
		/// </summary>
		/// <param name="lat1">The first x (latitude) coordinate.</param>
		/// <param name="long1">The first y (longitude) coordinate.</param>
		/// <param name="lat2">The second x (latitude) coordinate.</param>
		/// <param name="long2">The second y (longitude) coordinate.</param>
		/// <returns>The Manhattan (above ground) distance between (lat1, long1) and (lat2, long2)</returns>
		private static int CalculateManhattanDistance(int lat1, int long1, int lat2, int long2)
		{
			return Math.Abs(lat1 - lat2) + Math.Abs(long1 - long2);
		}
	}
}