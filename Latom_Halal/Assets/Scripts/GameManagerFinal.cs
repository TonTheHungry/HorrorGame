using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerFinal : MonoBehaviour
{
    public GameObject PlayerPrefab, GeneratorPrefab, MonsterPrefab, AudioManagerPrefab, GameMenuCanvas;
    public Material WallMat;
    private GameObject playerObj, generatorObj, audioManagerObj, starterCam;
    private List<GameObject> monsterObjs = new List<GameObject>();
    public Slider plrHpSlider;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start!");
        GameObject map = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        playerObj = Instantiate(PlayerPrefab, new Vector3(0,0,0), Quaternion.identity);
        generatorObj = Instantiate(GeneratorPrefab, new Vector3(0,-5,0), Quaternion.identity);
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
        for (int i = 0; i < 4; i++)
        {
            monsterObjs.Add(Instantiate(MonsterPrefab, new Vector3(0, 0, -50+200*i), Quaternion.identity));
            monsterObjs[i].GetComponent<MonsterFollow>().player = playerObj;
            monsterObjs[i].GetComponent<MonsterDamage>().PlrHpSlider = plrHpSlider;
        }
    }
    public void Activate()
    {
        starterCam = GameObject.FindGameObjectWithTag("MainCamera");
        starterCam.SetActive(false);
        playerObj.SetActive(true);
        foreach (var item in monsterObjs)
        {
            item.SetActive(true);
        }
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
        if (playerObj.GetComponent<PlayerController>().HasSword)
        {
            playerObj.SetActive(false);
            starterCam.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GameMenuCanvas.GetComponent<MainMenuScript>().GameWon();
        }
        int randomnum = Random.Range(0, 1200);
        if(randomnum == 666)
        {
                GameObject monster = (Instantiate(MonsterPrefab, playerObj.transform.position + new Vector3(0, 0 , 20), Quaternion.identity));
                monster.GetComponent<MonsterFollow>().player = playerObj;
                monster.GetComponent<MonsterFollow>().speed = 20;
                monster.GetComponent<MonsterDamage>().PlrHpSlider = plrHpSlider;
                monster.SetActive(true);
        }
        
    }
}
