using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Blocks
{
	public static Vector3 BLOCK_SCALE { get => new Vector3(1f, 1f, 1f); }
	public static int MAP_ORIGIN_HEIGHT = 0;
	public static int TEXTURE_STEP_SIZE = 128;
	public static Vector2 TEXTURE_SIZE = new Vector2(2048f, 2048f);

	public enum BlockName
	{
		Air = 0,
		Dirt = 1,
		Sand = 2,
		Stone = 3,
		Cobblestone = 4,
		Water = 5
	};

	public class BlockType
	{
		public readonly int id;
		public BlockName name;
		public readonly Color color;
		public readonly Vector2Int textureOffset;

		public BlockType(int id, BlockName name, Color color, Vector2Int textureOffset)
        {
			this.id = id;
			this.name = name;
			this.color = color;
			this.textureOffset = textureOffset;
		}
	}

	public static BlockType[] Block = 
	{
		new BlockType(0, BlockName.Air,			new Color( 0f, 0f, 0f, 0f),			new Vector2Int(5, 15)),
		new BlockType(1, BlockName.Dirt,		new Color( 0.42f, 0.33f, 0.16f),    new Vector2Int(0, 15)),
		new BlockType(2, BlockName.Sand,		new Color( 0.76f, 0.70f, 0.5f),     new Vector2Int(1, 15)),
		new BlockType(3, BlockName.Stone,		new Color( 0.72f, 0.69f, 0.61f),    new Vector2Int(2, 15)),
		new BlockType(4, BlockName.Cobblestone, new Color( 0.65f, 0.6f, 0.54f),     new Vector2Int(14, 15)),
		new BlockType(5, BlockName.Water,		new Color( 0.45f, 0.8f, 0.96f),     new Vector2Int(4, 15)),
	};

	//public static Color[] COLORS =
	//{
	//	new Color( 0f, 0f, 0f, 0f),
	//	new Color( 0.42f, 0.33f, 0.16f),
	//	new Color( 0.76f, 0.70f, 0.5f),
	//	new Color( 0.72f, 0.69f, 0.61f),
	//	new Color( 0.65f, 0.6f, 0.54f),
	//	new Color( 0.45f, 0.8f, 0.96f)
	//};
}
