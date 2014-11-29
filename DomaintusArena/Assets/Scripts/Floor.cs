using UnityEngine;
using System.Collections.Generic;

public class Floor : MonoBehaviour {

	//id
	public int ID
	{
		get { return id; }
	}
	private int id;
	
	//position
	public Vector2 Position
	{
		get { return position; }
	}
	private Vector2 position;
	
	//width & height
	private const int width = 80;
	private const int height = 60;
	
	//floor sprite rect
	public Rect SpriteRect
	{
		get { return new Rect(0, 0, width, height); }
	}
	
	//floor origin
	public Vector2 OriginPosition
	{
		get { return new Vector2(width / 2, height / 2); }
	}


	public Floor(int id, Vector2 position)
	{
		this.id = id;
		this.position = position;
	}
}
