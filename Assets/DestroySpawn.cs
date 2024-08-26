using System.Collections;
using UnityEngine;
public class DestroySpawn : MonoBehaviour
{
    public GameObject platform, current;
    public GameObject doofus;
    public float des_time = 4.0f;
    public float sp_time = 2.5f;
    public float sp_dis = 9.0f;
    void Start()
    {
        current = Instantiate(platform);
        current.transform.position = new Vector3(0, 0, 0);
        StartCoroutine(routine1());
    }
    private IEnumerator routine1()
    {
        while (doofus.transform.position.y > 0)
        {
            yield return new WaitForSeconds(sp_time);
            GameObject new_platform = Instantiate(platform);
            Vector3 pos = current.transform.position;
            int side = Random.Range(0, 4);
            Vector3 dis = new Vector3(0, 0, 0);
            if (side == 0)
            {
                dis = Vector3.back * sp_dis;
            }
            else if (side == 1)
            {
                dis = Vector3.forward * sp_dis;
            }
            else if (side == 2)
            {
                dis = Vector3.right * sp_dis;
            }
            else if (side == 3)
            {
                dis = Vector3.left * sp_dis;
            }
            new_platform.transform.position = pos + dis;
            new_platform.tag = "Platform";
            StartCoroutine(routine2(current, des_time));
            current = new_platform;
        }
    }
    private IEnumerator routine2(GameObject p, float des_time)
    {
        yield return new WaitForSeconds(des_time);
        Destroy(p);
    }
}