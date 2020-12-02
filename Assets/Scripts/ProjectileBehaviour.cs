using System;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
   public float speed = 2f;
   public Rigidbody2D rb;
   private void Start()
   {
      rb.velocity = transform.right * speed;
   }
   private void OnCollisionEnter2D(Collision2D collision2D)
   {
      if (!collision2D.gameObject.name.Equals("PennyPixel Variant"))
      {
         Destroy(gameObject);
      }
   }
}
