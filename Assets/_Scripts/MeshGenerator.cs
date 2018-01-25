using UnityEngine;

namespace Assets._Scripts
{

    //Following https://www.youtube.com/watch?v=4RpVBYW1r5M
    //Could use the existing map generation with a voxel world?
    public static class MeshGenerator {

        public static void GenerateTerrainMesh(float[,] heightMap)
        {
            int width = heightMap.GetLength(0);
            int height = heightMap.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    
                }
            }
        }
    }
}
