using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIMainMenu : MonoBehaviour
{
    [Header("Panel References")]
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelOptions;
    [SerializeField] private GameObject panelCredits;

    [Header("Main Menu References")]
    [SerializeField] private Button btnPlayMM;
    [SerializeField] private Button btnOptionsMM;
    [SerializeField] private Button btnCreditsMM;
    [SerializeField] private Button btnExitMM;
    [SerializeField] private Button btnCreditsBackMM;
    [SerializeField] private Button btnOptionsBackMM;

    [Header("Pause Menu References")]
    [SerializeField] private Button btnResumePM;
    [SerializeField] private Button btnOptionsPM;
    [SerializeField] private Button btnExitPM;
    [SerializeField] private Button btnOptionsBackPM;

    [Header("Settings References")]
    [SerializeField] private PlayerMovement playerMovementPlayerOne;
    [SerializeField] private PlayerMovement playerMovementPlayerTwo;
    [SerializeField] private Slider sliderPlayerOne;
    [SerializeField] private Slider sliderPlayerTwo;

    [SerializeField] private TMP_Text textPlayerOneValue;
    [SerializeField] private TMP_Text textPlayerTwoValue;

    bool isPaused = true;
    private void Awake()
    {
        // Main Menu Buttons
        btnPlayMM.onClick.AddListener(OnPlayClicked);
        btnOptionsMM.onClick.AddListener(OnOptionsMainMenuClicked);
        btnCreditsMM.onClick.AddListener(OnCreditsMainMenuClicked);
        btnExitMM.onClick.AddListener(OnExitClicked);

        btnCreditsBackMM.onClick.AddListener(OnCreditsBackMainMenuClicked);
        btnOptionsBackMM.onClick.AddListener(OnOptionsBackMainMenuClicked);

        // Pause Menu Buttons
        btnResumePM.onClick.AddListener(OnPlayClicked);
        btnOptionsPM.onClick.AddListener(OnOptionsPauseClicked);
        btnExitPM.onClick.AddListener(OnExitClicked);

        btnOptionsBackPM.onClick.AddListener(OnOptionsBackPauseClicked);

        sliderPlayerOne.onValueChanged.AddListener(ChangeVelocityPlayerOne);
        sliderPlayerTwo.onValueChanged.AddListener(ChangeVelocityPlayerTwo);

    }

    private void ChangeVelocityPlayerOne(float newValue)
    {
        playerMovementPlayerOne.velocity = newValue;
        textPlayerOneValue.text = newValue.ToString("F1");
    }
    private void ChangeVelocityPlayerTwo(float newValue)
    {
        playerMovementPlayerTwo.velocity = newValue;
        textPlayerTwoValue.text = newValue.ToString("F1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            panelPause.SetActive(isPaused);
        }
    }
    private void OnDestroy()
    {
        // Main Menu
        btnPlayMM.onClick.RemoveAllListeners();
        btnOptionsMM.onClick.RemoveAllListeners();
        btnCreditsMM.onClick.RemoveAllListeners();
        btnExitMM.onClick.RemoveAllListeners();
        btnCreditsBackMM.onClick.RemoveAllListeners();
        btnOptionsBackMM.onClick.RemoveAllListeners();

        // Pause Menu
        btnResumePM.onClick.RemoveAllListeners();
        btnOptionsPM.onClick.RemoveAllListeners();
        btnExitPM.onClick.RemoveAllListeners();
        btnOptionsBackPM.onClick.RemoveAllListeners();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }


    private void OnPlayClicked()
    {
        TogglePause();
        panelMainMenu.SetActive(false);
        panelPause.SetActive(false);
    }
    private void OnOptionsMainMenuClicked()
    {
        panelOptions.SetActive(true);
        panelMainMenu.SetActive(false);
        panelPause.SetActive(false);
    }
    private void OnCreditsMainMenuClicked()
    {
        panelCredits.SetActive(true);
        panelMainMenu.SetActive(false);

    }

    private void OnOptionsPauseClicked()
    {
        panelOptions.SetActive(true);
        btnOptionsBackPM.gameObject.SetActive(true);
        panelPause.SetActive(false);
    }

    private void OnCreditsBackMainMenuClicked()
    {
        panelCredits.SetActive(false);
        panelMainMenu.SetActive(true);
    }
    private void OnOptionsBackPauseClicked()
    {
        panelOptions.SetActive(false);
        panelPause.SetActive(true);
        btnOptionsBackPM.gameObject.SetActive(false);
    }

    private void OnOptionsBackMainMenuClicked()
    {
        panelOptions.SetActive(false);
        panelMainMenu.SetActive(true);
        panelPause.SetActive(false);
    }
    private void OnExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
