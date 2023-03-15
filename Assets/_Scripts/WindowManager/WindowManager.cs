using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public float sensitivity;
    public static event Action<Window> OnSelectedWindowChanged;
    
    [SerializeField] private List<Window> windowedApps;
    
    private Window selectedWindow;
    private ServiceWrapper serviceManager;
    
    private void Start()
    {
        windowedApps = GetComponentsInChildren<Window>().ToList();
        serviceManager = FindObjectOfType<ServiceWrapper>();
        selectedWindow = windowedApps[0];
        OnSelectedWindowChanged?.Invoke(selectedWindow);
    }

    private void OpenApp(GameObject window)
    {
        
    }

    private void CloseApp(GameObject window)
    {
        
    }

    private void SelectApp(Window window)
    {
        OnSelectedWindowChanged?.Invoke(window);
    }

    private void MoveApp(GameObject window)
    {
        
    }

    private void PlaceWindow(GameObject window)
    {
        
    }
    
}
