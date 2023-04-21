using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformUtils
{
    public static Vector3 ReturnAveragePosition(Transform parent)
    {
        Vector3 averagePosition = Vector3.zero;
        int numberOfChildren = parent.childCount;
        if (numberOfChildren <= 0) return parent.position;
        for (int i = 0; i < numberOfChildren; i++)
        {
            averagePosition += parent.GetChild(i).position;
        }
        averagePosition /= numberOfChildren;
        return averagePosition;
    }
    
    public static Transform SetPositionX(this Transform transform, float x)
    {
        Vector3 position = transform.position;
        position.x = x;
        transform.position = position;
        return transform;
    }
    
    public static Transform SetPositionY(this Transform transform, float y)
    {
        Vector3 position = transform.position;
        position.y = y;
        transform.position = position;
        return transform;
    }
    
    public static Transform SetPositionZ(this Transform transform, float z)
    {
        Vector3 position = transform.position;
        position.z = z;
        transform.position = position;
        return transform;
    }
    
    public static Transform SetLocalPositionX(this Transform transform, float x)
    {
        Vector3 position = transform.localPosition;
        position.x = x;
        transform.localPosition = position;
        return transform;
    }
    
    public static Transform SetLocalPositionY(this Transform transform, float y)
    {
        Vector3 position = transform.localPosition;
        position.y = y;
        transform.localPosition = position;
        return transform;
    }
    
    public static Transform SetLocalPositionZ(this Transform transform, float z)
    {
        Vector3 position = transform.localPosition;
        position.z = z;
        transform.localPosition = position;
        return transform;
    }
}
