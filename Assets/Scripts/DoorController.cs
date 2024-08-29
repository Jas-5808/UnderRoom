using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 0f; // Угол, на который дверь открывается
    public float closeAngle = 90f; // Угол, на который дверь закрывается
    public float rotationSpeed = 2f; // Скорость вращения двери
    private bool isOpen = false; // Состояние двери
    private bool isRotating = false; // Указывает, вращается ли дверь

    private Quaternion targetRotation; // Целевое вращение

    void Update()
    {
        // Проверяем, нажата ли клавиша E
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            isOpen = !isOpen; // Меняем состояние двери
            targetRotation = Quaternion.Euler(0, isOpen ? openAngle : closeAngle, 0);
            isRotating = true; // Начинаем вращение
        }

        // Плавно поворачиваем дверь к целевому углу
        if (isRotating)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Если дверь достигла целевого угла, останавливаем вращение
            if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.1f)
            {
                transform.localRotation = targetRotation; // Устанавливаем точный угол
                isRotating = false; // Останавливаем вращение
            }
        }
    }
}
