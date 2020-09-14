using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0;
    float verticalMove = 0;
    public float runSpeed = 10;
    bool jump = false;
    public bool crouch;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        SoundManager.PlaySound(Sounds.landing);
    }

    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * 10; //slow for ladders
        if ((horizontalMove != 0 || verticalMove != 0 ) && !SoundManager.isPlaying() && !animator.GetBool("IsJumping"))
        {
            SoundManager.PlaySound(Sounds.walk);

        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {            
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        //Interact with dialogue
        if (Input.GetButtonUp("Enter"))
        {

            Debug.Log("Enter");
            SoundManager.PlaySound(Sounds.enter);

            Level.Notify("Enter"); //Notify subsribers for interaction input
        }

        //Interact with dialogue
        if (Input.GetButtonUp("Fire1"))
        {
            //SoundManager.PlaySound(Sounds.click);
            Level.Notify("Fire1");
        }

        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;

    }

    void FixedUpdate()
    {
        //move char
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;       
    }
}
