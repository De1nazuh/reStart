using TMPro;
using UnityEngine;
using System;

public class GamePlayUI : MonoBehaviour
{
    public charaster charaster;
    public TextMeshProUGUI distanceText;

    private void SetDistanceText(float distance)
    {
        distanceText.text = Math.Round(distance, 1).ToString();

    }
    private void Update()
    {

        SetDistanceText(charaster.transform.position.z);
            

    }
}
