using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed = 1f;
    bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void LateUpdate()
    {
        if (this.gameObject.tag == "monster")
        {
            Move();
        }
        else if (this.gameObject.tag == "potbug")
        {
            Invoke("Move", 1f);
        }
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "endpoint")
        {
            if (isRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
        }
    }
}
