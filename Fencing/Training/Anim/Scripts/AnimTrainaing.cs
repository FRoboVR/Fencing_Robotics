using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTrain
{
    public string Triggerkey = "";


    public AnimTrain(string Triggerkey)
    {
        this.Triggerkey = Triggerkey;
    }
}

public class AnimTrainaing : MonoBehaviour
{
    AnimTrain[] trainings = new AnimTrain[]
    {
        new AnimTrain("TestAnim"),
        new AnimTrain("TestAnim2")
    };
    Animator animator;

    public float RetreatSpeed = 0.5f;

    public TargetObj targetObj;

    public bool Contact = false;
    
    public void StartTrain(AnimTrain training)
    {
        targetObj.gameObject.SetActive(true);
        animator.SetTrigger(training.Triggerkey);
        targetObj.ClearTrail();
    }

    private void Update()
    {
        float LastSpeed = animator.speed;

        if (targetObj.gameObject.active)
        {
            if (!Contact) animator.speed = System.Math.Abs(animator.speed) * (-RetreatSpeed);
            else  animator.speed = System.Math.Abs(animator.speed);
            if(LastSpeed != animator.speed) targetObj.ClearTrail();
        }
    }

    public void StopGame()
    {
        targetObj.gameObject.SetActive(false);
    }
}
