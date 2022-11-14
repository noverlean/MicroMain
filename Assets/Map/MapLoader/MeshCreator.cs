using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MeshCreator : MonoBehaviour
{
    public static Mesh MapMesh;
    public int blockCount = 0;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;

    void Start()
    {
        MapMesh = new Mesh();
    }

    public static class blockDefaultParams
    {
        public static Vector3[] vertices = {
            new Vector3(0f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
        };

        public static int[] triangles = {
            0, 3, 2,
            0, 2, 1,
        };

        public static Vector2[] uv = {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
        };
    }

    public static class MapBlocksArray
    {
        public static Vector3[] vertices = new Vector3[0];
        public static int[] triangles = new int[0];
        public static Vector2[] uv = new Vector2[0];
    }

    private Vector3[] AddAllVerticesWithOffsetByPosition(int x, int y)
    {
        Vector3[] vertices = new Vector3[blockDefaultParams.vertices.Length];

        for (int i = 0; i < blockDefaultParams.vertices.Length; i++)
        {
            vertices[i] = blockDefaultParams.vertices[i] + new Vector3(x, Blocks.MAP_ORIGIN_HEIGHT, y);
        }

        return vertices;
    }

    private int[] AddAllTrianglesWithOffsetByPosition(int x, int y)
    {
        int[] triangles = new int[blockDefaultParams.triangles.Length];

        for (int i = 0; i < blockDefaultParams.triangles.Length; i++)
        {
            triangles[i] = blockDefaultParams.triangles[i] + blockDefaultParams.vertices.Length * (blockCount-1);
        }

        return triangles;
    }

    private Vector2[] AddAllUVsByBlockType(int x, int y)
    {
        Vector2[] uv = new Vector2[blockDefaultParams.uv.Length];

        for (int i = 0; i < blockDefaultParams.uv.Length; i++)
        {
            uv[i] = (blockDefaultParams.uv[i] + MapData.Map[x, y].block.textureOffset) * Blocks.TEXTURE_STEP_SIZE / Blocks.TEXTURE_SIZE;
        }

        return uv;
    }

    public void UploadMesh()
    {
        MapMesh.vertices = MapBlocksArray.vertices;
        MapMesh.triangles = MapBlocksArray.triangles;
        MapMesh.RecalculateNormals();
        MapMesh.uv = MapBlocksArray.uv;

        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();

        meshFilter.mesh = MapMesh;
        meshCollider.sharedMesh = MapMesh;
    }

    public void BuildMesh(int x, int y/*, int blockCount*/)
    {
        //this.blockCount = blockCount;
        blockCount++;
        
        MapBlocksArray.vertices = Concat(MapBlocksArray.vertices, AddAllVerticesWithOffsetByPosition(x, y));
        MapBlocksArray.triangles = Concat(MapBlocksArray.triangles, AddAllTrianglesWithOffsetByPosition(x, y));
        MapBlocksArray.uv = Concat(MapBlocksArray.uv, AddAllUVsByBlockType(x, y));
    }

    public void ClearAll()
    {
        blockCount = 0;

        MapBlocksArray.vertices = new Vector3[0];
        MapBlocksArray.triangles = new int[0];
        MapBlocksArray.uv = new Vector2[0];
    }

    public Vector3[] Concat(Vector3[] x, Vector3[] y)
    {
        if (x == null) throw new ArgumentNullException("x");
        if (y == null) throw new ArgumentNullException("y");

        int oldLen = x.Length;
        Array.Resize<Vector3>(ref x, x.Length + y.Length);
        Array.Copy(y, 0, x, oldLen, y.Length);
        return x;
    }

    public int[] Concat(int[] x, int[] y)
    {
        int oldLen = x.Length;
        Array.Resize<int>(ref x, x.Length + y.Length);
        Array.Copy(y, 0, x, oldLen, y.Length);
        return x;
    }

    public Vector2[] Concat(Vector2[] x, Vector2[] y)
    {
        int oldLen = x.Length;
        Array.Resize<Vector2>(ref x, x.Length + y.Length);
        Array.Copy(y, 0, x, oldLen, y.Length);
        return x;
    }
}
