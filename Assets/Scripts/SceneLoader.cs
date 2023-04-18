using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] RectTransform fader;

    private void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;

        if (currentSceneName == "MainMenu") {
            fader.gameObject.SetActive(true);
            LeanTween.alpha (fader, 1, 0f);
            LeanTween.alpha (fader, 0, 1f).setOnComplete(() => {
                LeanTween.scale (fader, new Vector3(0,0,0), 0);
                fader.gameObject.SetActive(false);
            });
        }
        else {
            fader.gameObject.SetActive(true);
            LeanTween.scale (fader, new Vector3(1,1,1), 0);
            LeanTween.scale (fader, new Vector3(0,0,0), 0.5f).setEase (LeanTweenType.easeInOutExpo).setOnComplete(() => {
                fader.gameObject.SetActive(false);
            });
        }
    }
    public void LoadScene(string sceneName) {
        fader.gameObject.SetActive(true);
        LeanTween.scale (fader, new Vector3(0,0,0), 0);
        LeanTween.scale (fader, new Vector3(1,1,1), 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete(() => {
            SceneManager.LoadScene(sceneName);
        });
    }
}
