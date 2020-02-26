using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject Node;
    public GameObject Tile;
    private Vector3 plrPosition;
    private Vector3 newPoint;
    private GameObject generatedTile;
    GameObject previousTile;
    private int left, right, room, r;

    // Start is called before the first frame update
    void Start()
    {
        plrPosition = Node.transform.position;
        newPoint = plrPosition + new Vector3(0, 0, 10);
        transform.position = newPoint;
        generatedTile = Instantiate(Tile, newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
        generatedTile.name = "Straight";
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
        //generate left tile
        if (num == 0 && right <= 0)
        {
            left = 3;
            if (previousTile.name == "Straight")
            {
                GameObject side = previousTile.transform.Find("SideL").gameObject;
                side.transform.Rotate(new Vector3(0, 0, 90));
                side.transform.localPosition = new Vector3(-5, 5, 0);
            }
                newPoint = newPoint + new Vector3(-10, 0, 0);
                generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
                generatedTile.name = "Left";
                transform.position = newPoint;
        }
        //generate right tile
        if (num == 1 && left <= 0)
        {
            right = 3;
            if (previousTile.name == "Straight")
            {
                GameObject side = previousTile.transform.Find("SideR").gameObject;
                side.transform.Rotate(new Vector3(0, 0, 90));
                side.transform.localPosition = new Vector3(-5, 5, 0);
            }
                newPoint = newPoint + new Vector3(10, 0, 0);
                generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
                generatedTile.name = "Right";
                transform.position = newPoint;
        }
        //generate straight tile
        if (num == 2)
        {
            left--;
            right--;
            if (previousTile.name == "Left")
            {
                GameObject side = previousTile.transform.Find("SideR").gameObject;
                side.transform.Rotate(new Vector3(0, 0, 90));
                side.transform.localPosition = new Vector3(-5, 5, 0);
            }
            if (previousTile.name == "Right")
            {
                GameObject side = previousTile.transform.Find("SideR").gameObject;
                side.transform.Rotate(new Vector3(0, 0, 90));
                side.transform.localPosition = new Vector3(5, 5, 0);
            }
            newPoint = newPoint + new Vector3(0, 0, 10);
            generatedTile = Instantiate(Tile, newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
            generatedTile.name = "Straight";
            transform.position = newPoint;
        }
        previousTile = generatedTile;
    }
}
