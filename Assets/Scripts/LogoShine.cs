using UnityEngine;

public class LogoShine : MonoBehaviour
{
    public float speed = 2f;  // Adjust this value to change the speed of the line
    public float lineWidth = 0.1f;  // Adjust this value to change the width of the line
    public Color lineColor = Color.white;  // Adjust this value to change the color of the line
    public Material lineMaterial;  // Drag and drop a material with a "Unlit/Color" shader here
    private LineRenderer lineRenderer;
    private float timeOffset;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        timeOffset = Random.Range(0f, 1f);  // Add random time offset to make lines appear different
    }

    void Update()
    {
        float time = Time.time + timeOffset;
        Vector3 startPos = new Vector3(-1f, 0f, 0f);  // Starting position of the line
        Vector3 endPos = new Vector3(1f, 0f, 0f);  // Ending position of the line
        float t = Mathf.PingPong(time * speed, 1f);  // Time value used for animating the line position
        Vector3 pos = Vector3.Lerp(startPos, endPos, t);  // Current position of the line
        lineRenderer.SetPosition(0, pos + transform.position);  // Set the starting position of the line
        lineRenderer.SetPosition(1, pos + transform.position);  // Set the ending position of the line
    }
}
