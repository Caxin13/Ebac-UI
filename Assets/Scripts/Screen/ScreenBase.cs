using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }
}


public class ScreenBase : MonoBehaviour
{
    public TouchScreenKeyboardType screenType;

    public List<Transform> listOfObjects;

    public bool StartHidden = false;

    [Header ("Animation")]
    public float delayBetweenObjects = .05f;
    public float animationDuration = .3f;

    public void Start()
    {
        if(StartHidden)
        {
            HideObjects();
        }
    }

    [Button]
    protected virtual private void Show()
    {
        ShowObjects();
        Debug.Log("show");
    }

    [Button]
    protected virtual void Hide()
    {
        Debug.Log("Show");
        HideObjects();
    }

    private void HideObjects()
    {
        listOfObjects.ForEach(i => i.gameObject.SetActive(false));
    }

    private void ShowObjects()
    {
        for (int i = 0; i < listOfObjects.Count; i++)
        {
            var obj = listOfObjects[i];

            obj.gameObject.SetActive(true);
            obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
        }
    }

    private void ForceShowObjects()
    {
        listOfObjects.ForEach(i => i.gameObject.SetActive(true));
    }


}
