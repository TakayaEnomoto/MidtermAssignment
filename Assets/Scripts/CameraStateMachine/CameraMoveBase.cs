using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraMoveBase
{
    public abstract void EnterState(PlayerControll pc);
    public abstract void Update(PlayerControll pc);
    public abstract void LeaveState(PlayerControll pc);
    public abstract void LastUpdate(PlayerControll pc);
}
