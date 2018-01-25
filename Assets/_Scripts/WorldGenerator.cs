using Assets._Scripts;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

    public int Width;
    public int Depth;
    public int Height;
    public float BlockWidth;
    public float BlockHeight;
    public GameObject World;

    //public Terrain[] Terrains;

    private Block[,,] Blocks; 
	// Use this for initialization

    public void GenerateWorld()
    {
        Blocks = new Block[Width, Depth, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Depth; y++)
            {
                for (int z = 0; z < Height; z++)
                {
                    if (Blocks[x,y,z] != null)
                    {
                        foreach (Transform child in World.transform)
                        {
                            Destroy(child.gameObject);
                            Destroy(child.GetComponent<Rigidbody>());
                        }
                    } 
                    Blocks[x, y, z] = new Block(new Vector3(x, y, z), World);
                }
            }
        }
    }

    void OnValidate()
    {
        if (Width < 1) {
            Width = 1;
        }

        if (Height < 1) {
            Height = 1;
        }

        if (Depth < 1) {
            Depth = 1;
        }

        if (BlockWidth < 1) {
            BlockWidth = 1;
        }

        if (BlockHeight < 1) {
            BlockHeight = 1;
        }
    }
}

public class Block
{
    public Block(Vector3 position, GameObject world)
    {
        Primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Primitive.AddComponent<Rigidbody>();
        Primitive.transform.position = position;
        Primitive.transform.parent = world.transform;
    }

    public Terrain TerrainType;
    public GameObject Primitive;
}


[System.Serializable]
public struct Terrain
{
    public string Name;
    public float Height;
    public Color Colour;
}