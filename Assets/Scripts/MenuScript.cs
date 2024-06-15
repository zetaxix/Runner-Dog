using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // D�nd�rme h�z�n� kontrol eden bir katsay�
    public float rotationSpeed = 60.0f;

    // Ba�lang�� rotasyonunu depolamak i�in de�i�ken
    [SerializeField] Quaternion initialRotation;

    void Start()
    {
        // Ba�lang�� rotasyonunu 180 derece y ekseninde ayarla
        initialRotation = Quaternion.Euler(0, 210, 0);
        transform.rotation = initialRotation;
    }

    void Update()
    {
        // Mouse imlecinin x konumunu al
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        // Mouse x konumunu -1 ile 1 aras�na normalle�tir (Opsiyonel)
        float normalizedMouseX = (mouseX / Screen.width) * 2 - 1;

        float normalizedMouseY = (mouseY / Screen.height) * 2 - 1;

        // Y ekseninde d�nd�rme a��s�n� hesapla
        float rotationY = normalizedMouseX * rotationSpeed;
        float rotationX = normalizedMouseY * rotationSpeed;

        // Yeni rotasyonu hesapla ve ba�lang�� rotasyonuna ekle
        Quaternion newRotation = initialRotation * Quaternion.Euler(-rotationX, -rotationY, 0);

        // GameObject'i y ekseninde d�nd�r
        transform.rotation = newRotation;
    }
}
