using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Text : MonoBehaviour
{
    public Button b1;
    public TextMeshProUGUI b1text;

    // Start is called before the first frame update
    void Start()
    {
        b1= GetComponent<Button>();
        b1.onClick.AddListener(changeScene);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void changeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

   
}
