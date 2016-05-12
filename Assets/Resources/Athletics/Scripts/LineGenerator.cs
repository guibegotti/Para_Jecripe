using UnityEngine;
using System.Collections;

public class LineGenerator : MonoBehaviour {

    private LineRenderer l;
    public Transform athlete1;
    public Transform guide2;

    // Use this for initialization
    void Start () {
        l = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        l.SetPosition(0, athlete1.position);
        l.SetPosition(1, guide2.position);
	}
}
