using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] private HandGestureIdentifier handGestureIdentifier;
    [SerializeField] private HandInputManager handInputManager;
    [SerializeField] private TextMeshProUGUI Debug1;
    [SerializeField] private TextMeshProUGUI Debug2;

    private void Update()
    {
        Debug1.text = handGestureIdentifier.utilityGesture.ToString();
        Debug2.text = HandInputManager.passedAction.ToString();
    }
}
