using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer mr;
    public float animationSpeed = 0.05f;

    private void Awake() {
        mr = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
