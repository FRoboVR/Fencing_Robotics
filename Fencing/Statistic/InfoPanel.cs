using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zzeerr.game;

public class InfoPanel : MonoBehaviour
{
        
    #region Singlton:InfoPanel


    public static InfoPanel Instance;

    void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #endregion

    [SerializeField]
    Text txt;
    public void AppendText(TopItem topItem)
    {
        txt.text += topItem.name + ":  " + topItem.score + "\n";
    }
    public void ClearTxt()
    {
        txt.text = "";
    }

    private void Start()
    {
        Server.Instance.GetTop("LightsMiddleTime", "max", 5);
    }
}
