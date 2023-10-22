using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is instanced from MeshCreator and many values are passed down
// Generates a chunk with x height values
public class ChunkCreator : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;
    Shader terrainShader1;
    Material terrainMainMaterial;

    public void CreateChunk(float[,] heightValues, int chunkSizeX, int chunkSizeZ, Shader terrainShader1, Material terrainMainMaterial)
    {
        this.terrainShader1 = terrainShader1;
        this.terrainMainMaterial = terrainMainMaterial;
        vertices = new Vector3[(chunkSizeX+1) * (chunkSizeZ+1)];
        int i = 0;

        for (int x = 0; x <= chunkSizeX; x++)
        {
            for (int z = 0; z <= chunkSizeZ; z++)
            {
                float xPos = x;
                float zPos = z;

                vertices[i] = new Vector3(xPos, heightValues[x, z], zPos);
                i++;
            }
        }

        triangles = new int[chunkSizeX * chunkSizeZ * 6];
        int triangleIndex = 0;
        for (int x = 0; x < chunkSizeX; x++)
        {
            for (int z = 0; z < chunkSizeX; z++)
            {
                int vertexIndex = x * (chunkSizeX + 1) + z;
                triangles[triangleIndex] = vertexIndex;
                triangles[triangleIndex + 1] = vertexIndex + 1;
                triangles[triangleIndex + 2] = vertexIndex + chunkSizeX + 1;
                triangles[triangleIndex + 3] = vertexIndex + 1;
                triangles[triangleIndex + 4] = vertexIndex + chunkSizeX + 2;
                triangles[triangleIndex + 5] = vertexIndex + chunkSizeX + 1;
                triangleIndex += 6;
            }
        }

        UpdateChunk();
    }

    private void UpdateChunk()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = terrainMainMaterial;

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
                //Gizmos.DrawSphere(vertices[i], .25f);
            }
        }
    }
}
