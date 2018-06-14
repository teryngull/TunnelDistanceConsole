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
		/// <param name="startLat">The start location latitude.</param>
		/// <param name="startLong">The start location longitude.</param>
		/// <param name="endLat">The end location latitude.</param>
		/// <param name="endLong">The end location longitude.</param>
		/// <param name="tunnelList">The list of tunnel locations.</param>
		/// <returns>The smallest distance between the start and end locations via the tunnels or above ground</returns>
		public static int CalculateShortestPathTotal(int startLat, int startLong, int endLat, int endLong, List<Tunnel> tunnelList)
		{
			// calculate the above ground distance for comparison
			var aboveGroundDistance = CalculateManhattanDistance(startLat, startLong, endLat, endLong);
			Debug.WriteLine($"Above Ground Distance = {aboveGroundDistance}");

			// calculate the distance for each tunnel
			var shortestDistanceViaTunnel = CalculateDistanceForEachTunnelPath(startLat, startLong, endLat, endLong, tunnelList);
			Debug.WriteLine($"Shortest Distance Via Tunnel = {shortestDistanceViaTunnel}");

			return Math.Min(aboveGroundDistance, shortestDistanceViaTunnel);
		}

		/// <summary>
		/// Calculates the distance between a start and end location for each tunnel path available for a given list of tunnel locations
		/// </summary>
		/// <param name="startLat">The start location latitude.</param>
		/// <param name="startLong">The start location longitude.</param>
		/// <param name="endLat">The end location latitude.</param>
		/// <param name="endLong">The end location longitude.</param>
		/// <param name="tunnels">The list of tunnel locations.</param>
		/// <returns>The smallest distance between the start and end locations via the tunnels</returns>
		public static int CalculateDistanceForEachTunnelPath(int startLat, int startLong, int endLat, int endLong, List<Tunnel> tunnels)
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
		public static int CalculateManhattanDistance(int lat1, int long1, int lat2, int long2)
		{
			return Math.Abs(lat1 - lat2) + Math.Abs(long1 - long2);
		}
	}
}
