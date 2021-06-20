using Fencing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTracker : GameController
{
    public GameObject MovingObj;
    Animator animator;
    public float MoveSpeed;
    const int Denominator = 1;
    private const double DistForChangeDir = 0.15;
    public bool AllowMoving = false;

    public GameObject Player;

    float TargetDistance = 2;
    float CriticalMinDistance = 0.5f;
    float CriticalMaxDistance;

    public float timeActionMin = 0.2f;
    public float timeActionMax = 2f;

    public Text txt_dist;

    private bool InAction = false;

    Vector3 StartPos;

    private void Start()
    {
        Player = Camera.main.gameObject;
        animator = GetComponent<Animator>();
        StartPos = transform.position;

        CriticalMaxDistance = TargetDistance * 2;
    }

    private void Update()
    {
        if (Active)
        {
            float dist = CheckDistance();
            txt_dist.text = Math.Round(dist, 2).ToString();
            if ((dist > TargetDistance + DistForChangeDir) || (dist < TargetDistance - DistForChangeDir))
            {
                txt_dist.color = Color.red;
            }
            else
            {
                txt_dist.color = Color.green;
            }
            
            if(dist <= CriticalMinDistance)
            {
                int dir = UnityEngine.Random.RandomRange(0, 1);
                Debug.Log(dir);
                switch (dir)
                {
                    case 0:
                        animator.SetBool("forward", false);
                        animator.SetBool("backward", true);
                        break;
                    case 1:
                        animator.SetBool("forward", false);
                        animator.SetBool("backward", false);
                        break;
                }
            }

            if (dist >= CriticalMaxDistance)
            {
                int dir = UnityEngine.Random.RandomRange(0, 1);
                Debug.Log(dir);
                switch (dir)
                {
                    case 0:
                        animator.SetBool("backward", false);
                        animator.SetBool("forward", true);
                        break;
                    case 1:
                        animator.SetBool("forward", false);
                        animator.SetBool("backward", false);
                        break;
                }
            }

            if (!InAction)
            {
                float time = UnityEngine.Random.RandomRange(timeActionMin, timeActionMax);
                StartCoroutine(ChangeDirection(time));
            }


            if (AllowMoving)
            {
                if (animator.GetBool("forward")) transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward * -1, MoveSpeed * Time.deltaTime);
                else if (animator.GetBool("backward")) transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward, MoveSpeed * Time.deltaTime);
            }
        }

    }

    public override void StartGame()
    {
        base.StartGame();
        transform.position = StartPos;
    }

    public override void EndGame()
    {
        base.EndGame();
        transform.position = StartPos;
    }

    public void StartStep()
    {
        AllowMoving = true;
    }

    public void EndStep()
    {
        AllowMoving = false;
    }

    float CheckDistance()
    {
        Vector2 FirstPos = new Vector2(MovingObj.transform.position.x,MovingObj.transform.position.z);
        Vector2 SecondPos = new Vector2(Player.transform.position.x, Player.transform.position.z);

        float dist = Vector2.Distance(FirstPos, SecondPos);
        Debug.Log(dist);
        return dist;
    }

    IEnumerator ChangeDirection(float time)
    {
        InAction = true;
        yield return new WaitForSeconds(time);

        float dist = CheckDistance();
        

        int dir = UnityEngine.Random.RandomRange(0, 2);
        Debug.Log(dir);
        switch (dir)
        {
            case 0:
                animator.SetBool("backward", false);
                animator.SetBool("forward", true);
                break;
            case 1:
                animator.SetBool("forward", false);
                animator.SetBool("backward", true);
                break;
            case 2:
                animator.SetBool("forward", false);
                animator.SetBool("backward", false);
                break;
        }
        InAction = false;
    }

}
