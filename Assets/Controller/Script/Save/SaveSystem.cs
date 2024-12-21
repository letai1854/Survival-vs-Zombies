
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
public static class SaveSystem 
{
   public static void SaveLevel(Dictionary<int, int> levelStar)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/ninja.pq";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveLevel Show = new SaveLevel(levelStar);
        formatter.Serialize(stream, Show);
        stream.Close();
    }

    public static Dictionary<int, int> LoadLevel()
    {
        string path = Application.persistentDataPath + "/ninja.pq";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveLevel levelLoad = formatter.Deserialize(stream) as SaveLevel;
            stream.Close();

            return levelLoad.levelStar;
        }
        else
        {
            Debug.Log("null null null file");
            return null;
        }
       
    }
    public static void SaveLevelPass(Dictionary<int, bool> levelStar)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/ninja.oq";
        FileStream stream = new FileStream(path, FileMode.Create);

        PassLevel Show = new PassLevel(levelStar);
        formatter.Serialize(stream, Show);
        stream.Close();
    }

    public static Dictionary<int, bool> LoadLevelPass()
    {
        string path = Application.persistentDataPath + "/ninja.oq";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PassLevel levelLoad = formatter.Deserialize(stream) as PassLevel;
            stream.Close();

            return levelLoad.level;
        }
        else
        {
            Debug.Log("null null null file bool");
            return null;
        }

    }

    public static void SaveIndex(int i)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/ninja.tq";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveIncreaseLevel increaseLevel = new SaveIncreaseLevel(i);
        formatter.Serialize(stream, increaseLevel);
        stream.Close();
    }

    public static int  LoadIndex()
    {
        string path = Application.persistentDataPath + "/ninja.tq";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveIncreaseLevel levelLoad = formatter.Deserialize(stream) as SaveIncreaseLevel;
            stream.Close();

            return levelLoad.index;
        }
        else
        {
            Debug.Log("null null null file bool");
            return -1;
        }

    }

}
