using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFric : MonoBehaviour {

    public Camera cam;
    public Vector3 GForceVector;
    public Transform dc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnDrawGizmos()
    {
        if (!cam || !dc)
            return;

        Vector3 gforced = RainDropTools.GetGForcedScreenMovement(cam.transform, this.GForceVector);
        gforced = gforced.normalized;

        dc.localPosition = new Vector3(gforced.x, gforced.y, 0f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, dc.position);

        float angl = Mathf.Rad2Deg * Mathf.Atan2(gforced.y, gforced.x);
        Quaternion rot = Quaternion.AngleAxis(angl + 90f, Vector3.forward);
        Quaternion localrot = rot;
        dc.localRotation = localrot;

        float step = 0.1f;
        for (int i = 0; i < 5; i++)
        {
            float prog = i * step - (5 / 2) * step;
            Vector3 vec = new Vector3(prog, 0f, 0f);
            Gizmos.DrawSphere(dc.TransformPoint(vec), .2f);
        }
    }
}
