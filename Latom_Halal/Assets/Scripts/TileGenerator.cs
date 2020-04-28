using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject Node,Tile,Room,DownRoom,Generator,MapContainer,Item,Rose,Sword;
    public bool madeDownRoom;
    public int Y_Mod = 0;
    private Vector3 plrPosition;
    private Vector3 newPoint;
    private GameObject generatedTile;
    GameObject previousTile;
    private int left, right, room, r, t;
    private float originY;
    private int count, swordcount = 0;


    // Start is called before the first frame update
    void Start()
    {
        room = 20;
        if (Y_Mod == 0)
        {
            originY = transform.position.y;
            newPoint = transform.position;
        }
        else
        {
            newPoint = transform.position + new Vector3(0, 0, 10);
        }
        transform.position = newPoint;
        generatedTile = Instantiate(Tile, newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
        generatedTile.name = "Straight";
        previousTile = generatedTile;
        generatedTile.transform.parent = MapContainer.transform;

    }

    // Update is called once per frame
    void Update()
    {
        float newScale = 0.05f;
        float swordScale = 0.1f;

        plrPosition = Node.transform.position;
        if ((plrPosition - newPoint).sqrMagnitude < 10000000)
        {
            t = Random.Range(0, 3);
            r = Random.Range(0, 6);
            makeRoomType(r);
            makeTileType(t);
            if(t == 1 && r == 4 && generatedTile.name == "Room")
            {
                if (!GameObject.Find("Item"))
                {
                    //GameObject _item = Instantiate(Item, generatedTile.transform.position, Quaternion.identity);
                    //_item.name = "Item";
                    //Debug.Log("ITEM SPAWNED");
                }
                else
                {
                    //Debug.Log("ITEm ALREADY SPAWNED");
                }
            }
        }

        //Theresa.  Put a rose in every 4th tile
        //if (generatedTile.name == "Left" && count == 1)
        if (count == 4)
        {
            Rose.transform.localScale = new Vector3(newScale, newScale, newScale);
            //Vector3                                                     back/forth  up/down  left/right
            Rose.transform.position = generatedTile.transform.position + new Vector3(-4, 0, -4);
            GameObject _rose = Instantiate(Rose, Rose.transform.position, Quaternion.identity);
            _rose.name = "Rose";
            count = 0;
        }
        
        else
        {
            count++;
        }
        
        if (swordcount == 10)
        {
            Sword.transform.localScale = new Vector3(swordScale, swordScale, swordScale);
            Sword.transform.position = generatedTile.transform.position + new Vector3(-1, 1, 1);
            GameObject _sword = Instantiate(Sword, Sword.transform.position, Quaternion.identity);
            _sword.name = "Sword";
            swordcount = 0;
        }
        else
        {
            swordcount++;
        }


    }//end of Update

    private void makeRoomType(int num)
    {
        if (num == 5 && room <= 0 && !madeDownRoom)
        {
            makeDownRoom();
        }
        if (num < 4 && room <= 0)
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
        generatedTile.transform.parent = MapContainer.transform;
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
            newPoint.y = Y_Mod + originY;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
            generatedTile.name = "Left";
            transform.position = newPoint;
            Destroy(previousTile.transform.Find("SideL").Find("Door").gameObject);
        }
        else
        {
            newPoint = newPoint + new Vector3(-10, 0, 0);
            newPoint.y = Y_Mod + originY;
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
            newPoint.y = Y_Mod + originY;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.identity);
            generatedTile.name = "Right";
            transform.position = newPoint;
            Destroy(previousTile.transform.Find("SideR").Find("Door").gameObject);
        }
        else
        {
            newPoint = newPoint + new Vector3(10, 0, 0);
            newPoint.y = Y_Mod + originY;
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
            newPoint.y = Y_Mod + originY;
            generatedTile = Instantiate(Tile, newPoint, Quaternion.Euler(new Vector3(0, 90, 0)));
            generatedTile.name = "Straight";
            transform.position = newPoint;
            Destroy(previousTile.transform.Find("SideF").Find("Door").gameObject);
        }
        else
        {
            newPoint = newPoint + new Vector3(0, 0, 10);
            newPoint.y = Y_Mod + originY;
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
            newPoint.y = Y_Mod + originY;
            generatedTile = Instantiate(Room, newPoint, Quaternion.Euler(new Vector3(0, -90, 0)));
            generatedTile.name = "Room";
            Destroy(generatedTile.transform.Find("SideB").Find("Door").gameObject);
            transform.position = newPoint;
            previousTile = generatedTile;
        }
        if (previousTile.name == "Right")
        {
            room = 20;
            newPoint = newPoint + new Vector3(25, 0, 0);
            newPoint.y = Y_Mod + originY;
            generatedTile = Instantiate(Room, newPoint, Quaternion.Euler(new Vector3(0, -90, 0)));
            generatedTile.name = "Room";
            Destroy(generatedTile.transform.Find("SideL").Find("Door").gameObject);
            transform.position = newPoint;
            previousTile = generatedTile;
        }
        if (previousTile.name == "Left")
        {
            room = 20;
            newPoint = newPoint + new Vector3(-25, 0, 0);
            newPoint.y = Y_Mod + originY;
            generatedTile = Instantiate(Room, newPoint, Quaternion.Euler(new Vector3(0, -90, 0)));
            generatedTile.name = "Room";
            Destroy(generatedTile.transform.Find("SideR").Find("Door").gameObject);
            transform.position = newPoint;
            previousTile = generatedTile;
        }
        generatedTile.transform.parent = MapContainer.transform;
    }
    private void makeDownRoom()
    {
        madeDownRoom = true;
        GameObject beforeDownRoom = previousTile;
        makeNormalRoom();
        Destroy(generatedTile);
        generatedTile = Instantiate(DownRoom, previousTile.transform.position, Quaternion.Euler(new Vector3(0, -90, 0)));
        generatedTile.name = "Room";
        if (beforeDownRoom.name == "Left")
            Destroy(generatedTile.transform.Find("SideR").Find("Door").gameObject);
        if (beforeDownRoom.name == "Right")
            Destroy(generatedTile.transform.Find("SideL").Find("Door").gameObject);
        if (beforeDownRoom.name == "Straight")
            Destroy(generatedTile.transform.Find("SideB").Find("Door").gameObject);

        previousTile = generatedTile;
        generatedTile.transform.parent = MapContainer.transform;

        makeNewFloor();
    }

    private void makeNewFloor()
    {
        GameObject g = Instantiate(Room, previousTile.transform.position - new Vector3(0, 30, 0), Quaternion.Euler(new Vector3(0, -90, 0)));
        Destroy(g.transform.Find("SideF").Find("Door").gameObject);
        Destroy(g.transform.Find("Ceil").gameObject);

        GameObject gen = Instantiate(Generator, g.transform.position + new Vector3(0, 0, 15), Quaternion.identity);
        gen.GetComponent<TileGenerator>().originY = originY;
        gen.GetComponent<TileGenerator>().Y_Mod = Y_Mod - 30;
        gen.GetComponent<TileGenerator>().Item = Item;
        gen.GetComponent<TileGenerator>().Item = Rose;
        gen.GetComponent<TileGenerator>().Item = Sword;
        gen.GetComponent<TileGenerator>().Generator = Generator;
        gen.GetComponent<TileGenerator>().MapContainer = MapContainer;
        gen.GetComponent<TileGenerator>().Node = Node;
        gen.GetComponent<TileGenerator>().Tile = Tile;
        gen.GetComponent<TileGenerator>().Room = Room;
        gen.GetComponent<TileGenerator>().DownRoom = DownRoom;
    }
}
