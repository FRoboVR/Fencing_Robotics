using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float RotateSpeed = 2f;
    public Vector3[] Offset;

    private bool AllowMove = true;
    Transform target;
    Rigidbody rb;
    Collider collider;

    void Start()
    {
        collider = GetComponentInChildren<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        if (target == null) target = FindObjectOfType<Camera>().transform;
        targetPoint = target.position + Offset[Random.Range(0, Offset.Length)];
    }
    Vector3 targetPoint;
    void FixedUpdate()
    {
        Rotate();
        Move();
    }
    

    void Rotate()
    {
        if (AllowMove)
        {
            //Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
            //targetRotation *= Quaternion.Euler(-90, 0, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (float)(Time.deltaTime * RotateSpeed));
            transform.LookAt(targetPoint);
        }
    }
    void Move()
    {
        if (AllowMove)
        {
            rb.AddForce((transform.forward/*(target.position + new Vector3(0,-0.2f, 0)) - transform.position*/) * MoveSpeed * Time.deltaTime);
        }
    }

    public void BladeOnCollisionEnter()
    {
        rb.velocity = rb.velocity/5;
        //rb.angularVelocity = Vector3.zero;

        AllowMove = false;
        Invoke(nameof(enableGravity), 0.05f);
        //rb.useGravity = true;
    }
    private void enableGravity()
    {
        rb.useGravity = true;
    }
    
}
