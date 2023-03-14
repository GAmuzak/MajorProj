using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueReader : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI tmp;
    
    void Update()
    {
        tmp.text = (slider.value*100f).ToString("0");
    }
}
