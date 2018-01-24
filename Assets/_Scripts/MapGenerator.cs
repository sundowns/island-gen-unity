using UnityEngine;

namespace Assets._Scripts
{
    public class MapGenerator : MonoBehaviour
    {
        //https://www.youtube.com/watch?v=WP-Bm65Q-1Y

        public int Width;
        public int Height;
        public float NoiseScale;
        public bool AutoUpdate;

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GenerateMap();
            }
        }
        public void GenerateMap ()
        {
            float[,] noiseMap = Noise.GenerateNoiseMap(Width, Height, NoiseScale);
            MapDisplay display = FindObjectOfType<MapDisplay>();
            display.DrawNoiseMap(noiseMap);
        }
    }
}
