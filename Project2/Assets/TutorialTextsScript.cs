using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextsScript : MonoBehaviour
{
    public Text instructions;
    private float timeInterval = 3.0f;

    private float time;
    private float timeLeft;
    private float showControlsTime = 2.5f;

    private bool teach2Shoot;
    private bool teach2Jump;
    private bool showControls;
    private bool teach2Look;
    private bool goToNext;

    private const string showControlsInstruction = "Use W-A-S-D keyboard keys to move forwards-left-backwards-right";
    private const string useMouseInstruction = "Move mouse to look around";
    private const string shootInstruction = "Use left/right mouse click to shoot enemies!";
    private const string jumpInstruction = "Press space to jump";

    private bool ATouched = false;
    private bool WTouched = false;
    private bool STouched = false;
    private bool DTouched = false;

    private Vector3 initialMousePos;


    // Use this for initialization
    void Start()
    {
        instructions.text = showControlsInstruction;
        time = Time.time;
        timeLeft = 0;
        showControls = true;
        teach2Jump = false;
        teach2Shoot = false;
        teach2Look = false;
        goToNext = true;
        initialMousePos = Input.mousePosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                instructions.text = "";
            }

        }
        

        if (Input.GetKey(KeyCode.D))
        {
            DTouched = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            ATouched = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            STouched = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            WTouched = true;
        }
        if (WTouched && ATouched && STouched && DTouched && showControls)
        {
            TeachJump();
        }
        if (Input.GetKey(KeyCode.Space) && teach2Jump)
        {
            print("teaching to look");
            teachLook();
        }

        Vector3 mouseDelta = Input.mousePosition - initialMousePos;
        initialMousePos = Input.mousePosition;
        if (teach2Look && (mouseDelta.x < -15 || mouseDelta.x > 15)  && (mouseDelta.y < -15 || mouseDelta.y > 15))
        {
            teachShoot();
        }
        if (teach2Shoot && Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            instructions.text = "finished the tutorial! Now go and find the STAR GOAL";
            timeLeft = timeInterval;
        }


    }

  


    public void TeachJump()
    {
        print("teaching jump");
        showControls = false;
        teach2Jump = true;
        instructions.text = jumpInstruction;
    }
    public void teachLook()
    {
        teach2Jump = false;
        teach2Look = true;
        instructions.text = useMouseInstruction;
    }
    public void teachShoot()
    {
        teach2Look = false;
        teach2Shoot = true;
        instructions.text = shootInstruction;
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class TutorialTextsScript : MonoBehaviour {
//    public Text instructions;
//    private float timeInterval = 6.0f;

//    private float time;
//    private float timeLeft;
//    private float showControlsTime = 1.0f;

//    private bool teach2Shoot;
//    private bool teach2Jump;
//    private bool showControls;
//    private bool teach2Look;
//    private bool goToNext;

//    private const string showControlsInstruction = "Use W-A-S-D keyboard keys to move forwards-left-backwards-right";
//    private const string useMouseInstruction = "Move mouse to look around";
//    private const string shootInstruction = "Use left/right mouse click to shoot enemies!";
//    private const string jumpInstruction = "Press space to jump";


//    // Use this for initialization
//    void Start () {
//        instructions.text = "";
//        time = Time.time;
//        timeLeft = 0;
//        showControls = true;
//        teach2Jump = false;
//        teach2Shoot = false;
//        teach2Look = false;
//        goToNext = true;
//	}
	
//	// Update is called once per frame
//	void Update () {
//        if (timeLeft > 0)
//        {
//            timeLeft -= Time.deltaTime;

//        }
//        if(timeLeft < 0)
//        {
//            timeLeft = 0;
//            instructions.text = "";
//            goToNext = true;
//        }

//        if (Time.time > showControlsTime & showControls)
//        {
//            timeLeft = timeInterval;
//            instructions.text = showControlsInstruction;
//        }
//        if (goToNext && teach2Jump)
//        {
//            timeLeft = timeInterval;
//            instructions.text = jumpInstruction;
//        }
//        if (goToNext && teach2Look)
//        {
//            timeLeft = timeInterval;
//            instructions.text = useMouseInstruction;
//        }
//        if (goToNext && teach2Shoot)
//        {
//            timeLeft = timeInterval + 2.0f;
//            instructions.text = shootInstruction;
//        }

//        if (goToNext)
//        {
//            if (showControls)
//            {
//                showControls = false;
//                teach2Jump = true;
//            }
//            else if (teach2Jump)
//            {
//                teach2Jump = false;
//                teach2Look = true;
//            }
//            else if (teach2Look)
//            {
//                teach2Look = false;
//                teach2Shoot = true;
//            }
//            else if (teach2Shoot)
//            {
//                teach2Shoot = false;
//            }
//            goToNext = false;
//        }


//    }

//    public IEnumerator FadeTextToFullAlpha(float t, Text i)
//    {
//        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
//        while (i.color.a < 1.0f)
//        {
//            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
//            yield return null;
//        }
//    }

//    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
//    {
//        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
//        while (i.color.a > 0.0f)
//        {
//            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
//            yield return null;
//        }
//    }
//}
