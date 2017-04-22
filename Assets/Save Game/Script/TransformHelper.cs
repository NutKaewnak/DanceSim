using UnityEngine;
using System.Collections;

// just some simple helper methods for dealing with the Transform object. 
public static class TransformHelper
{
    public static Transform FindChildRecursive(this Transform t, string name)
    {
        if (t.name == name)
            return t;
        foreach (Transform child in t)
        {
            Transform ct = FindChildRecursive(child, name);
            if (ct != null)
                return ct;
        }
        return null;
    }

    public static bool Contains(this Transform parent, Transform target)
    {
        if (parent.childCount > 0)
        {
            foreach (Transform child in parent)
            {
                if (child == target)
                    return true;
            }
        }
        return false;
    }

    public static int IndexOfChild(this Transform t, Transform target)
    {
        if (t != null && target != null)
        {
            if (t.childCount > 0)
            {
                for (int i = 0; i < t.childCount; i++)
                {
                    if (t.GetChild(i) == target)
                        return i;
                }
            }
        }
        return -1;
    }

    public static Transform FindNearestChild(this Transform t, Vector3 pos)
    {
        Transform nearest = null;
        if (t != null && t.childCount > 0)
        {
            float curDist = 0;
            float dist = 100000;

            Transform tmp = null;
            for (int i = 0; i < t.childCount; i++)
            {
                tmp = t.GetChild(i);
                curDist = Vector3.Distance(tmp.position, pos);
                if (curDist < dist)
                {
                    dist = curDist;
                    nearest = tmp;
                }
            }
        }
        return nearest;
    }

    public static T GetComponentInAnyParent<T>(this Transform t) where T : Component
    {
        if(t.parent == null)
            return null; 

        Transform cur = t.parent; 
        while(cur != null)
        {
            T val = cur.GetComponent(typeof(T)) as T;
            if(val != null)
                return val; 
            cur = cur.parent; 
        }
        return null; 
    }

    public static T GetComponentInObjectHierarchy<T>(this Transform t) where T : Component
    {
        // check self
        T result = t.GetComponent(typeof(T)) as T; 
        if(result != null)
            return result;

        // check children
        result = t.GetComponentInChildren<T>(); 
        if(result != null)
            return result; 

        // check parents
        return t.GetComponentInAnyParent<T>();        
    }

    public static void SetActiveAllChildren(this Transform parent, bool active)
    {
        foreach(Transform child in parent)
        {
            child.gameObject.SetActive(active);
        }
    }

    public static void DestroyAllChildren(this Transform parent)
    {
        int childCount = parent.childCount; 
        for(int i = parent.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(parent.GetChild(i).gameObject);
        }
    }

    public static Transform GetChildWithMatchingComponent<T>(this Transform parent, T searchItem) where T : Component
    {
        if(parent.childCount == 0)
            return null; 
        
        foreach(Transform t in parent)
        {
            T item = t.GetComponent<T>(); 
            if(item != null && item == searchItem)
                return t; 
        }        
        return null; 
    }

    public static void SetParentAndResetLocalValues(this Transform target, Transform parent)
    {
        if(parent == null)
            return; 

        target.SetParent(parent); 
        target.localPosition = Vector3.zero; 
        target.localRotation = Quaternion.identity; 
        target.localScale = Vector3.one; 
    }
}