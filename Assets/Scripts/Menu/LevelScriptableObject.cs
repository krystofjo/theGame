using UnityEngine;
using FMODUnity;
using Mirror;


[CreateAssetMenu(menuName = "OOO/LevelScriptableObject")]
public class LevelScriptableObject : ScriptableObject
{
    public string levelIdentifier;
    [Scene]
    public string scenePath;

    public LevelScriptableObject nextLevel;

    [EventRef]
    public string levelAmbience;

    [Help("Time required for level (in seconds)")]
    public double timeLimit;

    [Header("Stars")]
    [Help("Rank stars required for level (in seconds)")]
    public float rank3Stars;
    public float rank2Stars;
    public float rank1Stars;
    
}
