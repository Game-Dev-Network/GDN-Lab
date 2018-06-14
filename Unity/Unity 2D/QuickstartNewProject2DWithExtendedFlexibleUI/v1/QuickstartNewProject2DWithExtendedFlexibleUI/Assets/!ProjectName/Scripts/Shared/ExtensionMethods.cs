using System;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods {

    /// <summary> Inclusive </summary>
    public static bool IsWithinRange<T>(this T value, T minimum, T maximum) where T : IComparable<T> {
        if (value.CompareTo(minimum) < 0) return false;
        if (value.CompareTo(maximum) > 0) return false;
        return true;
    }

    public static Vector3 Add(this Vector3 value, Vector3 addend) => value += addend;

    public static Vector3 Add(this Vector3 value, float addend) => new Vector3(value.x + addend, value.y + addend, value.z + addend);

    public static Vector2 Add(this Vector2 value, Vector2 addend) => value += addend;

    public static Vector2 Add(this Vector2 value, float addend) => new Vector2(value.x + addend, value.y + addend);

    public static bool IsEqual(this Resolution value, Resolution comparand) => value.width == comparand.width && value.height == comparand.height;

    /// <summary>Removes and returns item from the list</summary>
    public static T RemoveAndGet<T>(this IList<T> list, int index) {
        lock (list) {
            T value = list[index];
            list.RemoveAt(index);
            return value;
        }
    }

    // https://forum.unity.com/threads/limiting-rotation-with-mathf-clamp.171294/#post-2244265
    public static float ClampAngle(this float angle, float min, float max) {
        if (min < 0 && max > 0 && (angle > max || angle < min)) {
            angle -= 360;
            if (angle > max || angle < min) {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) return min;
                else return max;
            }
        }
        else if (min > 0 && (angle > max || angle < min)) {
            angle += 360;
            if (angle > max || angle < min) {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max))) return min;
                else return max;
            }
        }

        if (angle < min) return min;
        else if (angle > max) return max;
        else return angle;
    }
}