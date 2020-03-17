using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab, GeneratorPrefab, MonsterPrefab;
    public Material WallMat;
    private GameObject playerObj,monsterObj,generatorObj;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start!");
        GameObject map = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        map.name = "Map Container";
        playerObj = Instantiate(PlayerPrefab, new Vector3(0,0,0), Quaternion.identity);
        generatorObj = Instantiate(GeneratorPrefab, new Vector3(0,-5,0), Quaternion.identity);
        generatorObj.GetComponent<TileGenerator>().MapContainer = map;
        generatorObj.GetComponent<TileGenerator>().Node = playerObj;
        GameObject cap = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cap.transform.position = new Vector3(0, 0, -6);
        cap.GetComponent<Renderer>().material = WallMat;
        cap.transform.localScale = new Vector3(10, 10, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
