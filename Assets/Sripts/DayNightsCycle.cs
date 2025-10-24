// DayNightCycle.cs
using UnityEngine;
using System.Collections.Generic;

public class DayNightCycle : MonoBehaviour
{
    [Header("Sun Settings")]
    public Light sun; // Ссылка на Directional Light
    public float secondsInFullDay = 120f; // Длина полного дня в секундах
    [Range(0, 1)]
    public float currentTimeOfDay = 0.3f; // 0.75 = ночь, 0.3 = полдень
    
    [Header("Night Settings")]
    public float nightStartThreshold = 0.75f; // Время суток, когда начинается ночь (например, 0.2)
    public float nightEndThreshold = 0.3f;   // Время суток, когда ночь заканчивается

    private List<LanternController> allLanterns = new List<LanternController>();
    private bool isNight = false;

    void Start()
    {
        // НОВЫЙ СПОСОБ: Находим ВСЕ фонари на сцене
        LanternController[] lanternsArray = FindObjectsByType<LanternController>(FindObjectsSortMode.None);
        allLanterns.AddRange(lanternsArray);
        
        // Изначально выключаем все фонари (если сейчас день)
        UpdateLanterns(false);
        
        Debug.Log($"Найдено фонарей: {allLanterns.Count}");
    }

    // DayNightCycle.cs
void Update()
{
    // Обновляем время
    currentTimeOfDay += Time.deltaTime / secondsInFullDay;
    
    // Явно сбрасываем время, когда достигаем 1.0
    if (currentTimeOfDay >= 1.0f)
    {
        currentTimeOfDay = 0.0f;
        // Можно также добавить событие на смену суток, если нужно
        Debug.Log("Наступили новые сутки!");
    }
    // Вращаем солнце
    sun.transform.rotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

    // БОЛЕЕ ПОНЯТНАЯ логика:
    // Если мы в диапазоне "ночи" (от начала ночи до конца ночи через "полночь")
    bool shouldBeNight = false;
    
    if (nightStartThreshold < nightEndThreshold)
    {
        // Обычный случай: ночь не пересекает полночь
        shouldBeNight = currentTimeOfDay >= nightStartThreshold && currentTimeOfDay <= nightEndThreshold;
    }
    else
    {
        // Ночь пересекает полночь (например: 0.8 до 0.2)
        shouldBeNight = currentTimeOfDay >= nightStartThreshold || currentTimeOfDay <= nightEndThreshold;
    }

    // Если состояние "ночи" изменилось, переключаем фонари
    if (shouldBeNight != isNight)
    {
        isNight = shouldBeNight;
        UpdateLanterns(isNight);
        
        Debug.Log($"Время: {currentTimeOfDay:F2}, Ночь: {isNight}");
    }
}

    // DayNightCycle.cs - добавьте в метод UpdateLanterns
    void UpdateLanterns(bool turnOn)
    {
        Debug.Log($"Вызов UpdateLanterns({turnOn}), всего фонарей: {allLanterns.Count}");
        
        // Проходим по всем фонарям и включаем/выключаем их
        foreach (LanternController lantern in allLanterns)
        {
            if (lantern != null)
            {
                Debug.Log($"Переключаем фонарь {lantern.gameObject.name} на {turnOn}");
                lantern.ToggleLight(turnOn);
            }
        }
        
        Debug.Log(turnOn ? "Наступила ночь! Фонари включены." : "Наступил день! Фонари выключены.");
    }
}