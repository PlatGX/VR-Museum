using UnityEngine;

public class PredatorFloater : MonoBehaviour
{
    public float floatSpeed = 1.0f;
    public float floatHeight = 0.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
