using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementSelection : MonoBehaviour
{
    public static MovementSelection Instance;

    public enum MovementType { Continuous, Teleportation }
    public enum TurningType { Continuous, Snap }

    [SerializeField] MovementType movementType;
    [SerializeField] TurningType turningType;

    ContinuousMoveProviderBase conMoving;
    TeleportationTopProvider telMoving;
    ContinuousTurnProviderBase conTurning;
    ActionBasedSnapTurnProvider snapTurning;
    // Start is called before the first frame update
    void Start()
    {

        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        if (!TryGetComponent<ContinuousMoveProviderBase>(out ContinuousMoveProviderBase conMove)) Debug.LogError("NO CONMOVE");
        if (!TryGetComponent<TeleportationTopProvider>(out TeleportationTopProvider telMove)) Debug.LogError("NO TELMOVE");
        if (!TryGetComponent<ContinuousTurnProviderBase>(out ContinuousTurnProviderBase conTurn)) Debug.LogError("NO conTurn");
        if (!TryGetComponent<ActionBasedSnapTurnProvider>(out ActionBasedSnapTurnProvider snapTurn)) Debug.LogError("NO snapTurn");

        conMoving = conMove;
        telMoving = telMove;
        conTurning = conTurn;
        snapTurning = snapTurn;

        switch (movementType)
        {
            case (MovementType.Continuous):
                conMoving.enabled = true;
                telMoving.enabled = false;
                break;
            case (MovementType.Teleportation):
                conMoving.enabled = false;
                telMoving.enabled = true;
                break;
        }

        switch (turningType)
        {
            case (TurningType.Continuous):
                conTurning.enabled = true;
                snapTurning.enabled = false;
                break;
            case (TurningType.Snap):
                conTurning.enabled = false;
                snapTurning.enabled = true;
                break;
        }
    }


    public void TeleportMovement()
    {
        conMoving.enabled = false;
        telMoving.enabled = true;
    }

    public void ContinousMove()
    {
        conMoving.enabled = true;
        telMoving.enabled = false;
    }

    public void SnapTurn()
    {
        conTurning.enabled = false;
        snapTurning.enabled = true;
    }

    public void ContinousTurn()
    {
        conTurning.enabled = true;
        snapTurning.enabled = false;
    }


}
