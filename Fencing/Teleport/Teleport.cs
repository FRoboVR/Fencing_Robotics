using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fencing
{
    public class Teleport : MonoBehaviour
    {
        Player player;

        private void Start()
        {
            player = FindObjectOfType<Player>();
        }

        public void Tp(TeleportPoint point)
        {
            player.transform.position = point.transform.position;
            player.transform.rotation = point.transform.rotation;    
            if (point.gameObject.name == "TelportPoint_Spawn") TeleportPoint.AllGamesOff();
            else point.GameOn();
            //end
        }
    }
}

