using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public float sensitivity;
    public Vector2Int numberOfWindows;
    public static event Action<Window> OnSelectedWindowChanged;
    public WindowContainer[,] WindowContainer2DArray => windowContainer2DArray;
    [SerializeField] private List<Window> windowedApps;
    [SerializeField] private WindowContainer[,] windowContainer2DArray;

    private Window selectedWindow;
    private WindowPlacement windowPlacement;
    private ServiceWrapper serviceManager;
    
    private void Start()
    {
        windowedApps = GetComponentsInChildren<Window>().ToList();
        serviceManager = FindObjectOfType<ServiceWrapper>();
        windowPlacement = GetComponentInChildren<WindowPlacement>();
        selectedWindow = windowedApps[0];
        OnSelectedWindowChanged?.Invoke(selectedWindow);
        
        WindowContainer[] windowContainerArray = windowPlacement.transform.GetComponentsInChildren<WindowContainer>();
        SetWindowContainerPositions(windowContainerArray);
    }

    private void SetWindowContainerPositions(WindowContainer[] windowContainerArray)
    {
        windowContainer2DArray = new WindowContainer[numberOfWindows.x, numberOfWindows.y];
        int iterations = 0;
        for (int i = 0; i < numberOfWindows.x; i++)
        {
            for (int j = 0; j < numberOfWindows.y; j++)
            {
                windowContainer2DArray[i,j] = windowContainerArray[iterations];
                windowContainer2DArray[i, j].containerIndex = new Vector2Int(i, j);
                iterations++;
            }
        }
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
