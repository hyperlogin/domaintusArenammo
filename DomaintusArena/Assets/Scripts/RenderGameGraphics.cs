using UnityEngine;
using System.Collections;

public class RenderGameGraphics : MonoBehaviour {


	public GameObject wallSprite,healthCrateSprite,builderCrateSprite;
	public GameObject[] floorTileSprite;


	Vector2 noOfTileXY;
	const int tileWidth = 80, tileHeight = 60;
	Rect mapRect;

	//Map Object - floor
	Rect[] floorRect;

	//Map Object - wall
	int[] wallIndex;
	Wall[] wall;

	//Map Object - arena
	int arenaFrame = 0;
	float arenaOnTextureTimer = 0.0f;

	//Map Object - crate
	int[] crateSpawnIndex;
	Crate[] _crate;

	//Map Object - Health
	int[] healthSpawnIndex;
	Health[] health;
	
	//Map Object - spawn points
	int[] spawnPoints;
	
	//player 
	Player player;

	public void InitAllData()
	{

	}

	// Use this for initialization
	void Start () {
		//Render The Floor
		InitAllData();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
