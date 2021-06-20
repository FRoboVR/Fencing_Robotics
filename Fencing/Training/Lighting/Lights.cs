using Fencing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zzeerr.game;

public class Lights : GameController
{
    [SerializeField]
    private GameObject[] _lights;
    private List<Material> lights = new List<Material>();

    private Color[] colors = { Color.green, Color.red };

    public int maxTargets = 4;

    public float possibleAngle = 90f;
    public float possibleVelocity = 0.8f;


    public float minTime = 1f;
    public float timeToChangeMin = 2f;
    public float timeToChangeMax = 2f;

    private float timer;

    public float maxTimer = 60f;

    private float reactiontime;

    private int score;

    public Text txt_timer;
    public Text txt_score;
    public Text txt_reactiontime;
    public Text txt_end;

    public List<float> AllReactionTime = new List<float>();

    public bool FastChange = true;
    public bool ChangeAlpha = true;
    public bool SendResult = false;

    void Start()
    {
        //base.Start();
		//System.Array.Resize(ref lights, transform.childCount);

        for (int i = 0; i < _lights.Length; i++)
        {
            lights.Add(_lights[i].GetComponent<MeshRenderer>().material);
          //  _lights[i].AddComponent<Sphere>();
        }

        /*  topItem.discipline = "LightsMiddleTime";
          topItem.name = "TestName";
          topItem.score = "dff";*/
        

    }


    public override void StartGame()
    {
        if (!Active) StartCoroutine(Coroutine(minTime));
        base.StartGame();
        reactiontime = Time.time;
        timer = Time.time + maxTimer;
        score = 0;
        reactiontime = Time.time;
        timer = Time.time + maxTimer;
        txt_score.text = score.ToString();
        txt_reactiontime.text = Math.Abs(Math.Round(reactiontime - Time.time, 1)).ToString();

        topItem.discipline = "LightsMiddleTime";
        topItem.name = "TestName";

    }
    private void Update()
    {
        if (timer - Time.time > 0)
        {
           if(txt_end !=null) StartTxt();
            txt_timer.text = ((int)(timer - Time.time)).ToString();
        }
            
        else
        {
            txt_timer.text = "0";
            if (timer != 0 && SendResult)
            {
                topItem.score = MiddleTime().ToString();
                SendResult();
                Server.Instance.GetTop("LightsMiddleTime", "max", 5);
            }
            base.EndGame();
            
            if (txt_end != null) EndTxt();
        }
    }
    private void changeColor()
    {
        if (Active)
        {
            int counter = 0;

            for (int i = 0; i < lights.Count; i++)
            {
                int value = UnityEngine.Random.Range(0, 2);

                if (value == 0 && counter != maxTargets)
                {
                    lights[i].color = colors[0];
                    reactiontime = Time.time;
                    counter++;
                }
                else
                {
                    Color tmp = colors[1];
                    if(ChangeAlpha) tmp.a = 0;
                    lights[i].color = tmp;
                }
                    
            }
        }
        else
        {
            for (int i = 0; i < lights.Count; i++)
            {
                Color tmp = colors[1];
                if (ChangeAlpha) tmp.a = 0;
                lights[i].color = tmp;
            }
                

            if (txt_end != null) txt_end.text = "Ñ÷¸ò: "+score + "\r\n Ðåàêöèÿ: " + MiddleTime();
        }

    }

    public void EndTxt()
    {
        txt_timer.gameObject.SetActive(false);
        txt_score.gameObject.SetActive(false);
        txt_reactiontime.gameObject.SetActive(false);
        txt_end.gameObject.SetActive(true);
    }

    public void StartTxt()
    {
        txt_timer.gameObject.SetActive(true);
        txt_score.gameObject.SetActive(true);
        txt_reactiontime.gameObject.SetActive(true);
        txt_end.gameObject.SetActive(false);
    }

    private IEnumerator Coroutine(float MinTimeChange)
    {
        if (FastChange) {
            reactiontime = Time.time;
           changeColor();
          
        }
        float waitTime = UnityEngine.Random.RandomRange(MinTimeChange, timeToChangeMax);

        yield return new WaitForSeconds(waitTime);
        if (!FastChange) {
            reactiontime = Time.time;
           changeColor();
        }
        StartCoroutine(Coroutine(minTime));
	}

    public void Interact()
    {
        if (Active)
        {
            if (GetComponent<AudioSource>() != null) GetComponent<AudioSource>().Play();
            score++;
            txt_score.text = score.ToString();
            float rt = Math.Abs(reactiontime - Time.time);
            txt_reactiontime.text = Math.Round(rt, 2).ToString();
            AllReactionTime.Add(rt);

            

            StopAllCoroutines();
            StartCoroutine(Coroutine(timeToChangeMin));

        }
    }

    public float MiddleTime()
    {
        float midTime = 0;
        foreach (var item in AllReactionTime)
        {
            midTime += item;
        }
        midTime /= AllReactionTime.Count;
        midTime = (float)Math.Round(midTime, 2);
        return midTime;
    }
}
