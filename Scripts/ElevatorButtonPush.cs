using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorButtonPush : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.05f;
    [SerializeField] private float aminationSpeed = 0.5f;
    [SerializeField] private int floor = 0;

    public Transform leftOutHallDoor;
    public Transform rightOutHallDoor;
    public Transform leftInHallDoor;
    public Transform rightInHallDoor;

    private Vector3 leftOutHallDoorStart;
    private Vector3 rightOutHallDoorStart;
    private Vector3 leftInHallDoorStart;
    private Vector3 rightInHallDoorStart;

    public Transform leftOutElevatorLDoor;
    public Transform rightOutElevatorLDoor;
    public Transform leftInElevatorLDoor;
    public Transform rightInElevatorLDoor;

    private Vector3 leftOutElevatorDoorStart;
    private Vector3 rightOutElevatorDoorStart;
    private Vector3 leftInElevatorDoorStart;
    private Vector3 rightInElevatorDoorStart;

    public Transform Elevator;
    public GameObject ElevartorStations;
    [SerializeField] private Transform Player = null;

    private bool openAnimation;
    private bool openRunnig;
    private bool openedDoor;
    private bool elevatorMoveAnimation;
    private bool elevatorDoorAnimation;
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    private CharacterController characterController;
    private Vector3 movF, movB;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        openAnimation = false;
        openRunnig = false;
        openedDoor = false;
        elevatorMoveAnimation = false;

        movF = new Vector3(0.1f, 0, 0);
        movB = new Vector3(-0.1f, 0, 0);

        characterController = Player.GetComponent<CharacterController>();

        floor -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && !GlobalElevatorWPlayerMoveing.isMoveing && !openRunnig && GetValue() + threshold >= 0.3)
        {
            Pressed();
        }
        if (_isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }

        if (elevatorMoveAnimation)
        {
            if (Vector3.Distance(Elevator.position, ElevartorStations.transform.GetChild(floor).transform.position) >= 0.001)
            {
                if (Player)
                {
                    GlobalElevatorWPlayerMoveing.isMoveing = true;
                    Player.position = new Vector3(Player.position.x, Elevator.transform.GetChild(0).transform.position.y, Player.position.z);

                    characterController.Move(movF - new Vector3(0, 9.81f, 0) * Time.deltaTime);
                    characterController.Move(movB - new Vector3(0, 9.81f, 0) * Time.deltaTime);
                }
                Elevator.position = Vector3.MoveTowards(Elevator.position, ElevartorStations.transform.GetChild(floor).transform.position, aminationSpeed * 4 * Time.deltaTime);
                
            }
            else
            {
                leftOutHallDoorStart += leftOutHallDoor.position;
                rightOutHallDoorStart += rightOutHallDoor.position;
                leftInHallDoorStart += leftInHallDoor.position;
                rightInHallDoorStart += rightInHallDoor.position;


                leftOutElevatorDoorStart += leftOutElevatorLDoor.position;
                rightOutElevatorDoorStart += rightOutElevatorLDoor.position;
                leftInElevatorDoorStart += leftInElevatorLDoor.position;
                rightInElevatorDoorStart += rightInElevatorLDoor.position;
                openAnimation = true;
                elevatorMoveAnimation = false;
                GlobalElevatorWPlayerMoveing.isMoveing = false;
            }
        }

        if (openAnimation)
        {
            if (Vector3.Distance(leftOutHallDoorStart, leftOutHallDoor.position) < 0.2)
            {
                leftOutHallDoor.position += Vector3.right * Time.deltaTime * aminationSpeed;
                rightOutHallDoor.position += Vector3.left * Time.deltaTime * aminationSpeed;
            }
            else
            {
                elevatorDoorAnimation = true;
            }
            if (Vector3.Distance(leftInHallDoorStart, leftInHallDoor.position) < 0.5)
            {
                leftInHallDoor.position += Vector3.right * Time.deltaTime * aminationSpeed;
                rightInHallDoor.position += Vector3.left * Time.deltaTime * aminationSpeed;
            }

            if (elevatorDoorAnimation)
            {
                if (Vector3.Distance(leftOutElevatorDoorStart, leftOutElevatorLDoor.position) < 0.2)
                {
                    leftOutElevatorLDoor.position += Vector3.right * Time.deltaTime * aminationSpeed;
                    rightOutElevatorLDoor.position += Vector3.left * Time.deltaTime * aminationSpeed;
                }

                if (Vector3.Distance(leftInElevatorDoorStart, leftInElevatorLDoor.position) < 0.5)
                {
                    leftInElevatorLDoor.position += Vector3.right * Time.deltaTime * aminationSpeed;
                    rightInElevatorLDoor.position += Vector3.left * Time.deltaTime * aminationSpeed;
                }
                else
                {
                    StartCoroutine(ExampleCoroutine());
                }
            }
        }
        else if (!openAnimation && openedDoor)
        {
            if (Vector3.Distance(leftOutHallDoorStart, leftOutHallDoor.position) >= 0.0001)
            {
                leftOutHallDoor.position = Vector3.Lerp(leftOutHallDoor.position, leftOutHallDoorStart, aminationSpeed/4);
                rightOutHallDoor.position = Vector3.Lerp(rightOutHallDoor.position, rightOutHallDoorStart, aminationSpeed / 4);
            }
            else
            {
                elevatorDoorAnimation = true;
            }
            if (Vector3.Distance(leftInHallDoorStart, leftInHallDoor.position) >= 0)
            {
                leftInHallDoor.position = Vector3.Lerp(leftInHallDoor.position, leftInHallDoorStart, aminationSpeed / 4);
                rightInHallDoor.position = Vector3.Lerp(rightInHallDoor.position, rightInHallDoorStart, aminationSpeed / 4);
            }

            if (elevatorDoorAnimation)
            {
                if (Vector3.Distance(leftOutElevatorDoorStart, leftOutElevatorLDoor.position) >= 0)
                {
                    leftOutElevatorLDoor.position = Vector3.Lerp(leftOutElevatorLDoor.position, leftOutElevatorDoorStart, aminationSpeed / 4);
                    rightOutElevatorLDoor.position = Vector3.Lerp(rightOutElevatorLDoor.position, rightOutElevatorDoorStart, aminationSpeed / 4);
                }

                if (Vector3.Distance(leftInElevatorDoorStart, leftInElevatorLDoor.position) >= 0.0001)
                {
                    leftInElevatorLDoor.position = Vector3.Lerp(leftInElevatorLDoor.position, leftInElevatorDoorStart, aminationSpeed / 4);
                    rightInElevatorLDoor.position = Vector3.Lerp(rightInElevatorLDoor.position, rightInElevatorDoorStart, aminationSpeed / 4);
                }
                else
                {
                    leftOutHallDoorStart = new Vector3();
                    rightOutHallDoorStart = new Vector3();
                    leftInHallDoorStart = new Vector3();
                    rightInHallDoorStart = new Vector3();

                    leftOutElevatorDoorStart = new Vector3();
                    rightOutElevatorDoorStart = new Vector3();
                    leftInElevatorDoorStart = new Vector3();
                    rightInElevatorDoorStart = new Vector3();

                    openedDoor = false;
                    elevatorDoorAnimation = false;
                    openAnimation = false;
                    openRunnig = false;
                }
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        openedDoor = true;

        yield return new WaitForSeconds(2);

        openAnimation = false;
        elevatorDoorAnimation = false;
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        elevatorMoveAnimation = true;
        openRunnig = true;
        Debug.Log("pressed");

    }

    private void Released()
    {
        _isPressed = false;
        Debug.Log("released");

    }

}

public static class GlobalElevatorWPlayerMoveing
{
    public static bool isMoveing = false;
}
