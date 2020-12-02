using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   public Transform player;
   public float distance = 50.0f;

   private void Awake()
   {
      GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / distance);
   }

   private void Update()
   {
      transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
      
   }
}
