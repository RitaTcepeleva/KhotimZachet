using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Component comp = collision.GetComponent<Component>();
        if (comp && comp.tag.Contains("Border"))
        {
            if (comp.tag == "BorderHor") direction.y *= -1;
            else direction.x *= -1;
        }
    }
}
