using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapGenerateRules
{
    public class BlockTypeRange
    {
        public Vector2 range;
        public Blocks.BlockName blockName;

        public BlockTypeRange(Vector2 range, Blocks.BlockName blockName)
        {
            this.range = range;
            this.blockName = blockName;
        }
    }

    public static BlockTypeRange[] BlockTypeRanges = 
    {
        new BlockTypeRange(new Vector2(0f,      0.3f),  Blocks.BlockName.Water),
        new BlockTypeRange(new Vector2(0.3f,    0.4f),  Blocks.BlockName.Sand),
        new BlockTypeRange(new Vector2(0.4f,    0.6f),  Blocks.BlockName.Dirt),
        new BlockTypeRange(new Vector2(0.6f,    0.8f),  Blocks.BlockName.Stone),
        new BlockTypeRange(new Vector2(0.8f,    1.0f),  Blocks.BlockName.Cobblestone),
    };

    public static Blocks.BlockName GetBlockTypeFromRange(float value) {
        for (int i = 0; i < BlockTypeRanges.Length; i++)
        {
            if (value > BlockTypeRanges[i].range.x && value < BlockTypeRanges[i].range.y)
            {
                return BlockTypeRanges[i].blockName;
            }
        }

        return Blocks.BlockName.Air;
    }
}
