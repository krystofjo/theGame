using UnityEngine;


public class AmbienceSoundController : MonoBehaviour
{
    LevelGameState levelGameState;
    FMOD.Studio.EventInstance ambienceInstance;
    bool isPlayingMusic = false;



    public void OnGameStart()
    {
        levelGameState = FindObjectOfType<LevelGameState>();

        if (levelGameState == null || levelGameState.levelData == null) {
            Debug.LogWarning("Missing assigned LevelScriptableObject for this level!");
            enabled = false;
            return;
        }


            ambienceInstance = FMODUnity.RuntimeManager.CreateInstance(levelGameState.levelData.levelAmbience);
            ambienceInstance.start();
            isPlayingMusic = true;

    }

    public void StopCurrentMusic()
    {   
        if(isPlayingMusic)
        {
        ambienceInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        isPlayingMusic = false;
        }
    }
}
