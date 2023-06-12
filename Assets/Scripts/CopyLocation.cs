using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLocation : MonoBehaviour
{
    [SerializeField]
    Transform copyPosTarget;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(copyPosTarget.position.x, copyPosTarget.position.y+100.0f, copyPosTarget.position.z);;
    }
}
