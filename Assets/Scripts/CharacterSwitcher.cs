using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcherp : MonoBehaviour
{
    [Header("Animator Assignments")]
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;
    public Avatar avatar1;
    public Avatar avatar2;

    [Header("Character Models")]
    public GameObject characterModel1;
    public GameObject characterModel2;

    [Header("Character Models")]
    public GameObject Platform1;
    public GameObject Platform2;
    
    [Header("Input Binding")]
    public PlayerInput playerInput; // Bu PlayerInput'a sen inspector'dan bağlı olanı atacaksın
    public string switchActionName = "SwitchCharacter"; // Action asset'teki isim

    private InputAction switchAction;
    private Animator animator;
    private bool usingFirstSet = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Eğer PlayerInput atanmışsa, action'ı buradan bul
        if (playerInput != null)
        {
            switchAction = playerInput.actions[switchActionName];
        }

        if (switchAction != null)
        {
            switchAction.performed += OnSwitchCharacter;
            switchAction.Enable(); // Gerekli olabilir
        }
        else
        {
            Debug.LogError("SwitchCharacter InputAction bulunamadı. İsim doğru mu?");
        }
    }

    private void OnDestroy()
    {
        if (switchAction != null)
        {
            switchAction.performed -= OnSwitchCharacter;
        }
    }

    private void Start()
    {
        ApplyCurrentSet();
    }

    private void OnSwitchCharacter(InputAction.CallbackContext context)
    {
        usingFirstSet = !usingFirstSet;
        ApplyCurrentSet();
    }

    private void ApplyCurrentSet()
    {
        if (usingFirstSet)
        {
            animator.runtimeAnimatorController = controller1;
            animator.avatar = avatar1;

            characterModel1.SetActive(true);
            characterModel2.SetActive(false);
            
            Platform1.SetActive(true);
            Platform2.SetActive(false);
            
        }
        else
        {
            animator.runtimeAnimatorController = controller2;
            animator.avatar = avatar2;

            characterModel1.SetActive(false);
            characterModel2.SetActive(true);
            
            Platform1.SetActive(false);
            Platform2.SetActive(true);
        }
    }
}
