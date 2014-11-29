using UnityEngine;
using System.Collections;

public class Arena : MonoBehaviour {

	//position
	public Vector2 Position
	{
		get { return position; }
		set { position = value; }
	}
	private Vector2 position = Vector2.zero;
	
	//width & height
	private const int width = 320;
	private const int height = 240;
	
	//floor sprite rect
	public Rect SpriteRect
	{
		get { return new Rect(0, 0, width, height); }
	}
	
	//floor origin
	public Vector2 OriginPosition
	{
		get { return new Vector2(40, 30); }
	}
	
	//arena glow
	private ArenaGlow[] arenaGlows = new ArenaGlow[4];
	public int SelectedGlowID
	{
		get { return selectedGlowID; }
		set { selectedGlowID = value; }
	} 
	private int selectedGlowID = -1;
	
	//has send arena is clear
	public bool IsClearArenaSend
	{
		get { return isClearArenaSend; }
		set { isClearArenaSend = value; }
	}
	private bool isClearArenaSend = false;



	public Arena()
	{
		//initialize arena glow
		for (int i = 0; i < arenaGlows.Length; i++)
			arenaGlows[i] = new ArenaGlow(i);
	}
}
