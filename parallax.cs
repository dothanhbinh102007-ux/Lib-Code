using System.Runtime.CompilerServices;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private Material material;
    [SerializeField]
    private float ParallaxFactor = 0.01f; //toc do di chuyen cua parallax
     [SerializeField]
     private Camera mainCamera;
    private float offset; // tinh toan dieu chinh offset
    private float lastCameraX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        if (mainCamera == null)
            mainCamera = Camera.main;

        lastCameraX = mainCamera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        PrallaxScroll();
    }
    private void PrallaxScroll()
    {
            float posX = mainCamera.transform.position.x - lastCameraX;
            Vector2 offset = material.GetTextureOffset("_MainTex");
            offset.x += posX * ParallaxFactor;
            material.SetTextureOffset("_MainTex", offset);
            lastCameraX = mainCamera.transform.position.x;

    }
}
