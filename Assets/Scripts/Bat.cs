using UnityEngine;

public class Bat : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    public Sprite[] sprites;
    private int spriteindex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float str = 5f;
    public AudioSource audioSource;
    public AudioClip flapSound;

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Start()
    {
        InvokeRepeating(nameof(animate), 0.15f, 0.15f);
    }
    private void animate()
    {
        spriteindex++;
        if(spriteindex >= sprites.Length)
        {
            spriteindex = 0;
        }
        spriterenderer.sprite = sprites[spriteindex];
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        if (collider != null && spriterenderer.sprite != null)
        {
            collider.pathCount = spriterenderer.sprite.GetPhysicsShapeCount();
            for (int i = 0; i < collider.pathCount; i++)
            {
                var points = new System.Collections.Generic.List<Vector2>();
                spriterenderer.sprite.GetPhysicsShape(i, points);
                collider.SetPath(i, points.ToArray());
            }
        }
    }
    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        bool flapPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        if (flapPressed)
        {
            direction = Vector3.up * str;
            PlayFlapSound(); 
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * str;
                PlayFlapSound(); 
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            FindFirstObjectByType<GManager>().gameover();
        }
        else if(collision.gameObject.tag == "Points")
        {
            FindFirstObjectByType<GManager>().pluspoints();
        }
    }
    private void PlayFlapSound()
    {
        if (audioSource == null || flapSound == null)
            return;

        audioSource.Stop();
        audioSource.pitch = Random.Range(0.7f, 0.9f);
        audioSource.volume = 0.6f; 
        audioSource.PlayOneShot(flapSound);
    }

   

}
