using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    public int xSize = 3200;
    public int zSize = 3200;
    public int chunkSizeX = 100;
    public int chunkSizeZ = 100;
    public GameObject chunkObject;
    public TextAsset[] csvFiles; // Assign the CSV file in the Inspector
    float[,] heightValues = new float[3200, 3200];

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

                foreach(string value in values)
                {
                    if (value.Length < 1) continue;
                    heightValues[y, x] = float.Parse(value);
                    x++;

                    if (x == 3200)
                    {
                        y++;
                        x = 0;
                    }  
                }
            }
        }

        // Generating chunks (only 16 for now)
        for (int i = 0; i < 6; i++)
        {
            for (int o = 0; o < 3; o++)
            {
                float[,] chunkHeightValues = new float[chunkSizeX + 1, chunkSizeZ + 1];

                // Copying a subsection of the array
                for (int g = 0; g <= chunkSizeX; g++)
                {
                    for (int h = 0; h <= chunkSizeX; h++)
                    {
                        print("H: " + h + " , " + "G: " + g);
                        chunkHeightValues[h, g] = heightValues[h + i * chunkSizeX, g + o * chunkSizeZ];
                    }
                }

                GameObject chunk = Instantiate(chunkObject, new Vector3(i * chunkSizeX, 0, o * chunkSizeZ), Quaternion.identity, transform);
                chunk.GetComponent<ChunkCreator>().CreateChunk(chunkHeightValues, chunkSizeX, chunkSizeZ, i * chunkSizeX, o * chunkSizeZ);
            }
        }
    }
}
