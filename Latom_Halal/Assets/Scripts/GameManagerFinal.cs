using UnityEngine;
using UnityEngine.UI;

public class GameManagerFinal : MonoBehaviour
{
    public GameObject PlayerPrefab, GeneratorPrefab, MonsterPrefab, AudioManagerPrefab, GameMenuCanvas;
    public Material WallMat;
    private GameObject playerObj,monsterObj,generatorObj, audioManagerObj, starterCam;
    public Slider plrHpSlider;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start!");
        GameObject map = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        playerObj = Instantiate(PlayerPrefab, new Vector3(0,0,0), Quaternion.identity);
        generatorObj = Instantiate(GeneratorPrefab, new Vector3(0,-5,0), Quaternion.identity);
        monsterObj = Instantiate(MonsterPrefab, new Vector3(0,0,-50), Quaternion.identity);
        audioManagerObj = Instantiate(AudioManagerPrefab);
        map.name = "Map Container";
        //Generator dependencies
        generatorObj.GetComponent<TileGenerator>().MapContainer = map;
        generatorObj.GetComponent<TileGenerator>().Node = playerObj;
        generatorObj.GetComponent<TileGenerator>().Node = PlayerPrefab;
        // Capstone for tile generator
        GameObject cap = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cap.transform.position = new Vector3(0, 0, -6);
        cap.GetComponent<Renderer>().material = WallMat;
        cap.transform.localScale = new Vector3(10, 10, 2);
        //Monster dependencies
        plrHpSlider = playerObj.transform.Find("Canvas").transform.Find("HealthBar").GetComponent<Slider>();
        monsterObj.GetComponent<MonsterFollow>().player = playerObj;
        monsterObj.GetComponent<MonsterDamage>().PlrHpSlider = plrHpSlider;
    }
    public void Activate()
    {
        starterCam = GameObject.FindGameObjectWithTag("MainCamera");
        starterCam.SetActive(false);
        playerObj.SetActive(true);
        monsterObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(plrHpSlider.value <= 0 && isGameOver == false)
        {
            isGameOver = true;
            // Game Over
            playerObj.SetActive(false);
            starterCam.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GameMenuCanvas.GetComponent<MainMenuScript>().GameOver();
        }
    }
}
