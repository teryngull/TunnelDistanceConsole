using System;
using System.Collections.Generic;
using System.Diagnostics;
using TunnelDistance.Console.Models;

namespace TunnelDistance.Console.Helpers
{
	public static class DistanceHelpers
	{
		/// <summary>
		/// Calculates the distance between a start and end location (above ground or via tunnels)
		/// </summary>
		/// <param name="startLocation">The start location latitude and longitude.</param>
		/// <param name="endLocation">The end location latitude and longitude.</param>
		/// <param name="tunnelList">The list of tunnel locations.</param>
		/// <returns>The smallest distance between the start and end locations via the tunnels or above ground</returns>
		public static int CalculateShortestPathTotal(Location startLocation, Location endLocation, List<Tunnel> tunnelList)
		{
			// calculate the above ground distance for comparison
			var aboveGroundDistance = CalculateManhattanDistance(startLocation.Latitude,
			                                                     startLocation.Longitude,
			                                                     endLocation.Latitude,
			                                                     endLocation.Longitude);
			Debug.WriteLine($"Above Ground Distance = {aboveGroundDistance}");

			// calculate the distance for each tunnel
			var shortestDistanceTotal = CalculateDistanceForEachTunnelPath(startLocation,
			                                                                   endLocation,
			                                                                   aboveGroundDistance,
			                                                                   tunnelList);
			Debug.WriteLine($"Shortest Distance Total = {shortestDistanceTotal}");

			return shortestDistanceTotal;
		}

		/// <summary>
		/// Calculates the distance between a start and end location for each tunnel path available for a given list of tunnel locations
		/// </summary>
		/// <param name="startLocation">The start location latitude and longitude.</param>
		/// <param name="endLocation">The end location latitude and longitude.</param>
		/// <param name="aboveGroundDistance">The distance between the start and stop locations above ground for comparison.</param>
		/// <param name="tunnels">The list of tunnel locations.</param>
		/// <returns>The smallest distance between the start and end locations via the tunnels</returns>
		public static int CalculateDistanceForEachTunnelPath(Location startLocation, Location endLocation, int aboveGroundDistance, List<Tunnel> tunnels)
		{
			int shortestDistance = aboveGroundDistance;

			foreach (Tunnel tunnelEntrance in tunnels)
			{
				// calculate the distance to the tunnel entrances from the start location
				var distanceToTunnelEntrance = CalculateManhattanDistance(startLocation.Latitude,
				                                                          startLocation.Longitude,
				                                                          tunnelEntrance.Location.Latitude,
				                                                          tunnelEntrance.Location.Longitude);
				Debug.WriteLine($"Distance To Tunnel (Lat: {tunnelEntrance.Location.Latitude}, Long: {tunnelEntrance.Location.Longitude}) Entrance = {distanceToTunnelEntrance}");

				// calculate the distance to the junction from the start location
				var distanceToJunction = distanceToTunnelEntrance + tunnelEntrance.Length;
				Debug.WriteLine($"Distance To Tunnel (Lat: {tunnelEntrance.Location.Latitude}, Long: {tunnelEntrance.Location.Longitude}) Junction (from entrance) = {distanceToJunction}");

				foreach (Tunnel tunnelExit in tunnels)
				{
					// no need to calculate the distance out the same exit as the entrance because obviously that's not going to be the shortest choice!
					if (tunnelEntrance.Location.Latitude != tunnelExit.Location.Latitude && tunnelEntrance.Location.Longitude != tunnelExit.Location.Longitude)
					{
						// calculate the distance from the tunnel exit to the end location
						var distanceFromTunnelExit = CalculateManhattanDistance(endLocation.Latitude,
						                                                        endLocation.Longitude,
						                                                        tunnelExit.Location.Latitude,
						                                                        tunnelExit.Location.Longitude);
						Debug.WriteLine($"Distance From Tunnel (Lat: {tunnelExit.Location.Latitude}, Long: {tunnelExit.Location.Longitude}) Exit = {distanceFromTunnelExit}");

						// calculate the distance from the junction to the end location
						var distanceFromJunction = distanceFromTunnelExit + tunnelExit.Length;
						Debug.WriteLine($"Distance From Tunnel (Lat: {tunnelExit.Location.Latitude}, Long: {tunnelExit.Location.Longitude}) Junction (to exit) = {distanceFromJunction}");

						// add up the totals to get the total distance from start location to end location
						var totalTunnelDistance = distanceToJunction + distanceFromJunction;
						Debug.WriteLine($"Total distance from Start (Lat: {startLocation.Latitude}, Long: {startLocation.Longitude}) to End ((Lat{endLocation.Latitude}, Long{endLocation.Longitude})= {totalTunnelDistance}");

						if (totalTunnelDistance < shortestDistance)
						{
							shortestDistance = totalTunnelDistance;
						}
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
		public static int CalculateManhattanDistance(int lat1, int long1, int lat2, int long2)
		{
			return Math.Abs(lat1 - lat2) + Math.Abs(long1 - long2);
		}
	}
}
