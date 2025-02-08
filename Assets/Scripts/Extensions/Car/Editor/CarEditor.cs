using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEditor;

[CustomEditor(typeof(Car))]

public class CarEditor : Editor
{
    [UnityEditor.MenuItem("Ebac/Test")]
    public static void Test()
    {
        Debug.Log("Test");
    }


    public override void OnInspectorGUI()
    {
        //  base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);

        myTarget.speed = EditorGUILayout.IntField("Minha Velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Marcha", myTarget.gear);

        EditorGUILayout.LabelField("Velocidade total", myTarget.TotalSpeed.ToString());

        EditorGUILayout.HelpBox("Calcule a velocidade do carro", MessageType.Info);

        if (myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Velocidade acima do permitido", MessageType.Error);
        }

        GUI.color = Color.blue;

        if (GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }


    }
}
