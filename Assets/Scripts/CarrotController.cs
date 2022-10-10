using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.instance.count++;
            GameManager.instance.scoreCount();
            UIManager.instance.activeScore(GameManager.instance.getCount(), gameObject.transform);
        }
    }

   
}
