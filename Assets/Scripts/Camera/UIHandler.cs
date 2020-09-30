using System;
using Mirror;
using TMPro;
using UnityEngine;
using OOO.Utils;
using UnityEngine.UI;


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
        GameObject[] starsComplete;

        [SerializeField]
        Slider elapsedTimeSlider;

        [SerializeField]
        Slider[] starSliders;


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

            
            _SetSliders();




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
            elapsedTimeSlider.value = (float)gameState.TotalTime-(float)gameState.ElapsedTime;

        }


        private void _RenderScore()
        {
            var val = gameState.score;

            foreach (var s in stars) { s.SetActive(false); }
            foreach (var s in starsComplete) { s.SetActive(false); }

            switch (val)
            {
                case 3:
                    stars[0].SetActive(true);
                    stars[1].SetActive(true);
                    stars[2].SetActive(true);

                    starsComplete[0].SetActive(true);
                    starsComplete[1].SetActive(true);
                    starsComplete[2].SetActive(true);

                    break;

                case 2:
                    stars[0].SetActive(true);
                    stars[1].SetActive(true);

                    starsComplete[0].SetActive(true);
                    starsComplete[1].SetActive(true);

                    break;

                case 1:
                    stars[0].SetActive(true);

                    starsComplete[0].SetActive(true);

                    break;

                default:
                    break;
            }

        }

        private void _SetSliders()
        {
            elapsedTimeSlider.maxValue = (float)gameState.TotalTime;
            elapsedTimeSlider.value = (float)gameState.TotalTime;


            starSliders[0].maxValue = (float)gameState.TotalTime;
            starSliders[1].maxValue = (float)gameState.TotalTime;
            starSliders[2].maxValue = (float)gameState.TotalTime;

            starSliders[0].value = (float)gameState.TotalTime-gameState.levelData.rank3Stars;
            starSliders[1].value = (float)gameState.TotalTime-gameState.levelData.rank2Stars;
            starSliders[2].value = (float)gameState.TotalTime-gameState.levelData.rank1Stars;

        }

    }


}