using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;


public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    [Scene]
    string mainMenuScene;

    LevelGameState gameState;


    public void OpenMenu()
    {
        StopMusic();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void RestartLevel()
    {
        StopMusic();
        SceneManager.LoadScene(gameState.levelData.scenePath);
    }

    public void NextLevel()
    {   
        StopMusic();
        var nextLevel = gameState.levelData.nextLevel;
        if (nextLevel == null)
            return;

        var nextLevelScene = nextLevel.scenePath;
        SceneManager.LoadScene(nextLevelScene);
    }

    void Start()
    {
        gameState = FindObjectOfType<LevelGameState>();
    }

    void StopMusic()
    {
        this.GetComponentInParent<AmbienceSoundController>().StopCurrentMusic();
    }
}
