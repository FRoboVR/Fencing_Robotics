using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetObj : MonoBehaviour
{
    public AnimTrainaing animTrainaing;
    TrailRenderer trail;

    public void ClearTrail()
    {
        trail.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Sword>()!= null)
        {
            animTrainaing.Contact = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Sword>() != null)
        {
            animTrainaing.Contact = false;
        }
    }
}
