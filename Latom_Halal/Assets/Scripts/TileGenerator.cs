using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject Node,Tile,Room,DownRoom,Generator;
    public bool madeDownRoom;
    public int Y_Mod = 0;
    private Vector3 plrPosition;
    private Vector3 newPoint;
    private GameObject generatedTile;
    GameObject previousTile;
    private int left, right, room, r,t;


    // Start is called before the first frame update
    void Start()
    {
            room = 20;
            newPoint = transform.position + new Vector3(0, 0, 10);
            transform.position = newPoint;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
            generatedTile.name = "Straight";
            previousTile = generatedTile;
    }

    // Update is called once per frame
    void Update()
    {
        plrPosition = Node.transform.position;
        if ((plrPosition - newPoint).sqrMagnitude < 10000000)
        {
            t = Random.Range(0, 3);
            r = Random.Range(0, 14);
            makeRoomType(r);
            makeTileType(t);
        }
    }

    private void makeRoomType(int num)
    {
        if (num == 13 && room <= 0 && !madeDownRoom)
        {
            makeDownRoom();
        }
        if (num < 6 && room <= 0)
        {
            makeNormalRoom();
        }
        
    }

    private void makeTileType(int num)
    {
        room--;
        //generate left tile
        if (num == 0 && right <= 0)
        {
            makeLeftTile();
        }
        //generate right tile
        if (num == 1 && left <= 0)
        {
            makeRightTile();
        }
        //generate straight tile
        if (num == 2)
        {
            makeStraightTile();
        }
        previousTile = generatedTile;
    }
    private void makeLeftTile()
    {
        left = 3;
        if (previousTile.name == "Straight")
        {
            GameObject side = previousTile.transform.Find("SideL").gameObject;
            side.transform.Rotate(new Vector3(0, 0, 90));
            side.transform.localPosition = new Vector3(-5, 5, 0);
        }
        if (previousTile.name == "Room")
        {
            newPoint = newPoint + new Vector3(-25, 0, 0);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
            generatedTile.name = "Left";
            transform.position = newPoint;
            //new generator here
        }
        else
        {
            newPoint = newPoint + new Vector3(-10, 0, 0);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
            generatedTile.name = "Left";
            transform.position = newPoint;
        }
    }
    private void makeRightTile()
    {
        right = 3;
        if (previousTile.name == "Straight")
        {
            GameObject side = previousTile.transform.Find("SideR").gameObject;
            side.transform.Rotate(new Vector3(0, 0, 90));
            side.transform.localPosition = new Vector3(-5, 5, 0);
        }
        if (previousTile.name == "Room")
        {
            newPoint = newPoint + new Vector3(25, 0, 0);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
            generatedTile.name = "Right";
            transform.position = newPoint;
            //new generator here
        }
        else
        {
            newPoint = newPoint + new Vector3(10, 0, 0);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
            generatedTile.name = "Right";
            transform.position = newPoint;
        }
    }
    private void makeStraightTile()
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
        if (previousTile.name == "Room")
        {
            newPoint = newPoint + new Vector3(0, 0, 25);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
            generatedTile.name = "Straight";
            transform.position = newPoint;
            //new generator here
        }
        else
        {
            newPoint = newPoint + new Vector3(0, 0, 10);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
            generatedTile.name = "Straight";
            transform.position = newPoint;
        }
    }
    private void makeNormalRoom()
    {
        if (previousTile.name == "Straight")
        {
            room = 20;
            newPoint = newPoint + new Vector3(0, 0, 25);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Room, newPoint, Quaternion.identity);
            generatedTile.name = "Room";
            transform.position = newPoint;
            previousTile = generatedTile;
        }
        if (previousTile.name == "Right")
        {
            room = 20;
            newPoint = newPoint + new Vector3(25, 0, 0);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Room, newPoint, Quaternion.identity);
            generatedTile.name = "Room";
            transform.position = newPoint;
            previousTile = generatedTile;
        }
        if (previousTile.name == "Left")
        {
            room = 20;
            newPoint = newPoint + new Vector3(-25, 0, 0);
            newPoint.y = Y_Mod;
            generatedTile = Instantiate(Room, newPoint, Quaternion.identity);
            generatedTile.name = "Room";
            transform.position = newPoint;
            previousTile = generatedTile;
        }
    }
    private void makeDownRoom()
    {
        madeDownRoom = true;
        makeNormalRoom();
        Destroy(generatedTile);
        generatedTile = Instantiate(DownRoom, previousTile.transform.position, Quaternion.identity);
        generatedTile.name = "Room";
        previousTile = generatedTile;

        GameObject g = Instantiate(Room, previousTile.transform.position - new Vector3(0,30,0), Quaternion.identity);
        GameObject gen = Instantiate(Generator, g.transform.position + new Vector3(0,0,15), Quaternion.identity);
        gen.GetComponent<TileGenerator>().Y_Mod = Y_Mod-30;
        gen.GetComponent<TileGenerator>().Generator = Generator;
        gen.GetComponent<TileGenerator>().Node = Node;
        gen.GetComponent<TileGenerator>().Tile = Tile;
        gen.GetComponent<TileGenerator>().Room = Room;
        gen.GetComponent<TileGenerator>().DownRoom = DownRoom;
    }
}
