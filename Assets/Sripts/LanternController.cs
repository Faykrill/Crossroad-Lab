// LanternController.cs
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public Light lanternLight; // Ссылка на компонент Light самого фонаря
    public GameObject lightBulb; // Опционально: модель горящей лампочки

    public void ToggleLight(bool isOn)
    {
        // Включаем/выключаем источник света
        lanternLight.enabled = isOn;
        
        // Включаем/выключаем визуал лампочки (если есть)
        if (lightBulb != null)
            lightBulb.SetActive(isOn);
        
        Debug.Log($"ToggleLight вызван для {gameObject.name}: {isOn}");
        
        if (lanternLight != null)
        {
            Debug.Log($"Состояние света ДО: {lanternLight.enabled}");
            lanternLight.enabled = isOn;
            Debug.Log($"Состояние света ПОСЛЕ: {lanternLight.enabled}");
        }
        else
        {
            Debug.LogError($"LanternLight не назначен для {gameObject.name}!");
        }
        
        if (lightBulb != null)
        lightBulb.SetActive(isOn);
    }
}

