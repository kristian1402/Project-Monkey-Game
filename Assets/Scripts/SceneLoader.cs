using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    // Start is called before the first frame update

    private void Start(){
        fader.gameObject.SetActive(true);

        LeanTween.scale (fader, new Vector3(1,1,1), 0);
        LeanTween.scale (fader, new Vector3(0,0,0), 0.5f).setOnComplete(() => {
            fader.gameObject.SetActive(false);
        });
    }
    public void LoadScene(string sceneName) {
        fader.gameObject.SetActive(true);
        LeanTween.scale (fader, new Vector3(0,0,0), 0);
        LeanTween.scale (fader, new Vector3(1,1,1), 0.5f).setOnComplete(() => {
            SceneManager.LoadScene(sceneName);
        });
    }
}
