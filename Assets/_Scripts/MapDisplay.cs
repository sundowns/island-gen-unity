using UnityEngine;

namespace Assets._Scripts
{
    public class MapDisplay : MonoBehaviour
    {
        public Renderer TextureRenderer;

        public void DrawNoiseMap(float[,] noiseMap)
        {
            int width = noiseMap.GetLength(0);
            int height = noiseMap.GetLength(1);

            var texture = new Texture2D(width, height);
            
            Color[] colourMap = new Color[width * height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
                }
            }

            texture.SetPixels(colourMap);
            texture.Apply();

            TextureRenderer.sharedMaterial.mainTexture = texture;
            //transform plane to our texture size
            TextureRenderer.transform.localScale = new Vector3(width, 1, height);
        }
    }
}
