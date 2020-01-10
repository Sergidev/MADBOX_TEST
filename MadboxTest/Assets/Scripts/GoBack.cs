using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    [SerializeField]
    private Transform StartPos;

    [SerializeField]
    private Transform EndPos;

    [SerializeField]
    float speedGo;

    [SerializeField]
    float speedBack;

    int path = 0;

    private void Start()
    {
        this.transform.position = StartPos.position; 
    }

    void Update()
    {
        if (path == 1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, EndPos.position, Time.deltaTime * speedGo);

            if (this.transform.position == EndPos.position)
                path = 0;
        }
        else if (path == 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, StartPos.position, Time.deltaTime * speedBack);

            if (this.transform.position == StartPos.position)
                path = 1;
        }
    }
}
