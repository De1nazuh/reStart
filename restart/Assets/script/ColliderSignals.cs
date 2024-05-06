using DG.Tweening;
using System;
using UnityEngine;

public class ColliderSignals : MonoBehaviour
{
    public Action onExit;
    public Action onEnter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<charaster>() != null)
        {
            onEnter?.Invoke();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<charaster>() != null)
        {
            onExit?.Invoke();
        }

    }


}