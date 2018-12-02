using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
	void Start () {
		transform.Find("Play").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Room1"));
		transform.Find("Main menu").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Menu"));
	}	
}
