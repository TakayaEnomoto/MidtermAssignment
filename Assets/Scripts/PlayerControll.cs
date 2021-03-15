using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    [SerializeField]
    private float spd;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * Time.deltaTime * spd;
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.down * Time.deltaTime * spd;
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * Time.deltaTime *spd;
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * Time.deltaTime * spd;
    }
}
