using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public Sprite skin1, skin2, skin3, skin4;

    bool inventory;

    private void Update()
    {
        if(inventory) {
            if(Input.GetKeyDown(KeyCode.Q)) GetComponent<SpriteRenderer>().sprite = skin1;
           
            else if(Input.GetKeyDown(KeyCode.W)) GetComponent<SpriteRenderer>().sprite = skin2;
            
            else if(Input.GetKeyDown(KeyCode.E)) GetComponent<SpriteRenderer>().sprite = skin3;
            
            else if(Input.GetKeyDown(KeyCode.R)) GetComponent<SpriteRenderer>().sprite = skin4;
        }
    }
}