using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveLevel 
{
    public Dictionary<int, int> levelStar;

    public SaveLevel(Dictionary<int, int> levelStar)
    {
        this.levelStar = levelStar;
    }

}
