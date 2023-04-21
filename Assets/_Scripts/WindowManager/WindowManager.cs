using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public float sensitivity;
    public Vector2Int numberOfWindows;
    public List<Window> appList;
    public Window SelectedWindow => selectedWindow;
    public Window[,] Windows => windowedApps;
    public static event Action<Window> OnSelectedWindowChanged;
    private Window[,] windowedApps;
    public Vector2Int centralWindowIndex;

    private Window selectedWindow;
    private WindowPlacement windowPlacement;
    private ServiceWrapper serviceManager;
    private void Start()
    {
        centralWindowIndex = new Vector2Int((numberOfWindows.x - 1) / 2, (numberOfWindows.y - 1) / 2);
        Debug.Log(centralWindowIndex);
        serviceManager = FindObjectOfType<ServiceWrapper>();
        windowPlacement = GetComponentInChildren<WindowPlacement>();
        appList = windowPlacement.GetComponentsInChildren<Window>().ToList();
        windowedApps = ConvertTo2DArray<Window>(appList, numberOfWindows);
        selectedWindow = windowedApps[centralWindowIndex.x, centralWindowIndex.y];
        SelectWindow(windowedApps[centralWindowIndex.x, centralWindowIndex.y]);
    }
    
    private T[,] ConvertTo2DArray<T>(List<T> _windowObject1DArray, Vector2Int _numberOfWindows) where T : Window
    {
        T[,] convertTo2DArray = new T[numberOfWindows.x, numberOfWindows.y];
        int iterations = 0;
        for (int j = 0; j < _numberOfWindows.x; j++)
        {
            for (int i = 0; i < _numberOfWindows.y; i++)
            {
                convertTo2DArray[i,j] = _windowObject1DArray[iterations];
                convertTo2DArray[i, j].containerIndex = new Vector2Int(i, j);
                iterations++;
            }
        }

        return convertTo2DArray;
    }
    private void OpenApp(GameObject window)
    {
        
    }

    private void CloseApp(GameObject window)
    {
        
    }

    public void SelectWindow(Window window)
    {
        selectedWindow.ActivateCursor(false);
        window.ActivateCursor(true);
        selectedWindow = window;
    }

    private void MoveApp(GameObject window)
    {
        
    }

    private void PlaceWindow(GameObject window)
    {
        
    }
    
}
