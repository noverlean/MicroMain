using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector2 currentPlayerChunk;

    [SerializeField] private MeshCreator meshCreator;

    void Start()
    {
        MapGenerator.CreateMap();

        LoadMap(CheckPlayerPosition());
    }

    void Update()
    {
        if (currentPlayerChunk != CheckPlayerPosition())
            LoadMap(CheckPlayerPosition());

        currentPlayerChunk = CheckPlayerPosition();
    }

    Vector2 CheckPlayerPosition() => new Vector2(Mathf.Floor(player.position.x / (MapData.CHUNK_SIZE.x * Blocks.BLOCK_SCALE.x)), Mathf.Floor(player.position.z / (MapData.CHUNK_SIZE.y * Blocks.BLOCK_SCALE.z))); 

    public void LoadMap(Vector2 currentChunk)
    {
        Vector2 startPoint = (currentChunk - (MapData.CHUNK_LOAD_DISTANCE - new Vector2(1, 1))) * MapData.CHUNK_SIZE;
        Vector2 endPoint = (currentChunk + MapData.CHUNK_LOAD_DISTANCE) * MapData.CHUNK_SIZE;

        if (startPoint.x < 0)
        {
            startPoint.x = 0;
        }

        if (startPoint.y < 0)
        {
            startPoint.y = 0;
        }

        if (endPoint.x > MapData.MAP_SIZE.x)
        {
            endPoint.x = MapData.MAP_SIZE.x;
        }

        if (endPoint.y > MapData.MAP_SIZE.y)
        {
            endPoint.y = MapData.MAP_SIZE.y;
        }

        meshCreator.ClearAll();

        for (int x = (int)startPoint.x; x < endPoint.x; x++)
        {
            for (int y = (int)startPoint.y; y < endPoint.y; y++)
            {
                meshCreator.BuildMesh(x, y);
            }
        }

        meshCreator.UploadMesh();
    }
}
