using UnityEngine;
using UnityEngine.Tilemaps;

public class NumberGenerator : MonoBehaviour
{
    public Tilemap trapsTilemap;
    public Tilemap numberTilemap;
    public Tile[] numberTiles;
    public int startX = 0;
    public int startZ = 0;
    public int width = 100;
    public int height = 100;

    LayerMask trapMask;

    void Start()
    {
        trapMask = LayerMask.GetMask("Traps");

        Vector3 curpos = new Vector3(startX + 0.5f, 0, startZ + 0.5f);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3Int intPos = new Vector3Int(Mathf.FloorToInt(curpos.x), Mathf.FloorToInt(curpos.z), 0);

                int numberOfTraps = GetNumberOfTraps(curpos);
                numberTilemap.SetTile(intPos, numberTiles[numberOfTraps]);

                curpos.x++;
            }
            curpos.x = startX + 0.5f;
            curpos.z++;
        }
    }

    int GetNumberOfTraps(Vector3 pos)
    {
        int count = 0;
        pos.x--;
        pos.z--;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Physics.CheckSphere(pos, 0.01f, trapMask))
                {
                    count++;
                }
                pos.x++;
            }
            pos.x -= 3;
            pos.z++;
        }
        return count;
    }
}
