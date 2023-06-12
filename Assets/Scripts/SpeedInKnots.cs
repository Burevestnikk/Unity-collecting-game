using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class SpeedInKnots : MonoBehaviour
{
    public float speed;
    private float knots; 
    public TextMeshProUGUI speedText;

    void Update () {
        speed = GetComponent<Rigidbody>().velocity.magnitude;

        knots = speed * 1.94384f;
        speedText.text = Math.Round(knots).ToString() + " N/H";
    }
}
