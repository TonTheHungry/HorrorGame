using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject Node;
    public GameObject[] Tiles;
    private Vector3 plrPosition;
    private Vector3 newPoint;
    private GameObject generatedTile;
    enum GeneratedType { North, East, South, West };


    // Start is called before the first frame update
    void Start()
    {
        plrPosition = Node.transform.position;
        newPoint = plrPosition + new Vector3(0, 0, 7);
        transform.position = newPoint;
        generatedTile = Instantiate(Tiles[0], newPoint, Quaternion.identity);
        print(newPoint);
    }

    // Update is called once per frame
    void Update()
    {
        plrPosition = Node.transform.position;
        if ((plrPosition - newPoint).sqrMagnitude < 20000)
        {
            newPoint = newPoint + new Vector3(0, 0, 7);
            print("newtile spawn");
            generatedTile = Instantiate(Tiles[0], newPoint, Quaternion.identity);
            transform.position = newPoint;
        }
        
    }
}
