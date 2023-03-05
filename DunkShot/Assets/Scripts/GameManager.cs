using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("LEVEL SETTINGS")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pot;
    [SerializeField] private GameObject PotGrowth;
    [SerializeField] private GameObject[] FeaturePoint;
    [SerializeField] private AudioSource[] Sounds;
    [SerializeField] private ParticleSystem[] Effects;

    [Header("UI SETTINGS")]
    [SerializeField] private Image[] TaskImage;
    [SerializeField] private Sprite TaskSprite;
    [SerializeField] private int TargtBall;
    [SerializeField] private GameObject[] Panels;
    [SerializeField] private TextMeshProUGUI LevelName;


    int ThrownBasket;
    void Start()
    {
        BasketImage();
    }


    void Update()
    {
        MotionControl();
    }
    public void Basket(Vector3 Poz)
    {
        ThrownBasket++;
        TaskImage[ThrownBasket - 1].sprite = TaskSprite;
        Effects[0].transform.position = Poz;
        Effects[0].gameObject.SetActive(true);
        Sounds[1].Play();

        if (ThrownBasket == TargtBall)
        {
            Debug.Log("Kzandýn");
            Win();
        }
        if (ThrownBasket == 1)
        {
            FetchFeature();
        }
    }
    public void Lost()
    {
        Sounds[2].Play();
        Panels[2].SetActive(true);
        Time.timeScale = 0;
    }
    void Win()
    {
        Sounds[3].Play();
        Panels[1].SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Time.timeScale = 0;
    }
    public void CapEnlargement(Vector3 Poz)
    {
        Effects[1].transform.position = Poz;
        Effects[1].gameObject.SetActive(true);
        Sounds[0].Play();
        Pot.transform.localScale = new Vector3(55f, 55f, 55f);
    }
    void FetchFeature()
    {
        int RandomNumber = Random.Range(0, FeaturePoint.Length - 1);
        PotGrowth.transform.position = FeaturePoint[RandomNumber].transform.position;
        PotGrowth.SetActive(true);
    }
    public void ButtonsOperation(string Value)
    {
        switch (Value)
        {
            case "Stop":
                Time.timeScale = 0;
                Panels[0].SetActive(true);
                break;
            case "Resume":
                Time.timeScale = 1;
                Panels[0].SetActive(false);
                break;
            case "Again":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case "Next":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                break;
            case "Settings":
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }
    void MotionControl()
    {

        if (Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Platform.transform.position.x > -1.5)
                {
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - .3f, Platform.transform.position.y, Platform.transform.position.z), .080f);

                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Platform.transform.position.x < 1.5)
                {
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + .3f, Platform.transform.position.y, Platform.transform.position.z), .080f);
                }

            }
        }
    }
    void BasketImage()
    {
        LevelName.text = "LEVEL : " + SceneManager.GetActiveScene().name;
        for (int i = 0; i < TargtBall; i++)
        {
            TaskImage[i].gameObject.SetActive(true);
        }
    }
}
