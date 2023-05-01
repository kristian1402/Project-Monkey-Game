using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStoreSwitcher : MonoBehaviour
{
    public GameObject upgradeCanvas;
    public GameObject powerUpCanvas;
    public GameObject skinCanvas;

    void Start() {
        DeactivateCanvas(powerUpCanvas);
        DeactivateCanvas(skinCanvas);
    }

    void ActivateCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    void DeactivateCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    public void SwitchToUpgradeCanvas()
    {
        DeactivateCanvas(powerUpCanvas);
        DeactivateCanvas(skinCanvas);
        ActivateCanvas(upgradeCanvas);
    }

    public void SwitchToPowerUpCanvas()
    {
        DeactivateCanvas(upgradeCanvas);
        DeactivateCanvas(skinCanvas);
        ActivateCanvas(powerUpCanvas);
    }

    public void SwitchToSkinCanvas()
    {
        DeactivateCanvas(upgradeCanvas);
        DeactivateCanvas(powerUpCanvas);
        ActivateCanvas(skinCanvas);
    }
}