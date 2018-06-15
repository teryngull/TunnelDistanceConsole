using System.Collections.Generic;
using TunnelDistance.Console.Helpers;
using TunnelDistance.Console.Models;
using Xunit;

namespace TunnelDistanceConsole.UnitTests
{
	public class TunnelDistanceTest
	{
		[Theory]
		[InlineData(7, 2, 1, 8, 12)]
		[InlineData(5, 1, 1, 8, 11)]
		[InlineData(1, 1, 1, 8, 7)]
		[InlineData(1, 8, 1, 1, 7)]
		[InlineData(8, 8, 0, 0, 16)]
		public void CanCalculateManhattanDistance(int value1, int value2, int value3, int value4, int expected)
		{
			var result = DistanceHelpers.CalculateManhattanDistance(value1, value2, value3, value4);

			Assert.Equal(expected, result);
		}

		[Theory]
		[MemberData(nameof(TunnelTestDataGenerator.GetTunnelsFromDataGenerator), MemberType = typeof(TunnelTestDataGenerator))]
		public void CanGetShortestPath(Location startLocation, Location endLocation, List<Tunnel> tunnelList, int expected)
		{
			var result = DistanceHelpers.CalculateShortestPathTotal(startLocation, endLocation, tunnelList);

			Assert.Equal(expected, result);
		}
	}
}