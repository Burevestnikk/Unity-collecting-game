using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FuelScript : MonoBehaviour
{
    public float fuelAmount = 100f; 
    public float fuelConsumptionRate = 5f; 
    public TextMeshProUGUI fuelText; 
    public GameObject gameOverObject;
    private float fuelTimer = 5f;
    public mainLog mainLog;
    public TextMeshProUGUI GOscoretxt;

    public void AddFuel(float amount)
    {
        fuelAmount += amount;
    }

    void Update()
    {
        fuelTimer -= Time.deltaTime;

        if (fuelTimer <= 0f)
        {
            fuelAmount -= fuelConsumptionRate;
            fuelTimer = 2f;
        }

        if (fuelAmount <= 0f)
        {
            GOscoretxt.text = "SCORE: " + mainLog.score;
            gameOverObject.SetActive(true);
        }

        fuelAmount = Mathf.Clamp(fuelAmount, 0f, 100f);

        fuelText.text = Mathf.RoundToInt(fuelAmount).ToString() + " м³";

        if (fuelAmount <= 0f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}

