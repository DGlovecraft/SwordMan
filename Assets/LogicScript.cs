using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // สำหรับโหลดซีนใหม่

public class LogicScript : MonoBehaviour
{
    public Text hpText;
    public GameObject gameOverUI; // ลาก GameOver UI มาตั้งค่าใน Inspector

    public void UpdatePlayerHP(float hp)
    {
        hpText.text = "HP: " + math.round(hp).ToString();
    }

    // เรียกเมื่อ Player ตาย
    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
    }

    // ฟังก์ชันกดปุ่ม Play Again
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}

