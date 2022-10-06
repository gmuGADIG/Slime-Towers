using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //player interaction variables
    private PolygonCollider2D bodyCollider;
    private CircleCollider2D interact2D;
    private bool drillPresent = false;
    private bool inDrill = false;

    private List<GameObject> items = new List<GameObject>();
    private GameObject mostRecent;
    private GameObject drillControllable;

    //mouse/sprite control variables*

    //player movement variables
    Vector2 movement;
    float inputX, inputY;
    
        //modifiable values
    public float speed = 5f;
    public float sprintSpeed = 7.5f;
    public float accel = 2f;

    public Vector2 velocity;

    bool isSlow = false;
    public Rigidbody2D rigidBody;


    
    LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        //player facing
        

        //player movement
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
            //sprint
        if (Input.GetKey("left shift")){
            velocity = new Vector2(inputX, inputY) * Time.deltaTime * (speed + sprintSpeed);
        }
        else {
            velocity = new Vector2(inputX, inputY) * Time.deltaTime * speed;
        }

        //player interact
        if (Input.GetKeyDown(KeyCode.E)) { 
            if (drillPresent && mostRecent.CompareTag("Drill")) {
            }
        }


        //player sprite rotate
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("mousePosition: " + worldPosition.ToString());

        transform.Translate(velocity);
    }

    private void drillEnter() {
        inDrill = true;

        this.gameObject.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Drill")){
            //highlight drill
            Debug.Log("Drill in Range");
            drillPresent = true;
            drillControllable = collision.gameObject;
        }
        else {
            mostRecent = collision.gameObject;  //stores object in script
            items.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.tag.Equals("Drill")){
            //unhighlight drill
            Debug.Log("Drill out of range");
            drillPresent = false;

            drillControllable = collision.gameObject;

        }
    }

}
