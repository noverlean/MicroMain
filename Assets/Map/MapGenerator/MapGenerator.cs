using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MapGenerator
{		
	public static void CreateBlock(Vector3 position, float perlinValue){
		MapData.Map[(int)position.x, (int)position.z].block = Blocks.Block[(int)MapGenerateRules.GetBlockTypeFromRange(perlinValue)];
	}

	public static void CreateMap(){
		for (int x = 0; x < MapData.MAP_SIZE.x; x++){
			for (int y = 0; y < MapData.MAP_SIZE.y; y++){
				float xCoord = MapData.MAP_START_POINT.x + x / MapData.MAP_SIZE.x * MapData.PERLIN_SCALE;
                float yCoord = MapData.MAP_START_POINT.y + y / MapData.MAP_SIZE.y * MapData.PERLIN_SCALE;

                float sample = Mathf.PerlinNoise(xCoord, yCoord);

				CreateBlock(new Vector3(x, Blocks.MAP_ORIGIN_HEIGHT, y), sample);
			}
		}
	}
}
