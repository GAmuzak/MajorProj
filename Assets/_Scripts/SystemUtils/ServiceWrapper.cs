using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ServiceWrapper : MonoBehaviour
{
    private Slider slider;

    private static ServiceWrapper _instance;
    
    public static ServiceWrapper Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<ServiceWrapper>();
            if (_instance != null) return _instance;
            GameObject gg = new GameObject();
            gg.AddComponent<ServiceWrapper>();
            return _instance;
        }
    }
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        _instance = this;
    }

    private void PassData(HandGesture currentHandGesture, bool isLeftHand)
    {
        switch (currentHandGesture)
        {
            
        }
    }
}
