using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
    public Transform potbug;

    Vector3 pos;
    Quaternion rot;

    bool isColor;

    Transform bug;
    SpriteRenderer sr;

    private void Start()
    {
        isColor = true;
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "carrot")
            {
                gameObject.SetActive(false);
                GameManager.instance.count++;
                GameManager.instance.scoreCount();
                UIManager.instance.activeScore(GameManager.instance.getCount(), gameObject.transform);
            }
            else if (this.gameObject.tag == "notCarrot")
            {
                pos = this.gameObject.transform.position;
                rot = this.gameObject.transform.rotation;
                sr.material.color = new Color(1, 1, 1, 0);
                StartCoroutine(bugControl());

            }
        }
    }

    IEnumerator bugControl()
    {
        yield return new WaitForSeconds(0.5f);
        bug = Instantiate(potbug, pos, rot);
        StartCoroutine(colorControl(bug));
    }

    IEnumerator activeControl()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    IEnumerator colorControl(Transform bug)
    {
        Renderer render = bug.GetComponent<Renderer>();
        int count = 0;
        while (count < 6)
        {
            if (count % 2 == 0)
                render.material.color = new Color(1, 1, 1, 0);
            else
                render.material.color = new Color(1, 1, 1, 1f);

            yield return new WaitForSeconds(0.1f);
            count++;
        }


        StartCoroutine(activeControl());

        yield return null;
    }
}
