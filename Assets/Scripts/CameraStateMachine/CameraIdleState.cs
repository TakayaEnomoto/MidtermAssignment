using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIdleState : CameraMoveBase
{
    public override void EnterState(PlayerControll pc)
    {
    }

    public override void LeaveState(PlayerControll pc)
    {
        pc.countDown = 60;
    }

    public override void Update(PlayerControll pc)
    {
        pc.countDown -= Time.deltaTime * 2;
        if(pc.countDown <= 0)
        {
            pc.ChangeState(pc.StateReset);
        }
        if (Input.GetKey(KeyCode.W))
            pc.transform.position += Vector3.up * Time.deltaTime * pc.speed;
        if (Input.GetKey(KeyCode.S))
            pc.transform.position += Vector3.down * Time.deltaTime * pc.speed;
        if (Input.GetKey(KeyCode.A))
            pc.transform.position += Vector3.left * Time.deltaTime * pc.speed;
        if (Input.GetKey(KeyCode.D))
            pc.transform.position += Vector3.right * Time.deltaTime * pc.speed;
    }
}
