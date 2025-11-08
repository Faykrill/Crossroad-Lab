using UnityEngine;

public class MoveScript : MonoBehaviour
{

    [SerializeField] private float speed = 5f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime; 
    }
}
