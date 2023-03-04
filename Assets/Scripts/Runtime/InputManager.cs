using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool leftKey = false;
    public static bool rightKey = false;
    public static bool jumpKey = false;
    public static bool noKey = true;
    public static bool noLeftRightKey = true;
    void Update()
    {
        leftKey = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        rightKey = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        jumpKey = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        noKey = !(leftKey || rightKey || jumpKey);
        noLeftRightKey = !(leftKey || rightKey);
    }
}
