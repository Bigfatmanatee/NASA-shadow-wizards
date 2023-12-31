using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MeshCreator : MonoBehaviour
{
    public bool combineMeshes;
    public int xSize = 3200;
    public int zSize = 3200;
    public int chunkSizeX = 100;
    public int chunkSizeZ = 100;
    public GameObject chunkObject;
    public TextAsset[] csvFiles; // Assign the CSV file in the Inspector
    public Shader terrainShader1;
    public Material terrainMainMaterial;
    float[,] heightValues = new float[3201, 3201];

    private void Start()
    {
        int x = 0;
        int y = 0;
        foreach (TextAsset csvFile in csvFiles)
        {
            if (csvFile == null)
                continue;

            string[] lines = csvFile.text.Split('\n'); // Split the CSV file into lines

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                foreach (string value in values)
                {
                    if (value.Length < 1) continue;
                    // so the program doesn't exit, use a tryparse
                    float parsedValue;
                    bool success = float.TryParse(value, out parsedValue);
                    heightValues[y, x] = parsedValue;
                    x++;

                    if (x == 3200)
                    {
                        y++;
                        x = 0;
                    }
                }
            }
        }

        //Grid grid = new Grid(heightValues);
        //grid.CreateGrid;
            
        StartCoroutine(InstanceChunks());
    }

    private IEnumerator InstanceChunks()
    {
        // Generating chunks (only 16 for now)
        for (int i = 0; i < 16; i++)
        {
            for (int o = 0; o < 16; o++)
            {
                float[,] chunkHeightValues = new float[chunkSizeX + 1, chunkSizeZ + 1];

                // Copying a subsection of the array
                //print("Chunk " + i + "," + o + " starts at " + heightValues[i * chunkSizeX, o * chunkSizeZ]);
                for (int g = 0; g <= chunkSizeX; g++)
                {
                    for (int h = 0; h <= chunkSizeZ; h++)
                    {
                        //print("H: " + h + " , " + "G: " + g);
                        chunkHeightValues[h, g] = heightValues[h + i * chunkSizeX, g + o * chunkSizeZ];
                    }
                }

                GameObject chunk = Instantiate(chunkObject, new Vector3(i * chunkSizeX, 0, o * chunkSizeZ), Quaternion.identity, transform);
                chunk.GetComponent<ChunkCreator>().CreateChunk(chunkHeightValues, chunkSizeX, chunkSizeZ, terrainShader1, terrainMainMaterial);

                yield return new WaitForSeconds(.005f);
            }
        }

        if (combineMeshes)
        {
            CombineMeshes();
        }
    }

    private void CombineMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        mesh.CombineMeshes(combine);
        transform.GetComponent<MeshFilter>().sharedMesh = mesh;
        transform.gameObject.SetActive(true);
    }

    private void GridMaker()
    {
        
    }
}
