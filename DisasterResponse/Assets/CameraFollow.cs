using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private GameObject target;

    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, xMin, xMax), Mathf.Clamp(target.transform.position.y, yMin, yMax), transform.position.z);
    }

    void Update()
    {

    }
}