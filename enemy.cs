using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10;
    public float viewDistance = 10;
    public float rangeOfPatrol = 10;
    public Transform point;
    public Transform player;
    public bool moveingRight = false;

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= viewDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.localScale = new Vector3((transform.position.x - player.position.x) > 0 ? 1 : -1,
                transform.localScale.y, transform.localScale.z);
        }
        else {
            if (transform.position.x >= (point.position.x + rangeOfPatrol))
                moveingRight = false;
            else if (transform.position.x <= point.position.x - rangeOfPatrol)
                moveingRight = true;
            transform.position = moveingRight ? new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y) :
                new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector3(moveingRight ? -1 : 1,
                transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
