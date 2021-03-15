using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareDoor : MonoBehaviour
{

    [SerializeField]
    private GameObject button;
    private float t;
    void Start()
    {
        button = GameObject.Find("Button(Square)");
    }

    
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Lerp(1, 0, t), transform.localScale.y);
        OpenDoor();
        if (t > 1)
            t = 1;
        if (t < 0)
            t = 0;
    }

    void OpenDoor()
    {
        if (button.GetComponent<SquareButton>().active)
        {
            t += Time.deltaTime * 1.5f;
        }
        else if (button.GetComponent<SquareButton>().active == false)
        {
            t -= Time.deltaTime * 1.5f;
        }
    }
}
