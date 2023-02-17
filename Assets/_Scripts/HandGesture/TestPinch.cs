using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Input;
using TMPro;
using UnityEngine;

public class TestPinch : MonoBehaviour
{
    public Hand hand;

    public TextMeshPro pinchText;
    // Start is called before the first frame update
    void Start()
    {
        pinchText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        pinchText.text = "Pinch Strength" + hand.GetFingerPinchStrength(HandFinger.Index).ToString();
    }
}
