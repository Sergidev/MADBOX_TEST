using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Follower;

    [SerializeField]
    GameObject[] Paths;

    [SerializeField]
    int PathNumber = 0;

    [SerializeField]
    float T = 0f;
    [SerializeField]
    float Speed = 1f;
    bool GoRoute = true;

    [SerializeField]
    bool Touch = false;

    public bool Finished = false;

    Transform Yrot;

    private void Start()
    {
        Yrot = Follower.transform;
    }

    public void Restart()
    {
        /*Speed = 1f;
        Finished = false;
        PathNumber = 0;
        GoRoute = true;
        T = 0f;
        Touch = false;*/

        SceneManager.LoadScene("MainScene");
    }

    void Update()
    {
        Follower.transform.rotation = Quaternion.Lerp(Follower.transform.rotation, Yrot.rotation, Time.deltaTime * 2);

        /*if (Input.touchCount > 0)
            Speed = 1f;
        else
            Speed = 0;*/

        if (Touch)
            Speed = 1f;
        else
            Speed = 0;

        if (GoRoute && !Finished)
        {
            StartCoroutine(WalkPath(PathNumber));
        }
    }

    private IEnumerator WalkPath(int path)
    {
            GoRoute = false;

            Vector3 step1 = Paths[path].transform.GetChild(0).position;
            Vector3 step2 = Paths[path].transform.GetChild(1).position;
            Vector3 step3 = Paths[path].transform.GetChild(2).position;
            Vector3 step4 = Paths[path].transform.GetChild(3).position;

            while (T < 1)
            {
                T += Time.deltaTime * Speed * Paths[path].GetComponent<SpeedPath>().SpeedMove;

                this.transform.position = Mathf.Pow(1 - T, 3) * step1 +
                3 * Mathf.Pow(1 - T, 2) * T * step2 +
                3 * (1 - T) * Mathf.Pow(T, 2) * step3 +
                Mathf.Pow(T, 3) * step4;
            
                yield return new WaitForEndOfFrame();
            }

            T = 0f;
            PathNumber++;

        if (PathNumber > Paths.Length)
            Finished = true;

            GoRoute = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            Finished = true;
        }

        else if (other.gameObject.tag == "Respawn")
        {
            Restart();
        }

        else if (other.gameObject.tag == "MainCamera")
        {
            Yrot = other.gameObject.transform;
        }
    }
}
