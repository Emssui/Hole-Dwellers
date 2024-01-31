using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public Sprite skin1, skin2, skin3, skin4;

    private void Update()
    {
        GameObject inventoryObject = GameObject.FindWithTag("Inventory");

        if (inventoryObject != null && inventoryObject.activeSelf)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                    spriteRenderer.sprite = skin1;
                else if (Input.GetKeyDown(KeyCode.W))
                    spriteRenderer.sprite = skin2;
                else if (Input.GetKeyDown(KeyCode.E))
                    spriteRenderer.sprite = skin3;
                else if (Input.GetKeyDown(KeyCode.R))
                    spriteRenderer.sprite = skin4;

            }
        }
    }
}