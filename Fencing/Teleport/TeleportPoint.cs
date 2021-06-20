using Fencing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TeleportPoint : MonoBehaviour
{
    [SerializeField]
    GameController GameController;
    [SerializeField]
    BalloonSpawner balloonSpawner;

    static List<TeleportPoint> teleportPoints = new List<TeleportPoint>();

    public void GameOn()
    {
        if (!teleportPoints.Contains(this)) teleportPoints.Add(this);
      //  if (GameController != null) GameController.StartGame();
    ///    if (balloonSpawner != null) balloonSpawner.autoSpawn = true;
    }
    public static void AllGamesOff()
    {
        for (int i = 0; i < teleportPoints.Count; i++)
        {
            TeleportPoint item = teleportPoints[i];
            if (item.GameController != null) item.GameController.EndGame();
            if (item.balloonSpawner != null) item.balloonSpawner.autoSpawn = false;
        }
        
    }
}
