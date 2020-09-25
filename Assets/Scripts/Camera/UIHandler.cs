using System;
using Mirror;
using TMPro;
using UnityEngine;
using OOO.Utils;


namespace OOO.Camera
{
    /** Attached to the Camera obj*/
    public class UIHandler: MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI countdownText;


        [SerializeField]
        TextMeshProUGUI scoreText;


        [SerializeField]
        LevelGameState gameState;

        public void OnGameStart()
        {
            gameState = FindObjectOfType<LevelGameState>();
            if (gameState == null || gameState.levelData == null) {
                Debug.Log($"Missing game state!");
                return;
            }

            countdownText.text = "--:--";
        }

        void Update()
        {
            if (gameState == null)
                return;

            if (gameState.TotalTime > gameState.ElapsedTime)
            {
                var remaining = (int)(gameState.TotalTime - gameState.ElapsedTime);
                var minutes = remaining / 60;
                var seconds = (remaining % 60);

                if (seconds < 10)
                {
                    countdownText.text = minutes + ":" + "0" + seconds;
                }
                else
                {
                    countdownText.text = minutes + ":" + seconds;
                }
            }
            else
            {
                countdownText.text = "00:00";

                EventHub.Instance.FireEvent(
                    new GameOverEvent() { gameOverReasong = GameOverEvent.GameOverReason.TIME_UP }
                );
            }


            scoreText.text = gameState.score.ToString();
        }
    }
}