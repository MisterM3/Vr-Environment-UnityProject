using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurningChangeUI : MonoBehaviour
{
    TMP_Dropdown m_Dropdown;

    // Start is called before the first frame update
    void Start()
    {
        m_Dropdown = GetComponent<TMP_Dropdown>();

        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
    }


    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(TMP_Dropdown change)
    {
        if (change.value == 0)
        {
            MovementSelection.Instance.SnapTurn();
        }
        else if (change.value == 1)
        {
            MovementSelection.Instance.ContinousTurn();
        }
    }
}
