using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController2D controller2D;
    public Animator animator;

    public int health = 3;
    public float runSpeed = 40f;
    float HMove = 0f;
    public bool jump = false;
    public bool crouch = false;

    void Update() {
        HMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("s", Mathf.Abs(HMove));
        if (Input.GetButtonDown("Jump")) { jump = true; }
        if (Input.GetButtonDown("Crouch")) crouch = true;
        else if (Input.GetButtonUp("Crouch")) crouch = false;
    }

    void FixedUpdate() {
        controller2D.Move(HMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
