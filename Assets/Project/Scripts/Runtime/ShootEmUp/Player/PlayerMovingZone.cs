using UnityEngine;

namespace TaoPulse.ShootEmUp.Player
{
    public sealed class PlayerMovingZone : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Color borderColor = Color.white;

        [Header("Limit")] 
        [SerializeField, Min(0)] private float sizeX = 25f;
        [SerializeField, Min(0)] private float sizeY = 13.5f;

        private LineRenderer lineRenderer;

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 5;
            lineRenderer.loop = true;
            lineRenderer.useWorldSpace = true;
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;

            lineRenderer.startColor = borderColor;
            lineRenderer.endColor = borderColor;

            UpdateVisualBounds();
        }

        private void Update()
        {
            Vector3 position = playerTransform.position;
            position.x = Mathf.Clamp(position.x, -sizeX, sizeX);
            position.y = Mathf.Clamp(position.y, -sizeY, sizeY);
            playerTransform.position = position;
        }

        private void UpdateVisualBounds()
        {
            Vector3[] corners = new Vector3[5];
            corners[0] = new Vector3(-sizeX, -sizeY, 0);
            corners[1] = new Vector3(-sizeX, sizeY, 0);
            corners[2] = new Vector3(sizeX, sizeY, 0);
            corners[3] = new Vector3(sizeX, -sizeY, 0);
            corners[4] = corners[0];

            lineRenderer.SetPositions(corners);
        }

        private void OnValidate()
        {
            if (!lineRenderer) return;
            lineRenderer.startColor = borderColor;
            lineRenderer.endColor = borderColor;
            UpdateVisualBounds();
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = borderColor;
            Gizmos.DrawWireCube(
                new Vector3((-sizeX + sizeX) / 2, (-sizeY + sizeY) / 2, 0),
                new Vector3(sizeX - -sizeX, sizeY - -sizeY, 0)
            );
        }

        public void SetBorderSize(float x, float y)
        {
            sizeX = Mathf.Min(x, 0);
            sizeY = Mathf.Min(y, 0);
        }

        public void SetBorderColor(Color color)
        {
            borderColor = color;
        }
    }
}