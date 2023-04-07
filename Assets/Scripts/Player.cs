using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Rigidbody rigidbody;
    [SerializeField] public float speed = 5f;
    [SerializeField] Transform left, mid, right, transform;
    [SerializeField] int healthPoints = 3;
    int currentLane;

    int counter;

    HealthView healthView;

    private void Awake() 
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.transform = transform;
        this.healthView = FindObjectOfType<HealthView>();
    }

    private void Start()
    {
        this.currentLane = 1;
        this.rigidbody.position = this.transform.position;
        this.healthView.SetLive(this.healthPoints);
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            this.healthPoints--;
            this.healthView.SetLive(this.healthPoints);
            if(this.healthPoints <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }


    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            this.MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            this.MoveRight();
        }
        
    }
    private void FixedUpdate() {
        counter++;
        if(counter >= 500)
        {
            this.speed += 2.5f;
            counter = 0;
        }
        Vector3 target = this.rigidbody.position;
        target.z += Time.deltaTime * this.speed;
        this.rigidbody.MovePosition(target);
        
        
    }

    void MoveLeft()
    {
        Vector3 newPos;
        switch(this.currentLane)
        {
            case 0:
                return;
            case 1:
                this.currentLane--;
                newPos = this.transform.position;
                newPos.x = this.left.position.x;
                this.transform.position = newPos;
                break;
            case 2:
                this.currentLane--;
                newPos = this.transform.position;
                newPos.x = this.mid.position.x;
                this.transform.position = newPos;
                break;


        }
    }
    void MoveRight()
    {
        Vector3 newPos;
        switch(this.currentLane)
        {
            case 0:
                this.currentLane++;
                newPos = this.transform.position;
                newPos.x = this.mid.position.x;
                this.transform.position = newPos;
                break;
            case 1:
                this.currentLane++;
                newPos = this.transform.position;
                newPos.x = this.right.position.x;
                this.transform.position = newPos;
                break;
            case 2:
                return;


        }
    }
}
