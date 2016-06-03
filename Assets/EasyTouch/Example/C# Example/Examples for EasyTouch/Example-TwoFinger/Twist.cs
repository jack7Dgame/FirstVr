using UnityEngine;
using System.Collections;

public class Twist : MonoBehaviour {

	private TextMesh textMesh;
		
	// Subscribe to events
	void OnEnable(){
		EasyTouch.On_TouchStart2Fingers += On_TouchStart2Fingers;
		EasyTouch.On_Twist += On_Twist;
		EasyTouch.On_TwistEnd += On_TwistEnd;
		EasyTouch.On_Cancel2Fingers += On_Cancel2Fingers;
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_TouchStart2Fingers -= On_TouchStart2Fingers;
		EasyTouch.On_Twist -= On_Twist;
		EasyTouch.On_TwistEnd -= On_TwistEnd;
		EasyTouch.On_Cancel2Fingers -= On_Cancel2Fingers;
	}
	
	void Start(){
		textMesh = transform.Find("TextTwist").transform.gameObject.GetComponent("TextMesh") as TextMesh;
	}
	
	// At the 2 fingers touch beginning
	void On_TouchStart2Fingers( Gesture gesture){
		
		// Verification that the action on the object
		if (gesture.pickObject == gameObject){			
			EasyTouch.SetEnablePinch( false);
			EasyTouch.SetEnableTwist( true);
		}
	}
	
	// during the txist
	void On_Twist( Gesture gesture){
		
		// Verification that the action on the object
		if (gesture.pickObject == gameObject){	
			transform.Rotate( new Vector3(0,0,gesture.twistAngle));
			textMesh.text = "Delta angle : " + gesture.twistAngle.ToString();
		}
	}
	
	// at the twist end
	void On_TwistEnd( Gesture gesture){

		// Verification that the action on the object
		if (gesture.pickObject == gameObject){
			EasyTouch.SetEnablePinch( true);
			transform.rotation = Quaternion.identity;
			textMesh.text ="Twist me";
		}
	}
	
	// If the two finger gesture is finished
	void On_Cancel2Fingers(Gesture gesture){
		EasyTouch.SetEnablePinch( true);
		transform.rotation = Quaternion.identity;
		textMesh.text ="Twist me";
	}
}
