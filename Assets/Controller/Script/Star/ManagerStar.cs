using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerScence2 : MonoBehaviour
{
    public static ManagerScence2 instance;
    [SerializeField] public static GameObject startUI;
    public bool checkReturn = false;
    public bool passLevel1 = true;
    public bool passLevel2 = false;
    public bool passLevel3 = false;
    public bool checkWin = false;
    [SerializeField] public int passPoints = 1;
    [SerializeField] public int accountStar;
    [SerializeField] public int level;
    public int checkLevelCurrent = 0;
    public Dictionary<int, int> levelStar = new Dictionary<int, int>();


    public List<GameObject> listStar1 = new List<GameObject>();

    public Dictionary<GameObject, int> listStar2 = new Dictionary<GameObject, int>();

    public Dictionary<GameObject, int> listStar3 = new Dictionary<GameObject, int>();

    public static List<ListStarLevel1> dsStar1 = new List<ListStarLevel1>();


    private void Awake()
    {
        if (instance == null)
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
        //if (dsStar1.Count > 0)
        //{
        //    Debug.Log("ds1 " + dsStar1[0]);
        //}
        

        
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {

        GetStartUI();
        GetStarl1();
        foreach (ListStarLevel1 level in dsStar1)
        {
            if (level != null)
            {
                level.star1.SetActive(false);
                level.star2.SetActive(false);
                level.star3.SetActive(false);
               

                if (ManagerSenece.instance.levelStar.ContainsKey(1))
                {
                    if (ManagerSenece.instance.levelStar[1] == 1)
                    {
                        level.star1.SetActive(true);
                    }
                    if (ManagerSenece.instance.levelStar[1] == 2)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                    }
                    if (ManagerSenece.instance.levelStar[1] == 3)
                    {
                        level.star1.SetActive(true);
                        level.star2.SetActive(true);
                        level.star3.SetActive(true);
                    }

                }
                break;
            }
        }



        accountStar = 0;


        


    }
    private void ActivateStars(List<GameObject> starList, int count)
    {
        int activated = 0;
        foreach (var star in starList)
        {
            if (activated < count)
            {
                star.gameObject.SetActive(true);
                activated++;
            }
            else
            {
                break;
            }
        }
    }


    private static void GetStartUI()
    {

        GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag("Start"))
            {
                startUI = obj;
                DontDestroyOnLoad(startUI);


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
        SceneManager.LoadSceneAsync(2);
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Level3()
    {
        SceneManager.LoadSceneAsync(4);
    }
    private void ShowStartUI()
    {

        startUI.SetActive(true);
    }
}
