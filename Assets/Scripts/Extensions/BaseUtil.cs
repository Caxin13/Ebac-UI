using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
//using UnityEditor;

public static class BaseUtil
{

    [UnityEditor.MenuItem("Ebac/Teste")]
    public static void Teste()
    {
        Debug.Log("Teste");
    }

    [UnityEditor.MenuItem("Ebac/Teste2 %g")]
    public static void Teste2()
    {
        Debug.Log("Teste2");
    }

//colocando o #if e #endif estava desativando a função inteira em todo momento e não nos desejados


    public static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }

    public static void Scale(this GameObject t, float size = 1.2f)
    {
        t.transform.localScale = Vector3.one * size;
    }

    public static void ScaleVector(this Vector3 t, float size = 1.2f)
    {
       // t.localScale = Vector3.one * size;
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T GetRandom<T>(this T[] array)
    {
        if (array.Length == 0)
            return default(T);

        return array[Random.Range(0, array.Length)];

    }

    /*
    public static T GetRandom<t>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
    */

    public static T GetRandomButNotSame<T>(this List<T> list, T unique)
    {
        if (list.Count == 1)
            return unique;

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }

   
}
