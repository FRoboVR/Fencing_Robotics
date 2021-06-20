using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zzeerr.game;

namespace Fencing
{
    public abstract class GameController : MonoBehaviour
    {
        public bool Active = false;
        public TopItem topItem;

       //public AudioSource AS;

        // public AudioClip defaultTheme;

        // public AudioClip mainTheme;

        //public void Start()
        //{
        //    //AS = GameObject.Find("GlobalAudio").GetComponent<AudioSource>();
        //}

        public virtual void StartGame()
        {
            //AS.clip = mainTheme;
            //AS.Play();
            Active = true;
        }
        public virtual void EndGame()
        {
            //AS.clip = defaultTheme;
            //AS.Play();
            Active = false;
        }

        public void SendResult()
        {
            if(Active && topItem.score !="0") Server.Instance.SendTop(topItem);
        }
    }
}

