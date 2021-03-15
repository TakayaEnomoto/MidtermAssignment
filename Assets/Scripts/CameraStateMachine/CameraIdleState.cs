using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIdleState : CameraMoveBase
{
    public override void EnterState(PlayerControll pc)
    {
        pc.pastTransform_Temp = new List<Transform>();
    }

    public override void LeaveState(PlayerControll pc)
    {

    }

    public override void Update(PlayerControll pc)
    {
        pc.countDown -= Time.deltaTime * 2;
        if (Input.GetKey(KeyCode.W))
            pc.transform.position += Vector3.up * Time.deltaTime * pc.speed;
        if (Input.GetKey(KeyCode.S))
            pc.transform.position += Vector3.down * Time.deltaTime * pc.speed;
        if (Input.GetKey(KeyCode.A))
            pc.transform.position += Vector3.left * Time.deltaTime * pc.speed;
        if (Input.GetKey(KeyCode.D))
            pc.transform.position += Vector3.right * Time.deltaTime * pc.speed;
        if (pc.transform.position.x <= Camera.main.transform.position.x - 8.9f)
            pc.transform.position = new Vector3(Camera.main.transform.position.x - 8.9f, pc.transform.position.y, pc.transform.position.z);
        if (pc.transform.position.x >= Camera.main.transform.position.x + 8.9f)
            pc.transform.position = new Vector3(Camera.main.transform.position.x + 8.9f, pc.transform.position.y, pc.transform.position.z);
        if (pc.transform.position.y <= Camera.main.transform.position.y - 5)
            pc.transform.position = new Vector3(pc.transform.position.x, Camera.main.transform.position.y - 5, pc.transform.position.z);
        if (pc.transform.position.y >= Camera.main.transform.position.y + 5)
            pc.transform.position = new Vector3(pc.transform.position.x, Camera.main.transform.position.y + 5, pc.transform.position.z);



        pc.pastTransform_Temp.Add(pc.transform);

        if (pc.countDown <= 0)
        {
            if (pc.resetNum % 2 == 0)
            {
                pc.pastTransform_1.Clear();
                pc.pastTransform_1 = pc.pastTransform_Temp;
            }
            else if (pc.resetNum % 2 != 0)
            {
                pc.pastTransform_2.Clear();
                pc.pastTransform_2 = pc.pastTransform_Temp;
            }
            pc.ChangeState(pc.StateReset);
        }
    }
}
