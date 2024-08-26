using UnityEngine;

public class Follow : MonoBehaviour 
{

    public Transform obj;
    void Update () 
    {
        // To make the camera follow the player
        transform.position = obj.transform.position + new Vector3(0, 10, -17);
    }
}