using TMPro;
using UnityEngine;
using UnityEngine.UI; // Thêm nếu bạn sử dụng Text UI

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;
    public DamgeReceiver damgeReceiver;
    public PlayerStatus playerStatus;

    private int goldCount = 0; // Số vàng đã nhặt
    public TextMeshProUGUI goldText; // Tham chiếu đến Text UI để hiển thị số vàng )

    private void Awake()
    {
        PlayerCtrl.instance = this;
        this.damgeReceiver = GetComponent<DamgeReceiver>();
        this.playerStatus = GetComponent<PlayerStatus>();
    }

    // Hàm để tăng số vàng khi người chơi nhặt vàng
    public void AddGold(int amount)
    {
        goldCount += amount; // Cộng thêm số vàng
        UpdateGoldUI(); // Cập nhật UI nếu có
    }

    // Cập nhật UI để hiển thị số vàng
    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + goldCount; // Cập nhật văn bản để hiển thị số vàng
        }
    }
}
