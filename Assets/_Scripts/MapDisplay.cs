using UnityEngine;

namespace Assets._Scripts
{
    public class MapDisplay : MonoBehaviour
    {
        public Renderer TextureRenderer;
        public MeshFilter MeshFilter;
        public MeshRenderer MeshRenderer;

        public void DrawTexture(Texture2D texture)
        {
            TextureRenderer.sharedMaterial.mainTexture = texture;
            //transform plane to our texture size
            TextureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
        }

        public void DrawMesh(MeshData meshData, Texture2D texture) {
            MeshFilter.sharedMesh = meshData.CreateMesh();
            MeshRenderer.sharedMaterial.mainTexture = texture;
        }
    }
}
