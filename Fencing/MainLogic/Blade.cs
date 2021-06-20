using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Fencing
{
    public class Blade : MonoBehaviour
    {
        Rigidbody handRb;

        //  float speedX;
        //   float speedY;

        float AcceptableMinImpulse = 0.2f;

        ///public ScoreCounter SC;
        
        Balloon ballon;
        FlyingSword flyingSword;

        private Material otherMaterial;

        private void Start()
        {
            //SC = FindObjectOfType<ScoreCounter>();
            handRb = GameObject.Find("HandColliderRight(Clone)").GetComponent<Rigidbody>();
        }

        /* public void AddScore(Light light)
         {
             light.Off();
             SC.AddScore();
             Debug.Log(SC.score);
         }
         public void Punch(Light light, float velocity)
         {
             if (velocity >= AcceptableMinImpulse)
             {
                 if (light.PositiveImpulse && velocity > 0)
                     AddScore(light);
                 else if (!light.PositiveImpulse && velocity < 0)
                     AddScore(light);
             }
         }*/

        private void OnTriggerEnter(Collider other)
        {
            otherMaterial = other.gameObject.GetComponent<Material>();

            /* if (otherMaterial != null)
             {
                 float Velocity;

                 if (otherMaterial == )
                 {
                     if(light.axis == Light.Axis.x)
                     {
                         Velocity = handRb.velocity.x;
                         Debug.Log("x: "+handRb.velocity.x);
                         Punch(light, Velocity);
                         SC.AddScore();
                     }
                     else
                     {
                         Velocity = handRb.velocity.z;
                         Debug.Log("z: " + handRb.velocity.z);
                         Punch(light, Velocity);
                         SC.AddScore();
                     }

                 }
             }*/
            if (other.gameObject.GetComponent<Balloon>() != null)
            {
                ballon = other.gameObject.GetComponent<Balloon>();
                ballon.ApplyDamage();
                //SC.AddScore();
            }
            //if (other.gameObject.GetComponent<FlyingSword>() != null)
            //{
            //    flyingSword = other.gameObject.GetComponent<FlyingSword>();
            //    flyingSword.TriggerEnter();
            //    SC.AddScore();
            //}
        }
    }
}