using UnityEngine;
[System.Serializable]

public class ParallaxLayers
{
    [SerializeField] private Transform background;
    [SerializeField] private float paralaxMultiplier;
    [SerializeField] private float imageWidthOffset = 10;
    private float imageFullWidth;
    private float imageHalfWidth;
    public void CalculateImageWidth()
    {
        imageFullWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalfWidth = imageFullWidth / 2;
    }
    public void Move(float distanceToMove)
    {
        background.position += new Vector3(distanceToMove * paralaxMultiplier, 0, 0);
    }
    public void LoopBackground(float cameraRightEdge, float cameraLeftEdge)
    {
       float  imageRightEdge = (background.position.x + imageHalfWidth) - imageWidthOffset;
        float imageLeftEdge = (background.position.x - imageHalfWidth) + imageWidthOffset;
        if (imageRightEdge < cameraLeftEdge)
        {
            background.position += new Vector3(imageFullWidth, 0, 0);
        }
        else if (imageLeftEdge > cameraRightEdge)
        {
            background.position -= new Vector3(imageFullWidth, 0, 0);
        }
    }
}
