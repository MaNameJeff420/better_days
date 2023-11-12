using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField] private int player_number;
    private bool movement_enabled = false;

    private bool move_right_pressed;
    private bool move_left_pressed;
    private bool jump_pressed;

    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float jump_height;
    [SerializeField] private Transform ground_check;
    [SerializeField] private float ground_check_radius;
    [SerializeField] private LayerMask ground_mask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(enable_movement());
    }

    void Update()
    {
        gather_input();
        if(movement_enabled){ playermovement();}
    }

    void gather_input()
    {
        if(player_number == 1)
        {
            move_left_pressed = Input.GetKey(KeyCode.A);
            move_right_pressed = Input.GetKey(KeyCode.D);
            jump_pressed = Input.GetKeyDown(KeyCode.W);
        }else
        {
            move_left_pressed = Input.GetKey(KeyCode.LeftArrow);
            move_right_pressed = Input.GetKey(KeyCode.RightArrow);
            jump_pressed = Input.GetKeyDown(KeyCode.UpArrow);
        }
    }

    void playermovement()
    {
        //horizontal movement
        if (move_left_pressed)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }else if (move_right_pressed)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //vertical movement
        if (jump_pressed && is_grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_height);
        }
    }

    //grounded check
    bool is_grounded()
    {
        return Physics2D.OverlapCircle(ground_check.position, ground_check_radius, ground_mask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ground_check.position, ground_check_radius);
    }

    private IEnumerator enable_movement()
    {
        yield return new WaitForSeconds(1.5f);
        movement_enabled = true;
    }
}
