using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal: Collidable {
    public string[] sceneNames;

    protected override void OnCollide(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            // Teleport the player
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
