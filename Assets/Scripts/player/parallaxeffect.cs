using UnityEngine;

public class parallaxeffect : MonoBehaviour
{
    private GameObject cam;
    private float xposition;
    [SerializeField] float parallaxEffect;
    private float length;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        xposition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    void Update()
    {
        float distancemoved = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(xposition + distance, transform.position.y);
        if (distancemoved > xposition + length)
        {
            xposition = xposition + length;


        }
        else if (distancemoved < xposition - length)
        {
            xposition = xposition - length;

        }

    }
    }

