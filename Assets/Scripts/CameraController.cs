using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Player player;

    float speed;
    Vector3 pos = new Vector3((float)-0.5, 5, 0); 
    /*private void Awake()
    {
        
    }*/
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        transform.position = pos;
    }

    
    private void FixedUpdate()
    {
        
        pos.z = player.rigidbody.position.z;
        transform.position = pos; 
    }
}
