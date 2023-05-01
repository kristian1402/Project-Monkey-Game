// Importing necessary libraries
using UnityEngine.SceneManagement;
using UnityEngine;

// Defining the SceneLoader class
public class SceneLoader : MonoBehaviour
{
    // Serialized field for the fader gameobject
    [SerializeField] RectTransform fader = null;

    // Serialized field for the duration of the transition effect
    [SerializeField] float transitionTime = 0.75f;

    // This method is called when the object this script is attached to is created
    private void Start(){

        // Getting the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;

        // If the current scene is the MainMenu, show the fader and apply the fade-in and fade-out transition effect
        if (currentSceneName == "MainMenu") {
            fader.gameObject.SetActive(true);
            LeanTween.alpha (fader, 1, transitionTime); // Fade-in effect
            LeanTween.alpha (fader, 0, transitionTime).setOnComplete(() => { // Fade-out effect
                fader.gameObject.SetActive(false); // Deactivate the fader after the transition effect is complete
            });
        }
        // If it is any other scene, show the fader and apply the transition effect before loading the new scene
        else {
            fader.gameObject.SetActive(true);
            //LeanTween.alpha (fader, 0, transitionTime * 2); // Fade-out effect
            //LeanTween.alpha (fader, 1, transitionTime); // Fade-in effect
            LeanTween.scale (fader, new Vector3(1,1,1), transitionTime); // Scale-in effect
            LeanTween.scale (fader, new Vector3(0,0,0), transitionTime).setEase (LeanTweenType.easeInOutExpo).setOnComplete(() => { // Scale-out effect
                fader.gameObject.SetActive(false); // Deactivate the fader after the transition effect is complete
            });
        }
    }

    // This method is called when a scene needs to be loaded
    public void LoadScene(string sceneName) {
        fader.gameObject.SetActive(true);
        LeanTween.alpha (fader, 0, transitionTime * 2); // Fade-out effect
        LeanTween.alpha (fader, 1, transitionTime); // Fade-in effect
        LeanTween.scale (fader, new Vector3(0,0,0), 0f); // Scale-out effect (instantly)
        LeanTween.scale (fader, new Vector3(1,1,1), transitionTime).setEase (LeanTweenType.easeInOutQuad).setOnComplete(() => { // Scale-in effect
            SceneManager.LoadScene(sceneName); // Load the new scene after the transition effect is complete
        });
    }
}