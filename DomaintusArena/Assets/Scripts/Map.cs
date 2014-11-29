using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour {


	public GameObject[] floorTileSprite;
	public GameObject wallSprite;

	//floor list
	public List<Floor> floors;
	
	//wall list
	public List<Wall> walls;
	
	//arena
	public Arena arena;
	
	//crate list
	public List<Vector2> crates;
	
	//health list
	public List<Vector2> healths;

	public List<Vector2> spawnPoints;

	//Map Size Default
	//22x22 [ 1 Square x 1 Square ] 

	//Map Array
	private int[,] map = {   
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,2,0,0,0,0,2,0,3,0,0,2,0,0,0,0,2,0,0,1},
		{1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
		{1,0,0,0,0,4,1,0,0,0,0,0,0,0,0,1,4,0,0,0,0,1},
		{1,0,0,0,1,1,1,1,1,0,0,0,0,1,1,1,1,1,0,0,0,1},
		{1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
		{1,0,0,2,0,0,1,0,0,0,0,0,0,0,0,1,0,0,2,0,0,1},
		{1,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,1},
		{1,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,2,0,0,1,0,0,0,0,0,0,0,0,1,0,0,2,0,0,1},
		{1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
		{1,0,0,0,1,1,1,1,1,0,0,0,0,1,1,1,1,1,0,0,0,1},
		{1,0,0,0,0,4,1,0,0,0,0,0,0,0,0,1,4,0,0,0,0,1},
		{1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1},
		{1,0,0,2,0,0,0,0,2,0,0,3,0,2,0,0,0,0,2,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
	};

	public Map()
	{
		//initialize floor list
		floors = new List<Floor>();
		
		//initialize wall list
		walls = new List<Wall>();
			
		//initialize crate list
		crates = new List<Vector2>();
		
		//initialize health list
		healths = new List<Vector2>();
		
		//initialize spawn list
		spawnPoints = new List<Vector2>();

		//Init Map data
		int counter = 0;
		for (int y = 0; y < map.GetLength(1); y++)
		{
			for (int x = 0; x < map.GetLength(0); x++)
			{
				Vector2 pos = new Vector2(40 + (x * 80), 30 + (y * 60));
				
				switch (map[x, y])
				{
				case 1://wall
					AddWallOptimization(x, y, pos);
					break;
				case 2://crate
					crates.Add(pos);
					break;
				case 3://health
					healths.Add(pos);
					break;
				case 4://spawn point
					spawnPoints.Add(pos);
					break;
				case 5://arena(top left)
					arena.Position = pos;
					break;
				default:
					break;
				}
				
				//floor
				floors.Add(new Floor(counter % 2, pos));
				
				//increment counter
				counter++;
			}
		}
	}

	private void AddWallOptimization(int x, int y, Vector2 pos)
	{
		//set map x,y to 0
		map[x, y] = 0;
		
		int counterX = 0;
		int nextX = x + 1;
		int maxX = map.GetLength(0) - 1;
		while (nextX <= maxX && map[nextX, y] == 1)
		{
			//set this nextX x,y to 0
			map[nextX, y] = 0;
			
			//goto next x
			nextX++;
			
			//increment the counter
			counterX++;
		}
		
		int counterY = 0;
		if (counterX == 0)
		{
			int nextY = y + 1;
			int maxY = map.GetLength(1) - 1;
			
			while (nextY <= maxY && map[x, nextY] == 1)
			{
				//set this nextX x,y to 0
				map[x, nextY] = 0;
				
				//goto next x
				nextY++;
				
				//increment the counter
				counterY++;
			}
		}
		
		walls.Add(new Wall(pos , counterX, counterY));
	}

	public void Draw(int currentY)
	{
		//Draw Map
		for(int i = 0; i < floors.Count; i++)
		{
			//Instantiate(floorTileSprite[i%2],new Vector3(floorRect[i].x / 100,floorRect[i].y / 100),Quaternion.identity);
		}
		//Draw Walls
		for(int i = 0; i < walls.Count; i++)
		{
			for(int y = 0; y < walls[i].ExtraY + 1; y++)
			{
				for(int x = 0; x < walls[i].ExtraX + 1; x++)
				{
					Vector2 wallPos = walls[i].Position + new Vector2(x * 80,y * 60);
					if((int)wallPos.y == currentY)
					{
						//Instantiate(Resources.Load(""),new Vector3(wallPos.x,wallPos.y,0),Quaternion.identity);
					}
				}
			}
		}
	}


	public int Width
	{
		get { return map.GetLength(0) * 80; }
	}

	public int Height
	{
		get { return map.GetLength(1) * 60; }
	}

}
