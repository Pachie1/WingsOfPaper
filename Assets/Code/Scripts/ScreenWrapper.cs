using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    [SerializeField] Camera Gcamera;
    private float cameraHeight;
    private float cameraWidth;
    private float playerWidth;
    private float playerSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraHeight = Gcamera.orthographicSize * 2f;
        cameraWidth = Gcamera.aspect * cameraHeight;
        playerWidth = GetComponent<SpriteRenderer>().size.x * transform.localScale.x;
        playerSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {   
        if (transform.position.x <= Gcamera.transform.position.x - cameraWidth/2 - playerWidth/2)
        {
            transform.position = new Vector2(Gcamera.transform.position.x + cameraWidth / 2, transform.position.y);
        }else if (transform.position.x >= Gcamera.transform.position.x + cameraWidth / 2 + playerWidth/2)
        {
            transform.position = new Vector2(Gcamera.transform.position.x - cameraWidth / 2, transform.position.y);
        }
    }
}
