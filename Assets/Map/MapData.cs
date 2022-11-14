using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class MapData
{
	public static Vector2 MAP_SIZE { get => new Vector2( 54f, 54f); }
	public static Vector2 CHUNK_SIZE { get => new Vector2(3f, 3f); }
	public static Vector2 CHUNK_LOAD_DISTANCE { get => new Vector2(2, 2); }
	private static readonly int initializeMapSizeX = (int)MAP_SIZE.x;
	private static readonly int initializeMapSizeY = (int)MAP_SIZE.y;

	public static Vector3 MAP_START_POINT { get => new Vector3( 0f, 0f, 0f); }
	
	public static Vector2 PERLIN_ORIGIN_POSITION { get => new Vector2( 0, 0); }
	public static float PERLIN_SCALE = 3f;
		
	//public enum Structures
	//{
	//	Tree = 0,
	//	Lamp = 1,
	//	Gravel = 2,
	//};
	
	public struct BlockData
	{
		public Blocks.BlockType block;
		//public Structures structure;
		//public int temperature;
		//public int humidy;
	}
	
	public static BlockData[,] Map = new BlockData[initializeMapSizeX, initializeMapSizeY];
}
