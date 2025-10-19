using UnityEngine;

public class Bat : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    public Sprite[] sprites;
    private int spriteindex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float str = 5f;

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
    }
    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * str;
        }
   
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * str;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
}
