using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public void ArrivalDeparture() {
        SceneManager.LoadScene("ArrivalDeparture");
    }

    public void SeekFlee() {
        SceneManager.LoadScene("SeekFlee");
    }

    public void PursuitEvasion() {
        SceneManager.LoadScene("PursuitEvasion");
    }

    public void Wander() {
        SceneManager.LoadScene("Wander");
    }

    public void PathFollowing() {
        SceneManager.LoadScene("PathFollowing");
    }

    public void Close() {
        Application.Quit();
    }
}