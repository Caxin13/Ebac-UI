using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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



    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typer> listOfPhrases;

        public Image uiBackground;
        public bool StartHidden = false;

        [Header("Animation")]
        public float delayBetweenObjects = .05f;
        public float animationDuration = .3f;

        public void Start()
        {
            if (StartHidden)
            {
                HideObjects();
            }
        }

        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("show");
        }

        [Button]
        public virtual void Hide()
        {
            Debug.Log("Hide");
            HideObjects();
        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackground.enabled = false;
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);
            uiBackground.enabled = true;

        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
            uiBackground.enabled = true;

        }


    }

}
