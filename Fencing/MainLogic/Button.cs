using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Fencing
{
    public class Button : MonoBehaviour
    {
        public UnityEvent Event;

        public Image ProgressBar;

        public float targetTime = 5;
        private float TouchTime = 0;
        private bool Touched;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Sword>() != null)
            {
                Touched = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Sword>() != null)
            {
                Touched = false;
            }
        }

        private void FixedUpdate()
        {
            if (Touched)
            {
                TouchTime += 1;

            }
            else
            {
                TouchTime = 0;
            }

            if (ProgressBar != null) ProgressBar.fillAmount = TouchTime / targetTime;
            if (TouchTime >= targetTime)
            {
                if (GetComponent<AudioSource>() != null) GetComponent<AudioSource>().Play();
                Event.Invoke();
            }
        }
    }

}
