using System.Collections.Generic;
using TunnelDistance.Console.Models;

namespace TunnelDistanceConsole.UnitTests
{
	public static class TunnelTestDataGenerator
	{
		public static IEnumerable<object[]> GetTunnelsFromDataGenerator()
		{
			yield return new object[]
			{
				new Location
				{
					Latitude = 7,
					Longitude = 2,
				},
				new Location
				{
					Latitude = 1,
					Longitude = 8,
				},
				new List<Tunnel>
				{
					new Tunnel {
						Location = new Location
						{
							Latitude = 1,
							Longitude = 6,
						},
						Length = 2
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 7,
							Longitude = 3,
						},
						Length = 8
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 4,
							Longitude = 1,
						},
						Length = 3
					},
				},
				11,
			};

			yield return new object[]
			{
				new Location
				{
					Latitude = 7,
					Longitude = 2,
				},
				new Location
				{
					Latitude = 1,
					Longitude = 8,
				},
				new List<Tunnel>
				{
					new Tunnel {
						Location = new Location
						{
							Latitude = 1,
							Longitude = 2,
						},
						Length = 9,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 8,
							Longitude = 3,
						},
						Length = 4,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 2,
							Longitude = 7,
						},
						Length = 5,
					},
				},
				12,
			};

			yield return new object[]
			{
				new Location
				{
					Latitude = 1,
					Longitude = 8,
				},
				new Location
				{
					Latitude = 7,
					Longitude = 2,
				},
				new List<Tunnel>
				{
					new Tunnel {
						Location = new Location
						{
							Latitude = 1,
							Longitude = 2,
						},
						Length = 9,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 8,
							Longitude = 3,
						},
						Length = 4,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 2,
							Longitude = 7,
						},
						Length = 5,
					},
				},
				12,
			};

			yield return new object[]
			{
				new Location
				{
					Latitude = 1,
					Longitude = 8,
				},
				new Location
				{
					Latitude = 2,
					Longitude = 7,
				},
				new List<Tunnel>
				{
					new Tunnel {
						Location = new Location
						{
							Latitude = 1,
							Longitude = 2,
						},
						Length = 9,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 8,
							Longitude = 3,
						},
						Length = 4,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 2,
							Longitude = 7,
						},
						Length = 5,
					},
				},
				2,
			};

			yield return new object[]
			{
				new Location
				{
					Latitude = 1,
					Longitude = 8,
				},
				new Location
				{
					Latitude = 7,
					Longitude = 2,
				},
				new List<Tunnel>(),
				12,
			};

			yield return new object[]
			{
				new Location
				{
					Latitude = 5,
					Longitude = 6,
				},
				new Location
				{
					Latitude = 8,
					Longitude = 3,
				},
				new List<Tunnel>
				{
					new Tunnel {
						Location = new Location
						{
							Latitude = 1,
							Longitude = 2,
						},
						Length = 9,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 8,
							Longitude = 3,
						},
						Length = 4,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 2,
							Longitude = 7,
						},
						Length = 5,
					},
					new Tunnel {
						Location = new Location
						{
							Latitude = 5,
							Longitude = 5,
						},
						Length = 1,
					},
				},
				6,
			};
		}
	}
}