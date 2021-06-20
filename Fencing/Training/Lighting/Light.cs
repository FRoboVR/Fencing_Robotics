using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fencing
{
    public class Light : MonoBehaviour
    {
        public enum Axis
        {
            x,z
        }

        public Axis axis = 0;
        public bool PositiveImpulse = true;

        public Material[] lights;
        public Color[] colors = new Color[2];

        public float timeToChangeColor = 2f;//
        public float timeToAttack = 10f;//
        public int ChanceToOn = 20;///

        private void Start()
        {
            StartCoroutine(ChangeColor());
        }
        //a
        private void changeColors()
        {
            for (int i = 0; i < lights.Length; i++)
            {
                int value = Random.Range(0, 1);

                if (value == 1)
                    lights[i].color = colors[0];
                else
                    lights[i].color = colors[1];
            }
        }

        IEnumerator ChangeColor()
        {
            changeColors();
            yield return new WaitForSeconds(timeToAttack);
            StartCoroutine(ChangeColor());
        }

    }
}

