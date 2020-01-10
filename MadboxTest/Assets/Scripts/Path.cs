using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform[] Steps;

    private Vector3 GizmosPos;

    [SerializeField]
    private float sizeStep = 0.025f;

   private void OnDrawGizmos()
    {
        for(float t = 0; t <= 1; t += sizeStep)
        {
            GizmosPos =
                Mathf.Pow(1 - t, 3) * Steps[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * Steps[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * Steps[2].position +
                Mathf.Pow(t, 3) * Steps[3].position;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(GizmosPos, 0.15f);
        }

        Gizmos.DrawLine(new Vector3(Steps[0].position.x, Steps[0].position.y, Steps[0].position.z),
            new Vector3(Steps[1].position.x, Steps[1].position.y, Steps[1].position.z));

        Gizmos.DrawLine(new Vector3(Steps[2].position.x, Steps[2].position.y, Steps[2].position.z),
            new Vector3(Steps[3].position.x, Steps[3].position.y, Steps[3].position.z));
    }
}
