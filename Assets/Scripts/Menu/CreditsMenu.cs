using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
	void Start () {
		transform.Find("Back").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Menu"));
	}	
}
