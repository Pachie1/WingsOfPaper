using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightGame : MonoBehaviour


{
    public Light2D light2D;
    public float speed = 3f;

    public float intensityMin = 0.1f;
    public float intensityMax = 0.5f;

    public float radiusOuter = 0.5f;
    public float radiusInner = 0.1f;

    void Update()
    {
        GetComponent<Light>().intensity = Mathf.Lerp(
       intensityMax, intensityMin,
       Mathf.PingPong(Time.time * speed, 2)
      );
    }
}
