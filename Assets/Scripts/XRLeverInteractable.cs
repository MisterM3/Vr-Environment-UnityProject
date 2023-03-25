using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;



public class XRLeverInteractable : XRGrabInteractable
{

    [Header("Custom Settings")]

    [SerializeField] HingeJoint joint;

    //Range between min/max and actual float to make the swtich turn on or off.
    [SerializeField] float range = 1.0f;


    //False of true on
     bool previousState = false;

    private enum LeverInteractionType { OnOff, FloatAmount }

    [SerializeField] private LeverInteractionType interactionType;


    public UnityEvent SwitchOn;
    public UnityEvent SwitchOff;

    //Return between 0 (left) and 1(right)
    public UnityEvent<float> floatEvent;

    float angle;

    float maxAngle;
    float minAngle;

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        angle = joint.angle;

        maxAngle = joint.limits.max;
        minAngle = joint.limits.min;

        switch (interactionType)
        {
            case LeverInteractionType.OnOff:
                ProcessOnOff();
                break;
            case LeverInteractionType.FloatAmount:
                ProcessFloatAmount();
                break;
        }


    }


    public void ProcessOnOff()
    {

        if (maxAngle - angle < range && previousState == false)
        {
            previousState = true;
            SwitchOn?.Invoke();

        }

        if (angle - minAngle < range && previousState == true)
        {
            previousState = false;
            SwitchOff?.Invoke();
        }
    }

    public void ProcessFloatAmount()
    {

        angle += (Mathf.Abs(minAngle));
        maxAngle += (Mathf.Abs(minAngle));

        float amount = (angle / maxAngle);

        floatEvent?.Invoke(amount);

    }


    public bool InOnPosition()
    {
        float angle = joint.angle;

        float maxAngle = joint.limits.max;
        return maxAngle - angle < range;
    }
    public bool InOffPosition()
    {
        float angle = joint.angle;

        float minAngle = joint.limits.min;
        return minAngle - angle < range;
    }
}
