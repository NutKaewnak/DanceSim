using UnityEngine;
using System.Collections;

// just some simple helper methods for dealing with the Transform object. 
public class Vector3Helper
{
    public static Vector3 CreateRandomPointInRange(Vector3 center, Vector3 range)
    {
        Vector3 result = center;
        if (range.x > 0)
            result.x += UnityEngine.Random.Range(0, range.x);
        if (range.y > 0)
            result.y += UnityEngine.Random.Range(0, range.y);
        if (range.z > 0)
            result.z += UnityEngine.Random.Range(0, range.z);

        return result;
    }

    /// <summary>
    /// Returns the angle between 2 vectors about the given axis. 
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="axis"></param>
    /// <returns>degree between -180 and 180</returns>
    public static float GetAngleInDegrees(Vector3 v1, Vector3 v2, Vector3 axis)
    {
        return Mathf.Atan2(Vector3.Dot(axis, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

    /// <summary>
    /// Returns the angle between 2 vectors about the given axis.
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="axis"></param>
    /// <returns>value in radians between -Pi and Pi</returns>
    public static float GetAngleInRadians(Vector3 v1, Vector3 v2, Vector3 axis)
    {
        return Mathf.Atan2(Vector3.Dot(axis, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2));
    }

    //returns -1 when to the left, 1 to the right, and 0 for forward/backward
    public static float CheckRelativePosition(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0.0f)        
            return 1.0f;        
        else if (dir < 0.0f)        
            return -1.0f;        
        else        
            return 0.0f;        
    }

    public static float GetRelativeAngle(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        return Vector3.Dot(perp, up);
    }

    public static CardinalDirection GetRelativeHorizontalDirection(Vector3 forward, Vector3 target, Vector3 up)
    {
        Vector3 perpendicular = Vector3.Cross(forward, target);
        float direction = Vector3.Dot(perpendicular, up);

        if (direction > 0) return CardinalDirection.Right;
        else if (direction < 0) return CardinalDirection.Left;
        else return CardinalDirection.Undefined;
    }

    /// <summary>
    /// Returns the point after rotating about the pivot point by a provided angle 
    /// </summary>
    /// <param name="point"></param>
    /// <param name="pivot"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }

    public static Vector3 Random(bool lockY = false)
    {
        return new Vector3(
            UnityEngine.Random.Range(-1f, 1f),
            lockY ? 0 : UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f)); 
    }    
}
