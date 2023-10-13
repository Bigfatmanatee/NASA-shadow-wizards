using UnityEngine;

public class MeshCreatorTESTY : MonoBehaviour
{
    public int gridSize = 50;

    void Start()
    {
        GenerateSquareMesh();
    }

    void GenerateSquareMesh()
    {
        // Create a new mesh
        Mesh squareMesh = new Mesh();

        // Vertices
        Vector3[] vertices = new Vector3[(gridSize + 1) * (gridSize + 1)];
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                float xPos = (float)x / gridSize - 0.5f;
                float zPos = (float)z / gridSize - 0.5f;
                vertices[x * (gridSize + 1) + z] = new Vector3(xPos, 0, zPos);
            }
        }
        squareMesh.vertices = vertices;

        // Triangles
        int[] triangles = new int[gridSize * gridSize * 6];
        int triangleIndex = 0;
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                int vertexIndex = x * (gridSize + 1) + z;
                triangles[triangleIndex] = vertexIndex;
                triangles[triangleIndex + 1] = vertexIndex + 1;
                triangles[triangleIndex + 2] = vertexIndex + gridSize + 1;
                triangles[triangleIndex + 3] = vertexIndex + 1;
                triangles[triangleIndex + 4] = vertexIndex + gridSize + 2;
                triangles[triangleIndex + 5] = vertexIndex + gridSize + 1;
                triangleIndex += 6;
            }
        }
        squareMesh.triangles = triangles;

        // Normals (for shading)
        Vector3[] normals = new Vector3[vertices.Length];
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = Vector3.up;
        }
        squareMesh.normals = normals;

        // Create a MeshFilter component and assign the mesh
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = squareMesh;

        // Create a MeshRenderer component and assign a material
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));
    }
}
