using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class XRButtonInteractable : XRBaseInteractable
{
    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previousPress = false;

    private float previousHandHeight = 0.0f;
    private XRBaseInteractor hoverInteractor = null;

    public UnityEvent OnPress = null; 

    [SerializeField] float yMinPercentage = .5f;

    protected override void Awake()
    {
        base.Awake();
        hoverEntered.AddListener(StartPress);
        hoverExited.AddListener(EndPress);
    }

    // Start is called before the first frame update
    protected override void OnDestroy()
    {
        base.OnDestroy();
        hoverEntered.AddListener(StartPress);
        hoverExited.AddListener(EndPress);
    }

    // Update is called once per frame
    void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();

        Vector3 boundsInLocal = transform.InverseTransformVector(collider.bounds.size);
        yMin = transform.localPosition.y - (boundsInLocal.y * yMinPercentage);

        yMax = transform.localPosition.y;
    }

    private void StartPress(HoverEnterEventArgs arg)
    {
        hoverInteractor = (XRBaseInteractor)arg.interactorObject;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
    }

    private void EndPress(HoverExitEventArgs arg)
    {
        hoverInteractor = null;
        previousHandHeight = 0.0f;

        previousPress = false;

        SetYPosition(yMax);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (hoverInteractor)
        {
            float newHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosistion = transform.localPosition.y - handDifference;
            SetYPosition(newPosistion);
            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.InverseTransformVector(position);
        return localPosition.y;
    }

    private void SetYPosition(float yPosition)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(yPosition, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
        }
        previousPress = inPosition;
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + Mathf.Abs(yMin * 0.1f));

        return transform.localPosition.y == inRange;
    }    
}
