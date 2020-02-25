using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject Node;
    public GameObject[] Tiles;
    private Vector3 plrPosition;
    private Vector3 newPoint;
    private GameObject generatedTile;
    GameObject previousTile;
    private int r;
    private int left, right;

    // Start is called before the first frame update
    void Start()
    {
        plrPosition = Node.transform.position;
        newPoint = plrPosition + new Vector3(0, 0, 10);
        transform.position = newPoint;
        generatedTile = Instantiate(Tiles[2], newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
        previousTile = generatedTile;

    }

    // Update is called once per frame
    void Update()
    {
        plrPosition = Node.transform.position;
        if ((plrPosition - newPoint).sqrMagnitude < 20000)
        {
            r = Random.Range(0, 3);
            makeTileType(r);
        }

    }
    private void makeTileType(int num)
    {
        if (num == 0 && right <= 0)
        {
            left = 3;
            if (previousTile.transform.Find("SideL") != null)
            {
                GameObject side = previousTile.transform.Find("SideL").gameObject;
                side.transform.Rotate(new Vector3(0, 0, 90));
                side.transform.localPosition = new Vector3(-5, 5, 0);
            }
                newPoint = newPoint + new Vector3(-10, 0, 0);
                generatedTile = Instantiate(Tiles[num], newPoint, Quaternion.identity);
                transform.position = newPoint;
        }
        if (num == 1 && left <= 0)
        {
            right = 3;
            if (previousTile.transform.Find("SideR") != null)
            {
                GameObject side = previousTile.transform.Find("SideR").gameObject;
                side.transform.Rotate(new Vector3(0, 0, 90));
                side.transform.localPosition = new Vector3(-5, 5, 0);
            }
                newPoint = newPoint + new Vector3(10, 0, 0);
                generatedTile = Instantiate(Tiles[num], newPoint, Quaternion.identity);
                transform.position = newPoint;
        }
        if (num == 2)
        {
            left--;
            right--;
            newPoint = newPoint + new Vector3(0, 0, 10);
            generatedTile = Instantiate(Tiles[num], newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
            transform.position = newPoint;
        }
        previousTile = generatedTile;
    }
}
