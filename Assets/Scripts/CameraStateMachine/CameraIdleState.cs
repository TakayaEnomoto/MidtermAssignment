using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIdleState : CameraMoveBase
{
    public override void EnterState(PlayerControll pc)
    {
        if (pc.pastTransform_1.Count > 0)
        {
            pc.pastPlayer_1.SetActive(true);
        }
        pc.pastTransform_array = new Transform[1000];
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


        if (pc.resetNum % 2 == 0)
        {
            pc.pastTransform_1.Add(pc.transform);
            pc.pastTransform_array.SetValue(pc.transform, Mathf.RoundToInt((60 - pc.countDown) * (1000/ 60)));
        }
        else if (pc.resetNum % 2 != 0)
        {
            pc.pastTransform_2.Add(pc.transform);
        }

        if(pc.pastTransform_1.Count > 0 && pc.resetNum > 0)
        {
            int position = Mathf.RoundToInt((60 - pc.countDown) * (pc.pastTransform_1.Count / 60));
            if (position > pc.pastTransform_1.Count)
                position = pc.pastTransform_1.Count - 1;
            pc.pastPlayer_1.transform.position = pc.pastTransform_1[position].position;
        }

        if (pc.countDown <= 0)
        {
            if (pc.resetNum % 2 != 0 && pc.resetNum >= 1)
            {
                pc.pastTransform_1.Clear();
            }
            else if (pc.resetNum % 2 == 0 && pc.resetNum > 1)
            {
                pc.pastTransform_2.Clear();
            }
            pc.ChangeState(pc.StateReset);
        }
    }
}
