using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFruit : MonoBehaviour
{
    [Header("Splash Config")]
    [SerializeField] Transform objectTransform;
    private float delay = 0;
    private float pastTime = 0;
    private float when = 1.0f;
    private Vector3 off;

    
    void Start()
    {
        off = new Vector3(Random.Range(-0.5f, 0.5f), off.y, off.z);
        off = new Vector3(off.x, Random.Range(-0.5f, 0.5f), off.z);
    }
    private void Update()
    {
        if(when >= delay) 
        {
            pastTime = Time.deltaTime;

            objectTransform.position += off * Time.deltaTime * 5f;
            delay += pastTime;
        }
    }

    private void OnMouseDown()
    {
        Collect();
    }
    private void Collect() 
    {
        Destroy(gameObject);
    }
}
