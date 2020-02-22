using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject Node;
    public GameObject[] Tiles;
    private Vector3 plrPosition;
    private Vector3 newPoint;
    private GameObject generatedTile;
    enum GeneratedType { Left, Right, Straight, Big };
    GeneratedType previousGen;
    GeneratedType currentGen;
    private int r;
    private int type;

    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(0, 3);
        if (r == 0)
            currentGen = GeneratedType.Left;
        if (r == 1)
            currentGen = GeneratedType.Right;
        if (r == 2)
            currentGen = GeneratedType.Straight;

        plrPosition = Node.transform.position;
        newPoint = plrPosition + new Vector3(0, 0, 7);
        transform.position = newPoint;
        generatedTile = Instantiate(Tiles[r], newPoint, Quaternion.identity);
        print(newPoint);
    }

    // Update is called once per frame
    void Update()
    {
        plrPosition = Node.transform.position;
        if ((plrPosition - newPoint).sqrMagnitude < 20000)
        {
            previousGen = currentGen;
            r = Random.Range(0, 3);
            setTileType(r);
            newPoint = newPoint + new Vector3(0, 0, 7);
            generatedTile = Instantiate(Tiles[type], newPoint, Quaternion.identity);
            transform.position = newPoint;
        }

    }
    private void setTileType(int num)
    {
        if (num == 0)
        {
            if (previousGen != GeneratedType.Left)
            {
                currentGen = GeneratedType.Left;
                type = num;
            }
            else
            {
                currentGen = GeneratedType.Right;
                type = 1;
            }

        }
        if (num == 1)
        {
            if (previousGen != GeneratedType.Right)
            {
                currentGen = GeneratedType.Right;
                type = r;
            }
            else
            {
                currentGen = GeneratedType.Left;
                type = 0;
            }
        }
        if (num == 2)
        {
            currentGen = GeneratedType.Straight;
            type = r;
        }
    }
}
