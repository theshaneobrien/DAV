using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DebugValveControllers : MonoBehaviour
{
    public ActionBasedController leftHand;
    
    // Start is called before the first frame update
    void Start()
    {
        leftHand.selectAction.action.performed += SelectActionPerformed;
        leftHand.selectAction.action.canceled += SelectActionCancelled;
    }

    private void SelectActionPerformed(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("You have performed the select action");
        
        Debug.Log("The value of the callback was: " + callbackContext.ReadValue<float>());
    }
    
    private void SelectActionCancelled(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("You have cancelled the select action");
        
        Debug.Log("The value of the callback was: " + callbackContext.ReadValue<float>());
    }
}