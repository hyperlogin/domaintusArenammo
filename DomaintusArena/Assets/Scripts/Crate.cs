using UnityEngine;
using System.Collections;

public class Crate {

	int crateWidth,crateHeight;
	Vector2 cratePos,crateOrigin;

	bool isAlive;
	float RespawnTimer;
	int respawnInterval;

	Random random;

	public Vector2 Position
	{
		get { return cratePos;}
	}

	public bool IsAlive
	{
		get{return isAlive;}
	}


}
