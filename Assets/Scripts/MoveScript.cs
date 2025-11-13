using UnityEngine;
using Lane;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private DirectionLane currentLane;
    private float lookAheadDistance = 0f;
    public LayerMask laneLayerMask = 1;
    Vector3 direction = Vector3.forward;

    void Update()
    {
        FindLaneAhead();
        MoveWithDirection();
    }
    void FindLaneAhead()
    {
        Vector3 lookAheadPos = transform.position + transform.forward * lookAheadDistance;

        Collider[] hitColliders = Physics.OverlapSphere(lookAheadPos, 0.8f, laneLayerMask);
        foreach (var collider in hitColliders)
        {
            DirectionLane lane = collider.GetComponent<DirectionLane>();
            if (lane != null)
            {
                if ((Mathf.Abs(gameObject.transform.position.x - lane.transform.position.x) < 0.5f) ||
                    (Mathf.Abs(gameObject.transform.position.z - lane.transform.position.z) < 0.5f) 
                    && (currentLane != lane))
                {
                    direction = lane.GetWorldDirection();
                    currentLane = lane;
                }
                Debug.Log($"Найдена полоса: {lane.gameObject.name}, направление: {direction}");
                return;
            }
        }
        Debug.Log("Полоса не найдена, продолжаем движение вперед");
    }
    void MoveWithDirection()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    void OnDrawGizmosSelected()
    {
        // Визуализация области поиска впереди
        Gizmos.color = Color.magenta;
        Vector3 lookAheadPos = transform.position + transform.forward * lookAheadDistance;
        Gizmos.DrawWireSphere(lookAheadPos, 0.8f);
        Gizmos.DrawLine(transform.position, lookAheadPos);
    }
}
