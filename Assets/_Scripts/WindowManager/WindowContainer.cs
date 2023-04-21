using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowContainer : MonoBehaviour
{
    public Vector2Int containerIndex;
    public bool isOccupied;


    private void Start()
    {
        UpdateOccupancy();
    }

    public void UpdateOccupancy()
    {
        foreach (Transform child in transform)
        {
            isOccupied = child.TryGetComponent(out Window window);
        }
    }
}
