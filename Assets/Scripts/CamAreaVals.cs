using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAreaVals : MonoBehaviour
{
    [Tooltip("How far the camera should zoom out while player is in this area.")]
    public float zoomTarget;
    [Tooltip("Where the camera should target while the player is in this area. PLAYER -> camera follows player. FIXED -> camera targets position of this CameraArea's transform component")]
    public CameraAreaTarget target;
    private GameObject player;
    private Collider2D playerCollider;
    private Camera playerCam;
    private PlayerCameraScript camScript;
    private float prevCamZoomTarget = 7.5f;
    public enum CameraAreaTarget {
        PLAYER, //Camera targets player while player is in CameraArea
        FIXED //Camera targets a fixed point (the position of the CameraAreas transform)
            //while player is in CameraArea
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerCollider = player.GetComponent<PolygonCollider2D>();
        playerCam = GameObject.Find("Camera").GetComponent<Camera>();
        camScript = playerCam.GetComponent<PlayerCameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.Equals(playerCollider)) {
            prevCamZoomTarget = camScript.zoomTarget;
            camScript.zoomTarget = zoomTarget;
            if (target == CameraAreaTarget.FIXED) {
                camScript.setCameraTarget(transform);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.Equals(playerCollider)) {
            camScript.zoomTarget = prevCamZoomTarget;
            camScript.setCameraTarget(player.transform);
        }
    }
}
