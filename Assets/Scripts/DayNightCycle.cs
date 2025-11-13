using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private GameObject _sun;
    [SerializeField] private float speedSun;
    float x_sun = 45f;
    
    void Start()
    {
        transform.rotation =  Quaternion.Euler(x_sun, 21, 0);
    }

    void Update()
    {
        x_sun += speedSun;
        transform.rotation = Quaternion.Euler(x_sun, 21, 0);
    }
}
