using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Material otherMaterial;

    //[SerializeField]
    private float possibleAngle = 5f;
    ///[SerializeField]
    private float possibleVelocity = 0.8f;

    private int score;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GameObject.Find("HandColliderRight(Clone)").GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Light>() != null)
        {
            otherMaterial = other.GetComponent<MeshRenderer>().material;

            if (otherMaterial && otherMaterial.color == Color.green &&
                Vector3.Angle(transform.forward, other.transform.position - transform.position) < possibleAngle &&
                _rigidbody.velocity.x > possibleVelocity)
            {
                // score++;

                otherMaterial.color = Color.red;

                Debug.LogError(score);
            }
        }

    }
}
