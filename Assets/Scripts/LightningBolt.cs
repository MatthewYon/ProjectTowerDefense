using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightningBolt : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public int segments = 10;
    public float offset = 0.5f;
    public float duration = 0.1f;

    private LineRenderer lineRenderer;
    private float timer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            lineRenderer.enabled = true;
            GenerateLightning();
            timer = duration;

            // Désactiver après un court délai
            Invoke(nameof(HideLine), duration);
        }
    }

    void GenerateLightning()
    {
        if(endPoint == null)
            return;
        Vector3 start = startPoint.position;
        Vector3 end = endPoint.position;
        Vector3 direction = (end - start).normalized;
        float distance = Vector3.Distance(start, end);

        for (int i = 0; i <= segments; i++)
        {
            float t = (float)i / segments;
            Vector3 point = Vector3.Lerp(start, end, t);

            // Ajouter un petit décalage aléatoire
            Vector3 randomOffset = Vector3.Cross(direction, Random.insideUnitSphere) * Random.Range(-offset, offset);
            point += randomOffset;

            lineRenderer.SetPosition(i, point);
        }
    }

    void HideLine()
    {
        lineRenderer.enabled = false;
    }
}
