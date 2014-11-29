using UnityEngine;
using System.Collections;

public class Wall {



	//position
	public Vector2 Position
	{
		get { return position; }
	}
	private Vector2 position;
	
	//width & height
	private const int width = 80;
	private const int height = 120;
	
	//number of wall after this wall
	public int ExtraX
	{
		get { return extraX; }
	}
	private int extraX = 0;
	public int ExtraY
	{
		get { return extraY; }
	}
	private int extraY = 0;
	
	//floor sprite rect
	public Rect SpriteRect
	{
		get { return new Rect(0, 0, width, height); }
	}
	
	//floor origin
	public Vector2 OriginPosition
	{
		get { return new Vector2(width / 2, height * 0.75f); }
	}

	public Wall(Vector2 position, int extraX, int extraY)
	{
		this.position = position;
		this.extraX = extraX;
		this.extraY = extraY;
	}

}
