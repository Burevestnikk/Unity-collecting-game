using UnityEngine;

public class Refuel : MonoBehaviour
{
    public float fuelCapacity = 100f;
    public float refuelRate = 50f;
    public float refuelDistance = 50f;

    private float currentFuel;

    private void Start()
    {
        currentFuel = fuelCapacity;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(transform.position, other.transform.position) <= refuelDistance)
        {
            RefuelTank();
        }
    }

    private void RefuelTank()
    {
        if (currentFuel < fuelCapacity)
        {
            currentFuel += refuelRate * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0f, fuelCapacity);
            Debug.Log("Refueled! Current fuel level: " + currentFuel);
        }
    }
}
