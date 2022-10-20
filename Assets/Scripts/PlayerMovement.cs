using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //player interaction variables
    private PolygonCollider2D bodyCollider;
    private CircleCollider2D interact2D;
    private bool drillPresent = false;

    private List<GameObject> items = new List<GameObject>();
    private GameObject mostRecent;
    public DrillHealth drillControllable; //set in unity scene

    //mouse/sprite control variables*

    //player movement variables
    public Camera playerCam;
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
        playerCam.enabled = true;
    }

    void Update() {
        //player facing
        

        //player movement
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
            //sprint
        if (Input.GetKey("left shift")){
            rigidBody.velocity = new Vector2(inputX, inputY) * (speed + sprintSpeed);
        }
        else {
            rigidBody.velocity = new Vector2(inputX, inputY) * speed;
        }

        //player interact
        if (Input.GetKeyDown(KeyCode.E)) { 
            if (drillPresent /*&& ManagerScript.gm.getGameState() == GameState.EXPLORE*/) {
                drillControllable.playerEnter(this.gameObject);
            }
        }


        //player sprite rotate
        Vector3 worldPosition = playerCam.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("mousePosition: " + worldPosition.ToString());

        transform.Translate(velocity);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Drill")){
            //highlight drill
            Debug.Log("Drill in Range");
            drillPresent = true;
            drillControllable = collision.GetComponent<DrillHealth>();
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

            drillControllable = null;

        }
    }

}
