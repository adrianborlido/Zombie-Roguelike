using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

    public static GameManager instance;
    private void Awake() {
        if(instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<Sprite> itemPrices;

    // References
    public Player player;
    public FloatingTextManager floatingTextManager;
    // public Weapon weapon etc.

    public int money;

    // Floating text
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    // Save state
    /*
     * INT money
     * WEAPON weapon
     */
    public void SaveState() {
        string saving = "";
        saving += money.ToString() + "|";
        saving += "0";

        PlayerPrefs.SetString("SaveState", saving);
    }
    public void LoadState(Scene s, LoadSceneMode mode) {
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        money = int.Parse(data[1]);
    }
}
