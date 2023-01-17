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
    public Animator animator;
    Vector2 movement;
    float inputX, inputY;
    
        //modifiable values
    public float speed = 5f;
    public float sprintSpeed = 7.5f;
    public float accel = 2f;
    public bool canMove = true;

    public Vector2 velocity;

    bool isSlow = false;
    public Rigidbody2D rigidBody;

    
    LayerMask groundLayer;

    PopupManager popupManager;


    void Awake(){
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCam.enabled = true;
        popupManager = PopupManager.instance;
    }

    void Update() {
        //player facing
        
        if (canMove) {
            //player movement
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
            if ( inputX != 0 || inputY != 0 ) 
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
            //sprint
            if (Input.GetKey("left shift")){
                rigidBody.velocity = new Vector2(inputX, inputY) * sprintSpeed;
                animator.SetBool("IsSprinting", true);
            }
            else {
                rigidBody.velocity = new Vector2(inputX, inputY) * speed;
                animator.SetBool("IsSprinting", false);
            }
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

        // finish this part
        transform.Translate(velocity);
        if ( rigidBody.velocity != Vector2.zero )
        {
            float facingAngle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x)* Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.forward * (facingAngle - 90);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Drill")){
            //highlight drill
            drillPresent = true;
            drillControllable = collision.GetComponent<DrillHealth>();
        }
        else if ( collision.tag.Equals("Interactable") || collision.tag.Equals("Slime" ) ) {
            popupManager.objectShowing = collision.GetComponent<IInteractable>();
            popupManager.show_popup( popupManager.objectShowing );
        }
        else {
            mostRecent = collision.gameObject;  //stores object in script
            items.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.tag.Equals("Drill")){
            //unhighlight drill
            drillPresent = false;

            drillControllable = null;

        }
        else if ( collision.tag.Equals("Interactable") || collision.tag.Equals("Slime" ) ) {
            if ( collision.GetComponent<IInteractable>().Equals( popupManager.objectShowing ) ) {
                popupManager.hide_popup();
                popupManager.objectShowing = null;
            }
        }
    }


}
