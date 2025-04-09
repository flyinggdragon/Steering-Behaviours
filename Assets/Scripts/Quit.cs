using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {
    public void QuitClick() {
        SceneManager.LoadScene("Main Menu");
    }
}