//Jarvis
//3/11/24

using UnityEngine;

public class LavaScript : MonoBehaviour
{
    // Material of the current object
    private Material material;

    // Variable to track the incrementing value of the X component for _NoiseUVSpeed
    float noiseXValue = 0f;

    // Variable to control the speed of increment for _NoiseUVSpeed
    [SerializeField]
    private float incrementSpeed = 0.01f;

    // Variable to control the speed of pingpong effect for _EdgeColorIntensity
    [SerializeField]
    private float pingPongSpeedGlow = 3.0f; // Slow speed: ie. the higher the value, the slower the pingpong.

    [SerializeField]
    private float pingPongSpeedDissolve = 20.0f; // Slow speed: ie. the higher the value, the slower the pingpong.

    // Start is called before the first frame update
    void Start()
    {
        // Get the material from the current object
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we have a material to work with
        if (material != null)
        {
            // Increment the X value very slowly for _NoiseUVSpeed
            noiseXValue += Time.deltaTime * incrementSpeed;

            // Reset the value to 0 if it exceeds 1, creating a loop
            if (noiseXValue > 10f)
            {
                noiseXValue = 0f;
            }

            // Update the material with the new X value for _NoiseUVSpeed
            SetNoiseUVSpeedX(noiseXValue);

            // PingPong the _EdgeColorIntensity value between 0.6 and 1.6
            float edgeColorIntensity = 0.6f + Mathf.PingPong(Time.time / pingPongSpeedGlow, 1);
            material.SetFloat("_EdgeColorIntensity", edgeColorIntensity);

            // PingPong the _Dissolve value between 0 and 1.
            float dissolveValue = 0.15f + Mathf.PingPong(Time.time / pingPongSpeedDissolve, 0.65f);
            material.SetFloat("_Dissolve", dissolveValue);
        }
    }

    // Function to set the X value of _NoiseUVSpeed for the material
    public void SetNoiseUVSpeedX(float xValue)
    {
        Vector2 noiseUVSpeed = material.GetVector("_NoiseUVSpeed");
        noiseUVSpeed.x = xValue;
        material.SetVector("_NoiseUVSpeed", noiseUVSpeed);
    }
}
