using UnityEngine;

namespace Assets._Scripts
{
    public class MapDisplay : MonoBehaviour
    {
        public Renderer TextureRenderer;

        public void DrawTexture(Texture2D texture)
        {
            TextureRenderer.sharedMaterial.mainTexture = texture;
            //transform plane to our texture size
            TextureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
        }
    }
}
