using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingResetState : CameraMoveBase
{
    private Vector3 start;
    private Vector3 end;
    private float t;
    public override void EnterState(PlayerControll pc)
    {
        start = Camera.main.transform.position;
        end = new Vector3(0, 0, Camera.main.transform.position.z);
        t = 0;
    }

    public override void LeaveState(PlayerControll pc)
    {
        pc.transform.position = new Vector3(end.x, end.y, 0);
        pc.resetNum += 1;
        pc.countDown = 60;
    }

    public override void Update(PlayerControll pc)
    {
        Camera.main.transform.position = Vector3.Lerp(start, end, t);
        t += Time.deltaTime * 2f;
        if (t > 1)
        {
            pc.pastTransform_Temp = new List<Vector3>();
            t = 1;
            pc.ChangeState(pc.StateIdle);
        }
    }
    public override void LastUpdate(PlayerControll pc)
    {

    }
}
