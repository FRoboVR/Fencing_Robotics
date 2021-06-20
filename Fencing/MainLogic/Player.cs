using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class Player : MonoBehaviour
{
    public RenderModelChangerUI Rm;
    void Start()
    {
        Rm = GetComponent<RenderModelChangerUI>();
        Rm.ChangeHand();

    }
    GameObject LeftHand;
    private void Update()
    {
       if(LeftHand == null) {LeftHand = GameObject.Find("LeftRenderModel Alien(Clone)");
       if(LeftHand != null) if(LeftHand.active) LeftHand.SetActive(false);}
    }
}
