using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed = 5f;
    public float stopDistance = 10f; // Дистанция для остановки
    public Light lightComponent; // Ссылка на светофор

    void Start()
    {
            
    }

    void Update()
    {
         // Проверяем светофор
        if (lightComponent != null)
        {
            if (lightComponent.GetComponent<Light>().color != Color.green && 
                IsCloseToTrafficLight())
            {
                // Стоим на месте
                return;
            }
        }
        Vector3 movement = transform.right * speed * Time.deltaTime;
        transform.position += movement;
    }
    bool IsCloseToTrafficLight()
    {
        float distance = Vector3.Distance(transform.position, lightComponent.transform.position);
        return distance <= stopDistance;
    }
}
