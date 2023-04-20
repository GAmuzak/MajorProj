
using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 GetXY(this Vector3 vector3, float z=0)
    {
        return new Vector3(vector3.x, vector3.y, z);
    }

    public static Vector3 GetYZ(this Vector3 vector3, float x=0)
    {
        return new Vector3(x, vector3.y, vector3.z);
    }

    public static Vector3 GetXZ(this Vector3 vector3, float y=0)
    {
        return new Vector3(vector3.x, y, vector3.z);
    }
    
    public static Vector3 SetX(this Vector3 vector3, float x)
    {
        vector3.x = x;
        return vector3;
    }
    
    public static Vector3 SetY(this Vector3 vector3, float y)
    {
        vector3.y = y;
        return vector3;
    }
    
    public static Vector3 SetZ(this Vector3 vector3, float z)
    {
        vector3.z = z;
        return vector3;
    }
}
