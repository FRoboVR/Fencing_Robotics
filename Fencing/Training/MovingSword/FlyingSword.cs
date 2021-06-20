using Fencing;
using System.Collections;
using UnityEngine;

public class FlyingSword : MonoBehaviour
{
    Rotator rotator;
    public float DropDestroyTime = 2f;


    SwordSpawner Sp;
    bool IsActive = true;
    private void Start()
    {
        Sp = FindObjectOfType<SwordSpawner>();
        rotator = GetComponent<Rotator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Camera>() != null && IsActive)
        {
            IsActive = false;
            TriggerEnter();
        }
        if (other.GetComponent<Sword>() != null && IsActive)
        {
            IsActive = false;
            TriggerEnter();

            if (GetComponent<AudioSource>() != null)
                GetComponent<AudioSource>().Play();

            Sp.AddScore();
        }

    }
    public void TriggerEnter()
    {

        rotator.BladeOnCollisionEnter();
        StartCoroutine(Destroy(DropDestroyTime));
    }

    public IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
