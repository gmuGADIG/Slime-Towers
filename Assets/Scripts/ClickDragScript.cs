using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragScript : MonoBehaviour
{
    bool Moving;

    // Update is called once per frame
    void Update()
    {
        if(Moving){
            if(Input.GetMouseButtonUp(0)){
                Moving = false;
            }
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector3(pos.x,pos.y,0);
            transform.position = pos;
        }
    }

    void OnMouseOver(){
        Debug.Log("MouseOver");
        if(Input.GetMouseButtonDown(0)){
            Moving = true;
        }
    }
}
