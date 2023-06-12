using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderForceField : MonoBehaviour
{
    [SerializeField] public GameObject targetObject;
    [SerializeField] public Color fieldColor = Color.blue;
    [SerializeField] public float fieldRadius = 1.5f;
    [SerializeField] public float fieldHeight = 125.5f;
    [SerializeField] public float fieldOpacity = 0.5f;

    private Transform cylinderTransform;
    private Transform emptyGameObjectTransform;
    private Quaternion originalRotation;
    private Material cylinderMaterial;

    void Start()
    {
        emptyGameObjectTransform = new GameObject("CylinderForceField").transform;
        emptyGameObjectTransform.position = transform.position;
        emptyGameObjectTransform.rotation = targetObject.transform.rotation;

        cylinderTransform = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
        cylinderTransform.localScale = new Vector3(fieldRadius * 2, fieldHeight, fieldRadius * 2);
        cylinderMaterial = new Material(Shader.Find("Transparent/Diffuse"));
        cylinderTransform.GetComponent<Renderer>().material = cylinderMaterial;
        cylinderTransform.GetComponent<Renderer>().material.color = new Color(fieldColor.r, fieldColor.g, fieldColor.b, fieldOpacity);
        cylinderTransform.GetComponent<Renderer>().material.SetFloat("_Metallic", 1.0f);
        cylinderTransform.GetComponent<Renderer>().material.SetFloat("_Glossiness", 0.0f);
        cylinderTransform.GetComponent<Collider>().enabled = false;
        cylinderTransform.parent = emptyGameObjectTransform;
        originalRotation = cylinderTransform.rotation;
    }

    void LateUpdate()
    {
        if (targetObject != null)
        {
            emptyGameObjectTransform.position = targetObject.transform.position;
            emptyGameObjectTransform.rotation = targetObject.transform.rotation;
        }
        cylinderTransform.rotation = originalRotation;
    }
}
