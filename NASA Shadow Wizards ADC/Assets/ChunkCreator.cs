using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is instanced from MeshCreator and many values are passed down
// Generates a chunk with x height values
public class ChunkCreator : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;

    public void CreateChunk(float[,] heightValues, int chunkSizeX, int chunkSizeZ, float offsetX, float offsetZ)
    {
        vertices = new Vector3[(chunkSizeX + 1) * (chunkSizeZ + 1)];


        for (int i = 0, z = 0; z < chunkSizeX; z++)
        {
            for (int x = 0; x < chunkSizeZ; x++)
            {
                vertices[i] = new Vector3(offsetX + x, heightValues[x, z], offsetZ + z);

                i++;
            }
        }

        triangles = new int[chunkSizeX * chunkSizeZ * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < chunkSizeZ; z++)
        {
            for (int x = 0; x < chunkSizeX; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + chunkSizeX + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + chunkSizeX + 1;
                triangles[tris + 5] = vert + chunkSizeX + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        UpdateChunk();
    }

    private void UpdateChunk()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices != null)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], .25f);
            }
        }
    }
}
