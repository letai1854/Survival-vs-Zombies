//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class ManagerScence2 : MonoBehaviour
//{
//    public static ManagerScence2 instance;
//    [SerializeField] public static GameObject startUI;
//    public bool checkReturn = false;
    
//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);


//        }
//        else
//        {
//            Destroy(gameObject);
//        }

//    }


//    public void ReTurnMenu()
//    {
//        SceneManager.LoadSceneAsync(1).completed += (AsyncOperation op) =>
//        {
//            startUI = GameObject.FindWithTag("Start");


//            if (checkReturn)
//            {
//                ShowStartUI();

//            }

//        };

//    }
//    public void Level1()
//    {
//        SceneManager.LoadSceneAsync(2);
//    }
//    public void Level2()
//    {
//        SceneManager.LoadSceneAsync(3);
//    }
//    public void Level3()
//    {
//        SceneManager.LoadSceneAsync(4);
//    }
//    private void ShowStartUI()
//    {

//        startUI.SetActive(true);
//    }
//}
