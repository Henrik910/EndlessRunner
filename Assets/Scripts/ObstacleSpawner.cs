using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Obstacle prefab;
    [SerializeField] GameObject plane;
    [SerializeField] float frequency = 5f, offset = 4f;

    [SerializeField] Transform left, mid, right;

    float counter = 0f;

    Transform player;

    int t;

    int p;

    GameObject g;

    Vector3 pos;

    private void Awake()
    {

    this.player = FindObjectOfType<Player>().transform;
    Instantiate(plane, left);
    Instantiate(plane, mid);
    Instantiate(plane, right);
    }

    private void Update()
    {
        this.counter += Time.deltaTime;
        if(this.counter >= this.frequency)
        {
            this.Spawn();
        }
        g = GameObject.FindWithTag("Obstacle");
        Destroy(g, 10);
        t++;

        if(t >= 1000)
        {
            pos = left.position;
            pos.z = left.position.z + 1000000;
            Instantiate(plane, pos, Quaternion.identity, left);

            pos = mid.position;
            pos.z = mid.position.z + 1000000;
            Instantiate(plane, pos, Quaternion.identity, mid);
            pos = right.position;
            pos.z = right.position.z + 1000000;
            Instantiate(plane, pos, Quaternion.identity, right);
            if(frequency >= 0.3f){
            frequency -= 0.05f;
            }
            p++;
            t = 0;
        }
        
        
    }

    void Spawn()
    {
        Vector3 spawnPosition = this.player.position;
        spawnPosition.z = spawnPosition.z + this.counter + 70;
        switch(Random.Range(0, 3))
        {
            case 0:
                spawnPosition.x = this.left.position.x;
                break;
            case 1:
                spawnPosition.x = this.mid.position.x;
                break;
            case 2:
                spawnPosition.x = this.right.position.x;
                break;
        }
        Instantiate(this.prefab, spawnPosition, Quaternion.identity);
        this.counter = 0f;
    }
}
