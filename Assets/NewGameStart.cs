using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class NewGameStart : MonoBehaviour {

    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClickedButton);
    }

    // Update is called once per frame
    void OnClickedButton()
    {
        Application.LoadLevel("Start");
    }
}
