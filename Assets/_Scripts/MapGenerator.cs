using UnityEngine;

namespace Assets._Scripts
{
    public class MapGenerator : MonoBehaviour
    {
        //https://www.youtube.com/watch?v=WP-Bm65Q-1Y

        public enum DrawingMode
        {
            NoiseMap,
            ColourMap
        }

        public DrawingMode DrawMode;

        public int Width;
        public int Height;
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

        public void GenerateMap ()
        {
            if (UseRandomSeed)
            {
                Seed = Time.time.GetHashCode();
            }

            float[,] noiseMap = Noise.GenerateNoiseMap(Width, Height, Seed, NoiseScale, Octaves, Persistance, Lacunarity, Offset);

            Color[] colourMap = new Color[Width*Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    float currentHeight = noiseMap[x, y];
                    for (int i = 0; i < Regions.Length; i++) //loop through regions, assigning the correct type based on height!
                    {
                        if (currentHeight <= Regions[i].Height)
                        {
                            colourMap[y * Width + x] = Regions[i].Colour;
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
                display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, Width, Height));
            }
            
        }

        void OnValidate()
        {
            if (Width < 1)
            {
                Width = 1;
            }

            if (Height < 1)
            {
                Height = 1;
            }

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
