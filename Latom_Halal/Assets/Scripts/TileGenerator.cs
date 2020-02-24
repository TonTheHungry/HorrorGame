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
    private int left, right;

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
            makeTileType(r);
            
        }

    }
    private void makeTileType(int num)
    {
        if (num == 0 && right <= 0)
        {
            left = 3;
                currentGen = GeneratedType.Left;
                newPoint = newPoint + new Vector3(-8, 0, 0);
                generatedTile = Instantiate(Tiles[num], newPoint, Quaternion.identity);
                transform.position = newPoint;
        }
        if (num == 1 && left <= 0)
        {
            right = 3;
                currentGen = GeneratedType.Right;
                newPoint = newPoint + new Vector3(8, 0, 0);
                generatedTile = Instantiate(Tiles[num], newPoint, Quaternion.identity);
                transform.position = newPoint;
        }
        if (num == 2)
        {
            left--;
            right--;
            currentGen = GeneratedType.Straight;
            newPoint = newPoint + new Vector3(0, 0, 8);
            generatedTile = Instantiate(Tiles[num], newPoint, Quaternion.identity);
            transform.position = newPoint;
        }
    }
}
