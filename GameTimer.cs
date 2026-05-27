using UnityEngine;
using TMPro; // Wajib dipanggil untuk pakai UI TextMeshPro

public class GameTimer : MonoBehaviour
{
    [Header("Pengaturan Waktu")]
    public float timeRemaining = 60f; // Waktu dalam detik (60f = 1 menit)
    public bool timerIsRunning = false;

    [Header("Referensi UI")]
    public TextMeshProUGUI timeText; // Slot untuk naruh Teks UI kamu

    void Start()
    {
        // Jalankan timer otomatis saat game dimulai
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Kurangi waktu secara *real-time* setiap *frame*
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                // Waktu menyentuh angka 0
                Debug.Log("<color=red>WAKTU HABIS! GAME OVER!</color>");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        // Hitung pembagian menit dan detik
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Ubah teks UI jadi format 00:00
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        // Nanti kamu bisa tambahkan kode di sini untuk me-restart scene 
        // atau memunculkan panel tulisan "KAMU KALAH".
        // Untuk sekarang, kita matikan saja pergerakan playernya:
        Time.timeScale = 0f; // Menghentikan seluruh pergerakan dan waktu di game (Pause)
    }
} 