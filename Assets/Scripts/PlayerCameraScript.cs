using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraScript : MonoBehaviour
{
    private GameObject player;
    private Transform pTransform;
    private PlayerMovement pScript;
    private Rigidbody2D playerRB;
    private Camera camComponent;
    [Tooltip("Increase this value to make the camera react slower")]
    public float smoothing;
    [Tooltip("Increase this value to make the camera aim farther ahead of the player")]
    public float lookAhead;
    [Tooltip("Increase this for the camera to zoom out until reaching this value")]
    public float zoomTarget;
    private Vector3 camVelocity;
    private float zoomVelocity;
    private PolygonCollider2D playerCollider;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("O_Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        pScript = player.GetComponent<PlayerMovement>();
        transform.parent = null;
        camComponent = gameObject.GetComponent<Camera>();
        playerCollider = player.GetComponent<PolygonCollider2D>();
        target = player.transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref camVelocity, smoothing);
        camComponent.orthographicSize = Mathf.SmoothDamp(camComponent.orthographicSize, zoomTarget, ref zoomVelocity, smoothing);
    }

    public void setCameraTarget(Transform target) {
        this.target = target;
    }
}
