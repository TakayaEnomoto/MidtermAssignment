using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareButton : MonoBehaviour
{
    SpriteRenderer sr;
    public bool active;
    private int NumOfPlayers;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(NumOfPlayers != 0)
        {
            sr.color = Color.green;
            active = true;
        }
        else if(NumOfPlayers == 0)
        {
            sr.color = new Color(1, 0.1462264f, 0.1462264f);
            active = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            NumOfPlayers += 1;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            NumOfPlayers -= 1;
        }

    }
}
