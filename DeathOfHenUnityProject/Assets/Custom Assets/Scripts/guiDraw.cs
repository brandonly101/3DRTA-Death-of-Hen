using UnityEngine;
using System.Collections;

public class guiDraw : MonoBehaviour {


	// Scene 1, 2
	public Texture2D nutMountain, henImGoingToEat, ohNoLemmeHelp, getWater;
	public bool drawNutMountain, drawText, drawOhNo, drawGetWater;
	
	// Scene 3, 4, 5
	public Texture2D wellLol, wellGiveWater, getAppleBride, brideGiveApple, theWreaths, getWreathsWillow, noLittleHen;
	public bool drawWellLol, drawWellGiveWater, drawGetAppleBride, drawBrideGiveApple, drawGetWreathsWillow, drawWreaths, drawNoLittleHen;

	// Scene 6, 7
	public Texture2D theWagon, canWeCome, okayRooster, howToCross, iCanBridge, whatIfCoal;
	public bool drawWagon, drawCanWeCome, drawOkayRooster, drawHowToCross, drawICanBridge, drawWhatIfCoal;

	// Scene 8, 9, 10
	public Texture2D noRoosterScream, everyoneDead, iAmFillingSad;
	public bool drawNoRoosterScream, drawEveryoneDead, drawIAmFillingSad;

	// Use this for initialization
	void Start () {
		drawNutMountain = drawText = drawOhNo = drawGetWater = false;
		drawWellLol = drawWellGiveWater = drawGetAppleBride = drawBrideGiveApple = drawGetWreathsWillow = drawWreaths = drawNoLittleHen = false;
		drawWagon = drawCanWeCome = drawOkayRooster = drawHowToCross = drawICanBridge = drawWhatIfCoal = false;
	}

	void OnGUI () {
		////////////////////////////////////////////////////////////////
		// Scene 1, 2
		////////////////////////////////////////////////////////////////
		if (drawNutMountain) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.01), 
				(float)(Screen.height * 0.15),
				(float)(Screen.width * 0.7),
				(float)(Screen.height * 0.2)
				),
				nutMountain);
		}
		
		if (drawText) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.2), 
				(float)(Screen.height * 0.57),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				henImGoingToEat);
		}
		
		if (drawOhNo) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.4), 
				(float)(Screen.height * 0.05),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				ohNoLemmeHelp);
		}
		
		if (drawGetWater) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.2), 
				(float)(Screen.height * 0.57),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				getWater);
		}

		////////////////////////////////////////////////////////////////
		// Scene 3, 4, 5
		////////////////////////////////////////////////////////////////
		if (drawWellLol) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.5), 
				(float)(Screen.height * 0.4),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				wellLol);
		}

		if (drawWellGiveWater) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.5), 
				(float)(Screen.height * 0.4),
				(float)(Screen.width),
				(float)(Screen.height * 0.7)
				),
				wellGiveWater);
		}

		if (drawGetAppleBride) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.26), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				getAppleBride);
		}

		if (drawBrideGiveApple) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				brideGiveApple);
		}

		if (drawGetWreathsWillow) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.5), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				getWreathsWillow);
		}

		if (drawWreaths) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.3), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width * 3),
				(float)(Screen.height * 3)
				),
				theWreaths);
		}

		if (drawNoLittleHen) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				noLittleHen);
		}

		////////////////////////////////////////////////////////////////
		// Scene 6, 7
		////////////////////////////////////////////////////////////////

		if (drawWagon) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.3), 
				(float)(Screen.height * 0.5),
				(float)(Screen.width * 3),
				(float)(Screen.height * 3)
				),
				theWagon);
		}

		if (drawCanWeCome) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				canWeCome);
		}

		if (drawOkayRooster) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				okayRooster);
		}

		if (drawHowToCross) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.8),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				howToCross);
		}
		
		if (drawICanBridge) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.5), 
				(float)(Screen.height * 0.2),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				iCanBridge);
		}

		if (drawWhatIfCoal) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				whatIfCoal);
		}

		////////////////////////////////////////////////////////////////
		// Scene 8, 9, 10
		////////////////////////////////////////////////////////////////

		if (drawNoRoosterScream) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.5), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				noRoosterScream);
		}

		if (drawEveryoneDead) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				everyoneDead);
		}

		if (drawIAmFillingSad) {
			GUI.Label (
				new Rect (
				(float)(Screen.width * 0.1), 
				(float)(Screen.height * 0.1),
				(float)(Screen.width),
				(float)(Screen.height)
				),
				iAmFillingSad);
		}

	}
}
