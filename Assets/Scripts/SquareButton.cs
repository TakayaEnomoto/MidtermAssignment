using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareButton : MonoBehaviour
{
    SpriteRenderer sr;
    public bool active;
    // Start is called before the first frame update
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sr.color = Color.green;
            active = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sr.color = new Color(1, 0.1462264f, 0.1462264f);
            active = false;
        }

    }
}
