using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindableDoor : BindableObject
{

    [SerializeField] private Vector3 dragAnchorOffset;
    private SkinnedMeshRenderer doorMesh;

    public enum DoorState
    {
        Busy,
        Open,
        Closed
    }

    public DoorState currentState;

    public override void Start()
    {
        base.Start();
        setDoorState(DoorState.Closed);
        lineRenderer.SetPosition(0, dragAnchor += dragAnchorOffset);


    }

    public override void toggleAction()
    {
        Debug.Log("Opening Door");
    }

    private DoorState setDoorState(DoorState state)
    {
        currentState = state;
        return currentState;
    }
}
