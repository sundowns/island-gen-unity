using UnityEngine;

namespace Assets._Scripts
{
    public class MapGenerator : MonoBehaviour
    {
        //https://www.youtube.com/watch?v=WP-Bm65Q-1Y

        public enum DrawingMode
        {
            NoiseMap,
            ColourMap,
            Mesh
        }
        public DrawingMode DrawMode;

        /*
        Must be <255. 241 is nice because 240 is divisible by all even numbers up to 12, allowing us to smoothly
        reduce vertices based on distance for performance.  
        */ 
        const int mapChunkSize = 241; 
        [Range(0,6)]
        public int levelOfDetail;

        public float NoiseScale;
        public int Octaves;
        [Range(0,1)]
        public float Persistance;
        public float Lacunarity;
        public Vector2 Offset;
        public int Seed;

        public bool UseRandomSeed;
        public bool AutoUpdate;

        public Terrain[] Regions;
        [Range(0.1f, 1000)]
        public float meshHeightMultiplier;
        public AnimationCurve meshHeightCurve;

        public void GenerateMap ()
        {
            if (UseRandomSeed)
            {
                Seed = Time.time.GetHashCode();
            }

            float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, Seed, NoiseScale, Octaves, Persistance, Lacunarity, Offset);

            Color[] colourMap = new Color[mapChunkSize*mapChunkSize];

            for (int y = 0; y < mapChunkSize; y++)
            {
                for (int x = 0; x < mapChunkSize; x++)
                {
                    float currentHeight = noiseMap[x, y];
                    for (int i = 0; i < Regions.Length; i++) //loop through regions, assigning the correct type based on height!
                    {
                        if (currentHeight <= Regions[i].Height)
                        {
                            colourMap[y * mapChunkSize + x] = Regions[i].Colour;
                            break;
                        }
                    }
                }
            }

            MapDisplay display = FindObjectOfType<MapDisplay>();
            if (DrawMode == DrawingMode.NoiseMap)
            {
                display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
            }
            else if (DrawMode == DrawingMode.ColourMap)
            {
                display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
            } else if (DrawMode == DrawingMode.Mesh) {
                display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
            }
            
        }

        void OnValidate()
        {
            if (Lacunarity < 1)
            {
                Lacunarity = 1;
            }

            if (Octaves < 0)
            {
                Octaves = 0;
            }

        }
    }
    [System.Serializable]
    public struct Terrain
    {
        public string Name;
        public float Height;
        public Color Colour;
    }
}
