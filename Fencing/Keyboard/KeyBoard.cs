using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour
{

    public Text txt;

    public string stroka;
    
    public void Enter(string bukva)
    {
        stroka += bukva;
        UpdateTxt();
    }
    public void BackSpace()
    {
        string tmp = "";
        for (int i = 0; i < stroka.Length-1; i++)
        {
            tmp += stroka[i];
        }
        stroka = tmp;
        UpdateTxt();
    }

    void UpdateTxt()
    {
        txt.text = stroka;
    }

}
