using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float player_Speed;
    Rigidbody2D rb;
    [SerializeField] GameObject movement_Target;
    SpriteRenderer spriteRenderer;
    Animator animator;
    Vector3 mouseWorldPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        movement_Target.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_Movement = Vector3.MoveTowards(gameObject.transform.position, movement_Target.transform.position, player_Speed * Time.deltaTime);
        gameObject.transform.position = player_Movement;


        if (Input.GetMouseButtonDown(1))
        {
            mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            movement_Target.transform.position = mouseWorldPos;
        }

        if (gameObject.transform.position.x > movement_Target.transform.position.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isWalking", true);
        }
        else if (gameObject.transform.position.x < movement_Target.transform.position.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
