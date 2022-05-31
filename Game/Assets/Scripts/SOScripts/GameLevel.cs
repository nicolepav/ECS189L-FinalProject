using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Level", menuName = "GameLevel")]
public class GameLevel : ScriptableObject
{
    public int levelIndex;
    public string levelName;
    public string levelDescription;
    public Object levelScene;
    public Vector2 spawnLocation;
}
