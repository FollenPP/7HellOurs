using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //ref
    public Transform player;
    [SerializeField]
    private Vector3 offset;

    //variable
    private float smoothSpeed = 5f; 
    
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        Vector3 desirePosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desirePosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        
    }
}
