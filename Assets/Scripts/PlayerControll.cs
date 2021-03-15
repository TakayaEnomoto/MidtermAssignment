using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControll : MonoBehaviour
{
    public List<Transform> pastTransform_1;
    public List<Transform> pastTransform_2;
    public List<Transform> pastTransform_Temp;
    public float countDown;
    public int resetNum;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private float spd;
    public float speed
    {
        get
        {
            return spd;
        }
        set
        {
            spd = value;
        }
    }

    private GameObject button;
    private CameraMoveBase currentState;
    private CameraMovingResetState stateReset = new CameraMovingResetState();
    public CameraMovingResetState StateReset
    {
        get
        {
            return stateReset;
        }
        set
        {
            stateReset = value;
        }
    }
    private CameraMovingUpState stateUp = new CameraMovingUpState();
    public CameraMovingUpState StateUp
    {
        get
        {
            return stateUp;
        }
        set
        {
            stateUp = value;
        }
    }
    private CameraIdleState stateIdle = new CameraIdleState();
    public CameraIdleState StateIdle
    {
        get
        {
            return stateIdle;
        }
        set
        {
            stateIdle = value;
        }
    }

    public void ChangeState(CameraMoveBase newState)
    {
        if (currentState != null)
        {
            currentState.LeaveState(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.EnterState(this);
        }
    }
    void Start()
    {
        countDown = 60f;
        timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        button = GameObject.Find("Button(Square)");
        ChangeState(StateIdle);
    }

    void Update()
    {
        currentState.Update(this);
        timerText.text = Mathf.Round(countDown).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit" && button.GetComponent<SquareButton>().active)
        {
            Debug.Log("MoveCam");
            ChangeState(StateUp);
        }
    }
}
