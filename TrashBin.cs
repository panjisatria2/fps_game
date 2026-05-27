using UnityEngine;
using TMPro; // Wajib dipanggil untuk mengontrol UI TextMeshPro

public class TrashBin : MonoBehaviour
{
    [Header("Score Settings")]
    public int currentScore = 0;
    public int targetScore = 5; // Jumlah target sampah untuk level ini

    [Header("Referensi UI")]
    public TextMeshProUGUI scoreText; // Slot untuk teks skor di Canvas

    private void Start()
    {
        // Tampilkan skor awal di layar saat game pertama kali di-play
        UpdateScoreUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang masuk ke tong sampah punya tag "pickup"
        if (other.CompareTag("pickup"))
        {
            currentScore++; // Tambah poin skor
            Debug.Log("✅ Sampah masuk! Skor: " + currentScore);

            UpdateScoreUI(); // Update angka di layar UI

            Destroy(other.gameObject); // Hancurkan objek sampahnya

            // Cek apakah jumlah sampah sudah memenuhi target kemenangan
            if (currentScore >= targetScore)
            {
                LevelComplete();
            }
        }
    }

    private void UpdateScoreUI()
    {
        // Memastikan slot scoreText sudah diisi di Inspector agar tidak error
        if (scoreText != null)
        {
            // Format teks yang akan muncul di layar (Contoh: "Sampah: 1 / 5")
            scoreText.text = "Sampah: " + currentScore + " / " + targetScore;
        }
    }

    private void LevelComplete()
    {
        Debug.Log("<color=yellow>🎉 SELAMAT! Area sudah bersih!</color>");
        
        if (scoreText != null)
        {
            scoreText.text = "Target Selesai!"; // Ganti teks kalau sudah menang
        }
        
        // Catatan: Nanti kamu bisa tambahkan kode di sini untuk membuka pintu gerbang, 
        // memunculkan UI "You Win", atau pindah ke Scene Level 2.
    }
}