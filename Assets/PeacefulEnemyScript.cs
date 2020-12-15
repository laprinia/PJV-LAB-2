using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacefulEnemyScript : MonoBehaviour
{
    private bool isFacingRight = true;
    public Animator Animator;
    public Transform Player;
    public float MoveSpeed = 0.4f;
    public int distanceToView = 2;
    private float horizontalMove = 0f;


    private void Update()
    {
        if (Player.transform.position.x > transform.position.x && !isFacingRight)
            Flip();
        if (Player.transform.position.x < transform.position.x && isFacingRight)
            Flip();

        horizontalMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        Animator.SetFloat("Speed", Math.Abs(horizontalMove));
        Vector2 playerXAxis;
        playerXAxis = new Vector2(Player.position.x, Player.position.y);
        if (Vector3.Distance(transform.position, Player.position) >= distanceToView)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerXAxis, MoveSpeed * Time.deltaTime);
        }
    }

    void Flip()
    {
        transform.Rotate(0f,180f,0f);
        isFacingRight = !isFacingRight;
    }

    
    public IEnumerator DeathCoroutine()
    {
        Animator.SetInteger("State",1);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
