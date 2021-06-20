using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Material mat;
    private Rigidbody _rigidbody;

    [SerializeField]
    private Lights parentLights;
    private float possibleAngle;
    private float possibleVelocity;
    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
       
      //  parentLights = transform.parent.GetComponent<Lights>();
        possibleAngle = parentLights.possibleAngle;
        possibleVelocity = parentLights.possibleVelocity;

    }
   private void OnTriggerEnter(Collider other)
    {
       if(_rigidbody ==null) _rigidbody = GameObject.Find("HandColliderRight(Clone)").GetComponent<Rigidbody>();
        if (other.GetComponent<Sword>() != null)
        {
            if (mat.color == Color.green &&
             Vector3.Angle(other.transform.forward, transform.position - other.transform.position) < possibleAngle &&
             _rigidbody.velocity.x > possibleVelocity)
            {
                Color tmp = Color.red;

                if (parentLights.ChangeAlpha) tmp.a = 0;
                mat.color = tmp;
                parentLights.Interact();
            }
           // Debug.Log(Vector3.Angle(other.transform.forward, other.transform.position - transform.position));
        }

    }
   
}
