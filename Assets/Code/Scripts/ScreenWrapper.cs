using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    [SerializeField] Camera Gcamera;
    private float cameraHeight;
    private float cameraWidth;
    private float playerWidth;
    private float playerHeight;
    private float playerSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraHeight = Gcamera.orthographicSize * 2f;
        cameraWidth = Gcamera.aspect * cameraHeight;
        playerWidth = GetComponent<SpriteRenderer>().size.x * transform.localScale.x;
        playerHeight = GetComponent<SpriteRenderer>().size.y * transform.localScale.y;
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

        if (transform.position.y <= Gcamera.transform.position.y - cameraHeight / 2 + playerHeight/2)
        {
            transform.position = new Vector2(transform.position.x, Gcamera.transform.position.y - cameraHeight / 2 + playerHeight/2);
        }
        else if (transform.position.y >= Gcamera.transform.position.y + cameraHeight / 2 - playerHeight / 2)
        {
            transform.position = new Vector2(transform.position.x, Gcamera.transform.position.y + cameraHeight / 2 - playerHeight/2);
        }
    }
}
