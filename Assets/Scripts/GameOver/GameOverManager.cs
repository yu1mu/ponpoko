using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameOverManager : MonoBehaviour
{
    public Tilemap OverText;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
        StartCoroutine(colorControl(OverText.gameObject));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator colorControl(GameObject text)
    {
        int count = 0;
        while (count < 6)
        {
            if (count % 2 == 0)
                text.SetActive(false);
            else
                text.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            count++;
        }

        yield return null;
    }
}
