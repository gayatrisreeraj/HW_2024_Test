using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject doofus;
    // Player speed
    public float doofus_speed = 3.0f;
    void Update()
    {
        // Move the object using arrow keys
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * doofus_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * doofus_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * doofus_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * doofus_speed * Time.deltaTime);
        }
    }
}