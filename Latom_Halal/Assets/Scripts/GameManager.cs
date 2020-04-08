using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab, GeneratorPrefab, MonsterPrefab, AudioManagerPrefab;
    public Material WallMat;
    private GameObject playerObj,monsterObj,generatorObj, audioManagerObj;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start!");
        GameObject map = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        //Theresa - Player is now a gameobject already existing in the scene.
        //playerObj = Instantiate(PlayerPrefab, new Vector3(0,0,0), Quaternion.identity);
        generatorObj = Instantiate(GeneratorPrefab, new Vector3(0,-5,0), Quaternion.identity);
        audioManagerObj = Instantiate(AudioManagerPrefab);

        map.name = "Map Container";
        generatorObj.GetComponent<TileGenerator>().MapContainer = map;
        //THeresa change - character controller variables not being found.  Made Player a gameobject already in the scene
        //generatorObj.GetComponent<TileGenerator>().Node = playerObj;
        generatorObj.GetComponent<TileGenerator>().Node = PlayerPrefab;
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
