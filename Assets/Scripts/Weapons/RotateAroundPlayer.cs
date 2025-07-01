using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    
    public GameObject player; // Ссылка на игрока
    public float rotationRadius = 2f; // Радиус вращения
    public float rotationSpeed = 50f; // Скорость вращения (градусы в секунду)

    private float _angle; // Текущий угол вращения
    
    
    public float fadeDuration = 1f; // Длительность исчезновения/появления
    public float stayDuration = 2f; // Длительность видимости
    private Renderer objectRenderer;
    
    public float damageAmount;

    public bool shouldKnockBack;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(FadeCycle());

        
    }

    // Update is called once per frame
    void Update()
    {
        
        Rotate();
    }

    private void Rotate()
    {
        // Увеличиваем угол вращения на основе скорости вращения и времени, прошедшего с последнего кадра
        _angle += rotationSpeed * Time.deltaTime;

        // Вычисляем новую позицию объекта вокруг игрока
        Vector3 offset = new Vector3(Mathf.Sin(_angle * Mathf.Deg2Rad), 0, Mathf.Cos(_angle * Mathf.Deg2Rad)) * rotationRadius;
        transform.position = player.transform.position + offset;

        // Ориентируем объект лицом к игроку (опционально)
        transform.LookAt(player.transform);
    }
    
    IEnumerator FadeCycle()
    {
        while (true)
        {
            // Исчезновение
            objectRenderer.enabled = false;
            yield return new WaitForSeconds(fadeDuration);

            // Появление
            objectRenderer.enabled = true;
            yield return new WaitForSeconds(stayDuration);
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyV2>().TakeDamage(damageAmount, shouldKnockBack);   
            
            
        }
    }
    
    
}
