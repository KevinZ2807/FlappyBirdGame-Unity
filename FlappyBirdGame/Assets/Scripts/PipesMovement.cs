using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float leftEdge;

    private void Start() {
        // Tinh toan gia tri man hinh trai de khien pipi di qua bien mat
        // (Khong quan tam size man hinh nhu the nao)
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // Pipes di chuyen sang trái
        if (transform.position.x <leftEdge) { // Khi pipes qua het man hinh trai
            Destroy(gameObject); // bien mat
        }
    }
}
