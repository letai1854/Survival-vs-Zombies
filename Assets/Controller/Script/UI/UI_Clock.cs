using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Clock : MonoBehaviour
{
    public float countdownTime = 150f; // Thời gian đếm ngược (giây), ví dụ 150 giây cho 2 phút 30 giây
    private float currentTime;
    public TextMeshProUGUI countdownText; // TextMeshPro Text để hiển thị thời gian
    public float points;

    private void Awake()
    {
        points = countdownTime;
    }
    void Start()
    {
        currentTime = countdownTime; // Đặt thời gian hiện tại bằng thời gian đếm ngược

        UpdateCountdownText(); // Cập nhật văn bản hiển thị
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Giảm thời gian hiện tại theo thời gian đã trôi qua kể từ khung hình trước
            UpdateCountdownText(); // Cập nhật văn bản hiển thị

            if (currentTime <= 0)
            {
                currentTime = 0;
               
            }
            if (ManagerSkill.instance.exit.winLose)
            {
                return;
            }
            points = currentTime;
        }
  
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); // Tính số phút
        int seconds = Mathf.FloorToInt(currentTime % 60); // Tính số giây còn lại
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Cập nhật văn bản hiển thị theo định dạng mm:ss
    }


}
