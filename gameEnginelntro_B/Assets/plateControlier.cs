using JetBrains.Annotations;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Vector2 movelnput;
    public float moveSpeed = 7f;
    public float JumpForce = 7f;
    private Rigidbody2D rb;
    private Animator myAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("move", false);

    }
    public void OnMove(InputValue value)
    {
        movelnput = value.Get<Vector2>();
    }
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
    }
    // Update is called once per frame

    void Update()
    {
        Debug.Log("1234");
        if (movelnput.x > 0)
        {

            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movelnput.x < 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.Translate(Vector3.right * moveSpeed * movelnput.x * Time.deltaTime);

        if (movelnput.magnitude > 0)
        {

            myAnimator.SetBool("move", true);
        }
        else
        {
            {
                myAnimator.SetBool("move", true);
            }
            transform.Translate(Vector3.right * moveSpeed * movelnput.x * Time.deltaTime);

        }

    }
}