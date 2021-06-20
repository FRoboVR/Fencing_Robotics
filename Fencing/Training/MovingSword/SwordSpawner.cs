using Fencing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordSpawner : GameController
{
    public float Score = 0;
    public int maxSwords = 30;
    private int CountSwords = 0;

    public float SpawnTime = 2f;//
    public float MoveSpeed = 2f;//
    public float RotateSpeed = 2f;

    public float DropDestroyTime = 2f;

    public GameObject Sword;

    public Vector3 SpawnPos_1;
    public Vector3 SpawnPos_2;

    [SerializeField]
    private Vector3[] Offset;

    private List<GameObject> SpawnedSword = new List<GameObject>();

    public Text txt_countSwords;
    public Text txt_score;
    public Text txt_result;

    void Start()
    {
        ///base.Start();
        InvokeRepeating(nameof(Spawn), 0, SpawnTime);
    }

    public override void StartGame()
    {
        base.StartGame();
        Score = 0;
        CountSwords = maxSwords;
        txt_countSwords.text = CountSwords.ToString();
        txt_score.text = Score.ToString();
        txt_result.text = "";
    }

    void Spawn()
    {
        if (Active && CountSwords > 0)
        {

            Vector3 pos = new Vector3(Random.Range(SpawnPos_1.x, SpawnPos_2.x), Random.Range(SpawnPos_1.y, SpawnPos_2.y), Random.Range(SpawnPos_1.z, SpawnPos_2.z));
            GameObject sw = Instantiate(Sword, pos, Quaternion.identity);
            SpawnedSword.Add(sw);
            Rotator swR = sw.GetComponent<Rotator>();
            swR.MoveSpeed = MoveSpeed;
            swR.RotateSpeed = RotateSpeed;

            swR.Offset = Offset;

            FlyingSword swS = sw.GetComponent<FlyingSword>();
            swS.DropDestroyTime = DropDestroyTime;
            CountSwords--;
            
            if (CountSwords <= 0)
            {
                txt_score.text = "";
                txt_countSwords.text = "";
                txt_result.text = Score.ToString() + "/" + maxSwords.ToString();
            }else txt_countSwords.text = CountSwords.ToString();
        }   
    }
    public override void EndGame()
    {
        base.EndGame();
        foreach (var item in SpawnedSword)
        {
            //SpawnedSword.Remove(item);
            Destroy(item);           
        }
    }

    public void AddScore()
    {
        Score++;
        
        if(CountSwords <= 0)
        {
            txt_score.text = "";
            txt_countSwords.text = "";
            txt_result.text = Score.ToString() + "/"+ maxSwords.ToString();
        }
        else txt_score.text = Score.ToString();
    }
}
