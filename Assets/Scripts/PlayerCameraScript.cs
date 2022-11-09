using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    private GameObject player;
    private Transform pTransform;
    private PlayerMovement pScript;
    private Rigidbody2D playerRB;
    public float smoothing;
    private Vector3 camVelocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pTransform = player.transform;
        playerRB = player.GetComponent<Rigidbody2D>();
        pScript = player.GetComponent<PlayerMovement>();
        //transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + (pTransform.position - transform.position) * smoothing;
        //camVelocity += (playerRB.velocity - camVelocity) * smoothing;
        //transform.position += new Vector3(camVelocity.x, camVelocity.y, 0);
        Vector3 targetPos = new Vector3(pTransform.position.x, pTransform.position.y, -10);
        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref camVelocity, smoothing);
        transform.position = targetPos;
    }
}
