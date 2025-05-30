using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    
    private Camera mainCamera;
    private float lastCameraPositionX;
    private float cameraHalfWidth;
    [SerializeField] private ParallaxLayers[] backgroundLayers;

    private void Awake()
    {
        mainCamera = Camera.main;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        CalculateBackgroundWidth();
     

    }
    void FixedUpdate()
    {
        float currentCameraPositionX = mainCamera.transform.position.x;
        float distanceToMove = currentCameraPositionX - lastCameraPositionX;
        lastCameraPositionX = currentCameraPositionX;
        float cameraRightEdge = currentCameraPositionX + cameraHalfWidth;
        float cameraLeftEdge = currentCameraPositionX - cameraHalfWidth;
        foreach (ParallaxLayers layer in backgroundLayers)
        {
            layer.Move(distanceToMove);
            layer.LoopBackground(cameraRightEdge, cameraLeftEdge);
        }
   
    }
    private void CalculateBackgroundWidth()
    {
        foreach (ParallaxLayers layer in backgroundLayers)
        {
            layer.CalculateImageWidth();
        }
    }

}
