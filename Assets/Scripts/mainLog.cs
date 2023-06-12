using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class mainLog : MonoBehaviour
{
    public GameObject objectPrefab; 
    // public GameObject particlePrefab; 
    public float spawnRadius = 40.0f; 
    public float timeBetweenSpawns = 5.0f; 
    private float spawnTimer = 0.0f; 
    private GameObject currentObject;
    public float distanceToCollect = 10.0f; 
    public KeyCode collectKey = KeyCode.E; 
    private bool canCollect = false; 
    public TextMeshProUGUI scoreText;
    // public GameObject markerPrefab;
    public int score = 0; 
    public FuelScript fuelScript;
    public GameObject interButton;

    private CylinderForceField cylinderForceField;

    void Start()
    {
       Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(transform.position.x + randomCircle.x, Random.Range(0f, 2f), transform.position.z + randomCircle.y);


        currentObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        cylinderForceField = gameObject.AddComponent<CylinderForceField>();
        cylinderForceField.targetObject = currentObject;
        cylinderForceField.fieldColor = Color.blue;
        cylinderForceField.fieldRadius = 2.5f;
        cylinderForceField.fieldHeight = 126.0f;
        cylinderForceField.fieldOpacity = 0.5f;

        // GameObject particleEffect = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);
        // particleEffect.transform.parent = currentObject.transform;

        canCollect = false;

       // CreateMarker(currentObject);

        interButton.SetActive(false);

    }

    // void CreateMarker(GameObject obj)
    // {
    //     GameObject marker = Instantiate(markerPrefab, obj.transform.position, Quaternion.identity);
    //     marker.transform.parent = obj.transform;
    // }


    void Update()
    {
       
        spawnTimer += Time.deltaTime;

        if (currentObject == null && canCollect)
        {
            score++;
            fuelScript.AddFuel(10.0f);
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(transform.position.x + randomCircle.x, Random.Range(0f, 2f), transform.position.z + randomCircle.y);


            currentObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            cylinderForceField.targetObject = currentObject;

            // GameObject particleEffect = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);
            // particleEffect.transform.parent = currentObject.transform;

            canCollect = false;

            interButton.SetActive(false);

            spawnTimer = 0.0f;
        }

        scoreText.text = (score).ToString() + " Collected";
        if (currentObject != null && Vector3.Distance(transform.position, currentObject.transform.position) <= distanceToCollect)
        {
            interButton.SetActive(true);
            if (Input.GetKeyDown(collectKey))
            {
                Destroy(currentObject);
                currentObject = null;
                canCollect = true;
            }
        }else{
            interButton.SetActive(false);
        }
    }
}
