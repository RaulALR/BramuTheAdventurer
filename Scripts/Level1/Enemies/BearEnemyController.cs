using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearEnemyController : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rb2d;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.left * 5.5f; //Random.Range(4f, 7f);
    }

    private void Update()
    {
        if (GameController.GetGameState() == GameController.EGameState.Ended)
        {
            StopAnimation();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    private void StopAnimation()
    {
        animator.Play("BearIdle");
        rb2d.velocity = Vector2.left * 0f;
    }
}
