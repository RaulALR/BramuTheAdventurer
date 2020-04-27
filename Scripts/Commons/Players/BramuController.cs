using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BramuController : MonoBehaviour
{

    public GameObject levelController;
    private Animator animator;
    private float startY;

    public AudioClip jumpClip;
    public AudioClip dieClip;
    private AudioSource playerAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        startY = transform.position.y;
    }

    private void Update()
    {
        bool keyDown = (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"));
        if (keyDown && AllowPositionClick(Input.mousePosition.y))
        {
            BramuJump();
        }
    }

    private void BramuJump()
    {
        bool isGrounded = transform.position.y == startY;
        bool allowLevelJump = GameController.GetGameState() == GameController.EGameState.Playing;

        if (isGrounded && allowLevelJump)
        {
            UpdatePlayerState("BramuJump");
            PlayAudio(jumpClip);
        }
    }

    private void UpdatePlayerState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            UpdatePlayerState("BramuDie");
            PlayAudio(dieClip);
            GameController.SetGameState(GameController.EGameState.Ended);
            GameController.RestartPoint();
        }
        else if (other.gameObject.tag == "Point")
        {
            GameController.IncreasePoint(1);
        }
        else if (other.gameObject.tag == "Point2")
        {
            GameController.IncreasePoint(2);
        }
        else if (other.gameObject.tag == "Point3")
        {
            GameController.IncreasePoint(3);
        }
    }
    private void PlayAudio(AudioClip clip)
    {
        if (SoundController.GetAudioState() == SoundController.EAudioState.On)
        {
            playerAudio.clip = clip;
            playerAudio.Play();
        }
    }

    private bool AllowPositionClick(float input)
    {
        bool allow = false;
        if (input < (Screen.currentResolution.height - (Screen.currentResolution.height / 6)))
        {
            allow = true;
        }
        return allow;
    }
}
