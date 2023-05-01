using UnityEngine;
using TMPro;

public class MoneyTextUpdater : MonoBehaviour
{
    public MoneyData moneyData;
    public TextMeshProUGUI moneyText;

    void Update()
    {
        int currentMoney = moneyData.getMoney();
        moneyText.text = currentMoney.ToString();
    }
}