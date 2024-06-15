using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Döndürme hýzýný kontrol eden bir katsayý
    public float rotationSpeed = 60.0f;

    // Baþlangýç rotasyonunu depolamak için deðiþken
    [SerializeField] Quaternion initialRotation;

    void Start()
    {
        // Baþlangýç rotasyonunu 180 derece y ekseninde ayarla
        initialRotation = Quaternion.Euler(0, 210, 0);
        transform.rotation = initialRotation;
    }

    void Update()
    {
        // Mouse imlecinin x konumunu al
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        // Mouse x konumunu -1 ile 1 arasýna normalleþtir (Opsiyonel)
        float normalizedMouseX = (mouseX / Screen.width) * 2 - 1;

        float normalizedMouseY = (mouseY / Screen.height) * 2 - 1;

        // Y ekseninde döndürme açýsýný hesapla
        float rotationY = normalizedMouseX * rotationSpeed;
        float rotationX = normalizedMouseY * rotationSpeed;

        // Yeni rotasyonu hesapla ve baþlangýç rotasyonuna ekle
        Quaternion newRotation = initialRotation * Quaternion.Euler(-rotationX, -rotationY, 0);

        // GameObject'i y ekseninde döndür
        transform.rotation = newRotation;
    }
}
