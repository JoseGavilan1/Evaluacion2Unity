using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Carga la escena del juego (asegúrate de agregarla en la configuración de Build)
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        // Salir del juego (no funcionará en el editor)
        Application.Quit();
        // Para pruebas en el editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
