using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float speed = 5.0f;
    private float leftscreen;
    private void Start()
    {
        leftscreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < leftscreen)
        {
            Destroy(gameObject);
        }
    }
}
