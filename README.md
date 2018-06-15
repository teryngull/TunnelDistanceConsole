# Tunnel Distance Console App

Console app to find the shortest total distance you'll need to travel given the startPoint (coordinates of where you live), the endPoint (coordinates of your destination), and tunnels (a list of coordinates and distances for each tunnel). All above-ground travel is measured according to Manhattan distance.

## Getting Started

This application was created using VS 2017 for Mac. The console project is a .NET Core 2.0 and the unit test project is using xUnit.


## Additional Project Info

Uh oh! You've slept through your alarm and it looks like you'll be late for your shift with the terraforming crew!

Fortunately, from your experience living on Mars, you've identified an underground network of tunnels formed by lava tubes. It's risky, but if you use the tunnels as a shortcut, it might just get you there on time.

All tunnels meet underground at a common point, and for each tunnel, we know the coordinates of the entry point and the distance to this junction. For example, we could represent the following map by ```tunnels = [[1, 2, 9], [2, 7, 5], [8, 3, 4]]```:

![tunnel map 1](docs/example_1.png?raw=true "tunnel map 1")

In this case, the underground distance from ```(1, 2)``` to ```(2, 7)``` would be ```9 + 5 = 14```. The underground distance from ```(2, 7)``` to ```(8, 3)``` would be ```5 + 4 = 9```.

Given the ```startPoint``` (coordinates of where you live), the ```endPoint``` (coordinates of your destination), and ```tunnels``` (a list of coordinates and distances for each tunnel), find the shortest total distance you'll need to travel. All above-ground travel is measured according to [Manhattan distance](https://en.wiktionary.org/wiki/Manhattan_distance).

*Note: you can pass through the coordinates of a tunnel entrance without entering the tunnel, and it's also possible that there's a tunnel entrance at your start or end point.*

### Example

For ```startPoint = [7, 2], endPoint = [1, 8]```, and ```tunnels = [[1, 6, 2], [7, 3, 8], [4, 1, 3]]```, the output should be ```tunnelPath(startPoint, endPoint, tunnels) = 11```.

![tunnel map 2](docs/example_2.png?raw=true "tunnel map 2")

Although there's a tunnel entrance right next to your starting point (at ```(7, 3)```), it's a very long tunnel. It would be faster to take a detour and go through the tunnel at ```(4, 1)```, emerging at ```(1, 6)```, for a total distance of ```4 + 3 + 2 + 2 = 11```. Note that the above-ground distance would be ```12```, so taking the tunnel would be shorter.

### Input / Output

- **[execution time limit] 3 seconds (cs)**

- **[input] array.integer startPoint**

  A 2-element array of integers representing the coordinates of the point on the map where you depart from.

  Guaranteed constraints:
  ```
  startPoint.length = 2
  -106 ≤ startPoint[i] ≤ 106
  ```

- **[input] array.integer endPoint**

  A 2-element array of integers representing the coordinates of the point on the map where you need to go.

  Guaranteed constraints:
  ```
  endPoint.length = 2
  -106 ≤ endPoint[i] ≤ 106
  ```

- **[input] array.array.integer tunnels**

  An array of 3-element arrays of integers, which represent the entry coordinates and lengths of each tunnel. Each ```tunnels[i]``` is of the form ```[x-coordinate, y-coordinate, tunnel length]```.

  Guaranteed constraints:
  ```
  0 ≤ tunnels.length ≤ 104
  tunnels[i].length = 3
  -106 ≤ tunnels[i][0] ≤ 106
  -106 ≤ tunnels[i][1] ≤ 106
  1 ≤ tunnels[i][2] ≤ 5 · 106
  ```

- **[output] integer**

  An integer representing the minimum total distance you need to travel.
