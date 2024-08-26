using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform obj;
    void Update () {
        transform.position = obj.transform.position + new Vector3(0, 10, -17);
    }
}