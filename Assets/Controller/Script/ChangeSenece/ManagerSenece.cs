using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManagerSenece : MonoBehaviour
{
    public static ManagerSenece instance;
    [SerializeField] public static GameObject startUI;
    public bool checkReturn = false;
    public  bool passLevel1 = true;
    public  bool passLevel2 = false;
    public  bool passLevel3 = false;
    public bool checkWin = false;

    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;


    [SerializeField] public int passPoints = 1;
    [SerializeField] public int accountStar;
    [SerializeField] public int level;
    public int checkLevelCurrent = 0;
    public  Dictionary<int , int > levelStar = new Dictionary<int , int >();
    public Dictionary<int, bool> levelPass = new Dictionary<int, bool>();

    public List<GameObject> listStar1 = new List<GameObject>();

    public Dictionary<GameObject, int> listStar2 = new Dictionary<GameObject, int>();

    public Dictionary<GameObject, int> listStar3 = new Dictionary<GameObject, int>();

    public static List<ListStarLevel1> dsStar1 = new List<ListStarLevel1>();
    public static List<ListStarLevel2> dsStar2 = new List<ListStarLevel2>();

    public static List<ListStarLevel3> dsStar3 = new List<ListStarLevel3>();
    public static Volume volumeSound;
    public static Slider slider;


    public int increseLevel = 1;
    public float volumeValue = 1f;

    public bool checkStop = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Start()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Update()
    {


   
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {

        GetStartUI();
        GetStarl1();
        GetStarl2();
        GetStarl3();
        GetVolume();
        Dictionary<int, int> levelData = SaveSystem.LoadLevel();
        if (levelData != null)
        {
            levelStar = levelData;
        }

        ShowStar();
        Dictionary<int, bool> levelDataPass = SaveSystem.LoadLevelPass();
        if(levelDataPass != null)
        {
            levelPass = levelDataPass;
        }

        int index = SaveSystem.LoadIndex();
        if(index != -1)
        {
            level = index;
        }


        accountStar = 0;

        if (slider != null)
        {
            slider.value = volumeValue; 
        }
       
      

    }

    private void ShowStar()
    {
        foreach (ListStarLevel1 level in dsStar1)
        {
            if (level != null)
            {



                if (levelStar.ContainsKey(1))
                {
                    if (levelStar[1] == 1)
                    {
                        level.star1.SetActive(true);
                    }
                    if (levelStar[1] == 2)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                    }
                    if (levelStar[1] == 3)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                        level.star3.SetActive(true);
                    }

                }
                break;
            }
        }

        foreach (ListStarLevel2 level in dsStar2)
        {
            if (level != null)
            {
                level.star1.SetActive(false);
                level.star2.SetActive(false);
                level.star3.SetActive(false);


                if (levelStar.ContainsKey(2))
                {
                    if (levelStar[2] == 1)
                    {
                        level.star1.SetActive(true);
                    }
                    if (levelStar[2] == 2)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                    }
                    if (levelStar[2] == 3)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                        level.star3.SetActive(true);
                    }

                }
                break;
            }
        }

        foreach (ListStarLevel3 level in dsStar3)
        {
            if (level != null)
            {
                level.star1.SetActive(false);
                level.star2.SetActive(false);
                level.star3.SetActive(false);


                if (levelStar.ContainsKey(3))
                {
                    if (levelStar[3] == 1)
                    {
                        level.star1.SetActive(true);
                    }
                    if (levelStar[3] == 2)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                    }
                    if (levelStar[3] == 3)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                        level.star3.SetActive(true);
                    }

                }
                break;
            }
        }
    }



    private static void GetVolume()
    {
        Volume[] allGameObject = Resources.FindObjectsOfTypeAll<Volume>();
        foreach(Volume volume in allGameObject)
        {
   
            if (volume)
            {
             volumeSound = volume;
             slider = volumeSound.GetComponent<Slider>();
                slider.value = 1f;
            }
        }

    }

    private static void GetStartUI()
    {
        //startUI = GameObject.FindWithTag("Start");
        GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag("Start"))
            {
                startUI = obj;
                DontDestroyOnLoad(startUI);
                //ShowStartUI();

                break;
            }
        }
    }

    private static void GetStarl1()
    {

        ListStarLevel1[] allGameObjects = Resources.FindObjectsOfTypeAll<ListStarLevel1>();
        foreach (ListStarLevel1 obj in allGameObjects)
        {
            dsStar1.Add(obj);
                
        }
      
    }
    private static void GetStarl2()
    {

        ListStarLevel2[] allGameObjects = Resources.FindObjectsOfTypeAll<ListStarLevel2>();
        foreach (ListStarLevel2 obj in allGameObjects)
        {
            dsStar2.Add(obj);

        }



    }


    private static void GetStarl3()
    {

        ListStarLevel3[] allGameObjects = Resources.FindObjectsOfTypeAll<ListStarLevel3>();
        foreach (ListStarLevel3 obj in allGameObjects)
        {
            dsStar3.Add(obj);

        }



    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ReTurnMenu()
    {

        SceneManager.LoadSceneAsync(1).completed += (AsyncOperation op) =>
        {
            


            if (checkReturn)
            {
                ShowStartUI();

            }

        };

    }
    public void Level1()
    {
        level1 = true;
        SceneManager.LoadSceneAsync(2);
    }
    public void Level2()
    {
        level2 = true;
        SceneManager.LoadSceneAsync(3);
    }
    public void Level3()
    {
        level3 = true;
        SceneManager.LoadSceneAsync(4);
    }
    private void ShowStartUI()
    {

        startUI.SetActive(true);
    }
}
