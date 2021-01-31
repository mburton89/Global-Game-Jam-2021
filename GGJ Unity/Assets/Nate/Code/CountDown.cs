using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
        private TextMeshProUGUI textClock;

        private float countdownTimerDuration;
        private float countdownTimerStartTime;

        void Start()
        {
            textClock = GetComponent<TextMeshProUGUI>();
            CountdownTimerReset(5);
        }

        void Update()
        {
            // default - timer finished
            string timerMessage = "GET READY";
            int timeLeft = (int)CountdownTimerSecondsRemaining();

            if (timeLeft > 0)
                timerMessage = LeadingZero(timeLeft);

            textClock.text = timerMessage;
            
        }

        private void CountdownTimerReset(float delayInSeconds)
        {
            countdownTimerDuration = delayInSeconds;
            countdownTimerStartTime = Time.time;
        }

        private float CountdownTimerSecondsRemaining()
        {
            float elapsedSeconds = Time.time - countdownTimerStartTime;
            float timeLeft = countdownTimerDuration - elapsedSeconds;
            return timeLeft;
        }

        private string LeadingZero(int n)
        {
            return n.ToString().PadLeft(2, '0');
        }
      
}
