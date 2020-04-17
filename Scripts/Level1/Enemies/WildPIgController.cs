using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPIgController : MonoBehaviour
{
    private Animator animator;

    private Rigidbody2D rb2d;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.left * Random.Range(5f, 10f);
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
        else if (other.gameObject.tag == "Player")
        {
            GameController.SetGameState(GameController.EGameState.Ended);
            StopAnimation();
        }
    }

    private void StopAnimation()
    {
        animator.Play("WildPigIdle");
        rb2d.velocity = Vector2.left * 0f;   
    }
}
