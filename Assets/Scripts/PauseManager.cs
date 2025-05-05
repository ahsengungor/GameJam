using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Assign your Pause UI Panel here")]
    public GameObject pausePanel;

    [Header("Input Action Asset")]
    public InputActionAsset inputActions;

    private InputAction pauseAction;
    private bool isPaused = false;

    void Start()
    {
        // Oyun başladığında cursor kilitlenip gizlenir
        LockCursor();
    }

    void OnEnable()
    {
        if (inputActions != null)
        {
            var actionMap = inputActions.FindActionMap("UI");
            if (actionMap != null)
            {
                pauseAction = actionMap.FindAction("Pause");
                if (pauseAction != null)
                {
                    pauseAction.Enable();
                    pauseAction.performed += OnPause;
                }
                else
                {
                    Debug.LogWarning("Pause action not found in InputActionAsset.");
                }
            }
            else
            {
                Debug.LogWarning("UI action map not found in InputActionAsset.");
            }
        }
        else
        {
            Debug.LogWarning("InputActionAsset not assigned in the inspector.");
        }
    }

    void OnDisable()
    {
        if (pauseAction != null)
        {
            pauseAction.performed -= OnPause;
            pauseAction.Disable();
        }
    }

    void OnPause(InputAction.CallbackContext context)
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
        if (pausePanel != null) pausePanel.SetActive(true);
        UnlockCursor();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);
        LockCursor();
        isPaused = false;
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
