using UnityEngine;
using System.Collections;

public class FloatMovement : MonoBehaviour {

    private float amplitude;
    private float speed;

    void Start() {
        amplitude = Random.Range(0.03f, 0.04f);
        speed = Random.Range(2f, 4f);
    }

	void Update () {
        
        float x = transform.position.x + amplitude * Mathf.Sin(speed * Time.time);
        float y = transform.position.y + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
