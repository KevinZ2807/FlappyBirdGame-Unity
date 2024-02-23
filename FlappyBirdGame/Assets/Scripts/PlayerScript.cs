using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f; // Strength to push the bird go up

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {   
        // InvokeRepeating: Goi ham lap lai nhieu lan
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void FixedUpdate()
    {   
        // INPUTS FOR MOVING
        InputFunction();


    }  
    void OnEnable()
    {
       Vector3 position = transform.position; // Lay vi tri cua player
       position.y = 0f; // Set do cao len bang 0f
       transform.position = position; // Tele player den vi tri do
       direction = Vector3.zero; // Reset vat ly (Trong luc)
    }

    private void InputFunction() {
        // INPUT
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }
        
        // Control for Mobile Game:
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0); // Cham man hinh
            if (touch.phase == TouchPhase.Began) { // Khi vua cham vao man hinh
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime; // Falling
        transform.position += direction * Time.deltaTime; // Push the bird up (Jump)
    }

    private void AnimateSprite() {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        sr.sprite = sprites[spriteIndex]; // Hoat anh cua con chim se
                                        // thanh hình anh trong array sprites
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit " + other);
        if (other.gameObject.tag == "Obstacles" || other.gameObject.tag == "Ground") {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
