using UnityEngine;
using System.Collections;
using TouchControlsKit;

public class FPSInputControllerMobile : MonoBehaviour {

    public static FPSInputControllerMobile Instance;
    private GunHanddle gunHanddle;
	private FPSController FPSmotor;

    public int AimSpeed = 10;
	
	//public TouchScreenVal touchMove;
	//public TouchScreenVal touchAim;
	//public TouchScreenVal touchShoot;
	//public TouchScreenVal touchZoom;
	//public TouchScreenVal touchJump;
	
	//public Texture2D ImgButton;
	//public float TouchSensMult = 0.05f;

	
	void Start(){
		Application.targetFrameRate = 60;
	}
	void Awake ()
	{
		FPSmotor = GetComponent<FPSController> ();		
		gunHanddle = GetComponent<GunHanddle> (); 
	}

	void Update ()
	{
        //Player Movement Controls...
        FPSmotor.Move(new Vector3(TCKInput.GetAxis("Joystick", EAxisType.Horizontal), 0, TCKInput.GetAxis("Joystick", EAxisType.Vertical)));

        //Player Aim Controls...
        Vector2 LookDirection = TCKInput.GetAxis("Touchpad");
        FPSmotor.Aim(new Vector2(LookDirection.x * AimSpeed, LookDirection.y * AimSpeed));

        //Fire Button...
        if (TCKInput.GetAction("fireBtn", EActionEvent.Press))
        {
            gunHanddle.Shoot();
        }

        //Zoom Button...
        if (TCKInput.GetAction("SniperAim", EActionEvent.Down))
        {
            gunHanddle.Zoom();
        }

        //Player Jump Control...
        FPSmotor.Jump(TCKInput.GetAction("jumpBtn", EActionEvent.Down));

        //Vector2 aimdir = touchAim.OnDragDirection(true);
        //FPSmotor.Aim(new Vector2(aimdir.x,-aimdir.y)*TouchSensMult);
        //Vector2 touchdir = touchMove.OnTouchDirection (false);
        //FPSmotor.Move (new Vector3 (touchdir.x, 0, touchdir.y));

        //FPSmotor.Jump (Input.GetButton ("Jump"));

        //      if (touchShoot.OnTouchPress()){
        //	gunHanddle.Shoot();	
        //}
        //if(touchZoom.OnTouchRelease()){
        //	gunHanddle.ZoomToggle();
        //}
        //if (touchZoom.OnTouchRelease())
        //{
        //    FPSmotor.Jump(true);
        //}
    }


    void OnGUI(){
		
		//touchMove.Draw();
		//touchAim.Draw();
		//touchShoot.Draw();
		//touchZoom.Draw();
        //touchJump.Draw();

    }
}
