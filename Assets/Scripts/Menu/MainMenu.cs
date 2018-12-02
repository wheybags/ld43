using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	void Start () {
		transform.Find("Play").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Room1"));
		transform.Find("Credits").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Credits"));
		transform.Find("Quit").GetComponent<Button>().onClick.AddListener(() => Application.Quit());
	}	
}
