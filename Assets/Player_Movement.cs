using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int player_Speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Player_Movement = new Vector3((Input.GetAxis("Horizontal_Sharp")), (Input.GetAxis("Vertical_Sharp")), 0);
        rb.velocity = Player_Movement * player_Speed;
    }
}
