using DG.Tweening;
using System;
using UnityEngine;

public class СScreaptLose : MonoBehaviour
{
    public Action onExit;
    public Action onEnter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            onEnter?.Invoke();
        }

    }
}