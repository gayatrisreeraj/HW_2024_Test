using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DestroySpawn : MonoBehaviour
{
    public GameObject platform, current;
    public GameObject doofus;
    public Text s, gameover;
    public float des_time = 4.0f; // Destroy time = 4
    public float sp_time = 2.5f; // Spawn time = 2.5
    public float sp_dis = 9.0f;
    Vector3 last;
    int score = 0;
    void Start()
    {
        current = Instantiate(platform);
        current.transform.position = new Vector3(0, 0, 0);
        last = current.transform.position;
        StartCoroutine(routine1());
    }
    private IEnumerator routine1()
    {
        while (doofus.transform.position.y>0)
        {
            yield return new WaitForSeconds(sp_time);
            Vector3 pos = current.transform.position;
            Vector3 dis = new Vector3(0, 0, 0);
            // Randomly generate spawns of the platform
            do
            {
                int side = Random.Range(0, 4);
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
            } while ((pos + dis)==last);
            GameObject new_platform = Instantiate(platform);
            new_platform.transform.position = pos + dis;
            new_platform.tag = "Platform";
            StartCoroutine(routine2(current, des_time));
            last = new_platform.transform.position;
            current = new_platform;
            // Update score
            score += 1;
            s.text = "Score: " + score;
        }
        if (doofus.transform.position.y<0)
        {
            // Display Game Over
            gameover.text = "Game Over!";
            yield return new WaitForSeconds(3.0f);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }    private IEnumerator routine2(GameObject p, float des_time)
    {
        yield return new WaitForSeconds(des_time);
        // Destroy the previous platform
        Destroy(p);
    }
}