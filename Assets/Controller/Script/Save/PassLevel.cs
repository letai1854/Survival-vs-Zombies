using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class PassLevel 
{
    public Dictionary<int,bool> level;
    
    public PassLevel(Dictionary<int, bool> levelStar)
    {
        this.level = levelStar;
    }
}
