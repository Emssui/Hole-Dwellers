using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int rotationSpeed = -90;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
    }
}
