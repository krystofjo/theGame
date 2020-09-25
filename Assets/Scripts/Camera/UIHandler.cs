using System;
using Mirror;
using TMPro;
using UnityEngine;
using OOO.Utils;


namespace OOO.Camera
{
    /** Attached to the Camera obj*/
    public class UIHandler : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI countdownText;


        [SerializeField]
        TextMeshProUGUI scoreText;

        [SerializeField]
        GameObject[] stars;


        [SerializeField]
        LevelGameState gameState;

        public void OnGameStart()
        {
            gameState = FindObjectOfType<LevelGameState>();
            if (gameState == null || gameState.levelData == null)
            {
                Debug.Log($"Missing game state!");
                return;
            }

            countdownText.text = "--:--";
        }

        void Update()
        {
            if (gameState == null) return;

            _RenderCountdown();
            _RenderScore();
        }


        private void _RenderCountdown()
        {
            string text = "";

            if (gameState.TotalTime > gameState.ElapsedTime)
            {
                var remaining = (int)(gameState.TotalTime - gameState.ElapsedTime);
                var minutes = remaining / 60;
                var seconds = (remaining % 60);

                if (seconds < 10)
                {
                    text = minutes + ":" + "0" + seconds;
                }
                else
                {
                    text = minutes + ":" + seconds;
                }
            }
            else
            {
                text = "00:00";

                EventHub.Instance.FireEvent(
                    new GameOverEvent() { gameOverReasong = GameOverEvent.GameOverReason.TIME_UP }
                );
            }

            countdownText.text = text;
        }


        private void _RenderScore()
        {
            var val = gameState.score;

            foreach (var s in stars) { s.SetActive(false); }


            switch (val)
            {
                case 3:
                    stars[0].SetActive(true);
                    stars[1].SetActive(true);
                    stars[2].SetActive(true);
                    break;

                case 2:
                    stars[0].SetActive(true);
                    stars[1].SetActive(true);

                    break;

                case 1:
                    stars[0].SetActive(true);

                    break;

                default:
                    break;
            }

        }
    }


}