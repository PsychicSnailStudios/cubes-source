using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helpful random methods
/// </summary>
public static class Extensions
{
    #region Enumerations

    public static bool EnumToBool<T>(this T input, T comparer) where T : struct, IConvertible
	{
		if (typeof(T).IsEnum)
		{
			if (input.Equals(comparer))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	}

    #endregion

    #region Vectors

    public static Vector2 ToVector2(this Vector3 input)
    {
        return new Vector2(input.x, input.y);
    }
    public static Vector2 ToVector2(this Vector4 input)
    {
        return new Vector4(input.x, input.y);
    }

    public static Vector3 IntToVector3(this int input)
	{
        return new Vector3(input, input, input);
	}

    public static Vector3 FloatToVector3(this float input)
    {
        return new Vector3(input, input, input);
    }

    public static Vector3 TrimZ(this Vector3 input)
    {
        return new Vector3(input.x, input.y, 0);
    }

    /// <summary>
    /// <para>
    /// Divides the individual components of v0 by those of v1.
    /// </para><para>
    /// e.g. v0.ComponentDivide(v1) returns [ v0.x/v1.x, v0.y/v1.y, v0.z/v1.z ]
    /// </para><para>
    /// If any of the components of v1 are 0, then that component of v0 will
    /// remain unchanged to avoid divide by zero errors.
    /// </para>
    /// </summary>
    /// <returns>The Vector3 result of the ComponentDivide.</returns>
    /// <param name="v0">The numerator Vector3</param>
    /// <param name="v1">The denominator Vector3</param>
    static public Vector3 ComponentDivide(this Vector3 v0, Vector3 v1)
    {
        Vector3 vRes = v0;

        // Avoid divide by zero errors
        if (v1.x != 0)
        {
            vRes.x = v0.x / v1.x;
        }
        if (v1.y != 0)
        {
            vRes.y = v0.y / v1.y;
        }
        if (v1.z != 0)
        {
            vRes.z = v0.z / v1.z;
        }

        return vRes;
    }

    #endregion

    #region Lists

    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    /// <summary>
    /// Gets a random object from the list
    /// </summary>
    public static T GetRandom<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
    /// <summary>
    /// Gets a random object from the array
    /// </summary>
    public static T GetRandom<T>(this T[] list)
    {
        return list[UnityEngine.Random.Range(0, list.Length)];
    }

    #endregion

    #region Colors

    public static string ColorToHex(this Color32 color)
    {
        return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
    }

    public static Color32 HexToColor(this string hex)
    {
        hex = hex.Replace("0x", "");
        hex = hex.Replace("#", "");

        byte a = 255;
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }

        return new Color32(r, g, b, a);
    }

    #endregion

    #region Images

    public static string SpriteToString(this Sprite value)
    {
        if (value != null)
        {
            return value.texture.name;
        }
        else
        {
            return "null";
        }
    }

    #endregion

    #region Generics

    public static T GetIfNotNull<T>(this T value)
    {
        if (value != null)
        {
            return value;
        }
        else
        {
            return default(T);
        }
    }

    #endregion

    #region JSON

    /// <summary>
    /// Turns this object's JSON data into an object and returns it
    /// </summary>
    /// <returns>a c# object</returns>
    public static T Unpack<T>(this string data)
    {
        return JsonUtility.FromJson<T>(data);
    }

    /// <summary>
    /// Turns a object into a string of JSON and stores it in this objects data var
    /// </summary>
    /// <param name="modelData">the object to turn into JSON</param>
    public static string Pack<T>(this T modelData)
    {
        return JsonUtility.ToJson(modelData);
    }

    #endregion
}
