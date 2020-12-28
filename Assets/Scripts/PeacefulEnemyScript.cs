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
    private float timeStamp = 0f;
    private float horizontalMove = 0f;
    public float xOffset = 5.0f;
    private int offsetIndex = 0;
    private Vector2 startingPoint;

    private void Start()
    {
        startingPoint = new Vector2(transform.position.x, transform.position.y);
        timeStamp = Time.time;
    }

    private void Update()
    {
        if (Player.transform.position.x > transform.position.x && !isFacingRight)
            Flip();
        if (Player.transform.position.x < transform.position.x && isFacingRight)
            Flip();
        horizontalMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        Animator.SetFloat("Speed", Math.Abs(horizontalMove));

        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(startingPoint.x + xOffset, startingPoint.y), MoveSpeed * Time.deltaTime);

        if (Time.time >= timeStamp)
        {
            timeStamp = Time.time + 5.0f;
            xOffset = -xOffset;
        }
    }
    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    public IEnumerator DeathCoroutine()
    {
        Animator.SetInteger("State", 1);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}