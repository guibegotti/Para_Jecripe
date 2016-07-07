using UnityEngine;
using System.Collections;

public class FloatMovement : MonoBehaviour {

    private float amplitude;
    private float speed;

    void Start() {
        amplitude = Random.Range(0.003f, 0.004f);
        speed = Random.Range(2f, 4f);
    }

	void Update () {
        if (Time.timeScale != 0)
        {
            float x = transform.position.x + amplitude * Mathf.Sin(speed * Time.time);
            float y = transform.position.y + amplitude * Mathf.Sin(speed * Time.time);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
