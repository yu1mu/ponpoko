using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIgnore : MonoBehaviour
{
    public Collider2D mapCollider;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), mapCollider, true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), mapCollider, false);
        }
    }
}
