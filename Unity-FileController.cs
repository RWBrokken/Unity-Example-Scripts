/*  ---------------------------------------------------------------------------------------
   	  Save Utility Script		V.2.3		Originally coded by: Richard Brokken  12/2017
   	  Use: Managed save and load system		Customized by: 
   	  Description: This is an example for a filesave controller object, with potential
   	          for multiple saves (ie. different levels) based on filenames, in addition
			  to a highscore list with ascending and descending sort function.
    ---------------------------------------------------------------------------------------  */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//    The following are used to access other nessessary namspaces for file operations
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//    Commented out as this example has the settings on the GameController object, provided here for information
//[System.Serializable]
//public class AppSettings {
//	public string testString;
//	public string loadTest;
//
//	[Header("Save filenames")]
//	public string settingsSave;
//	public string gameSave;
//	public string playerSave;
//	public string highscoreSave;
//	// Extras for HighScore
//	public bool _I___EraseFile;
//}
//    Primary execution script, only needs declarations. Can have functions.
public class FileController : MonoBehaviour {
	public bool debugMsgsEnabled = true;
	[HideInInspector]  //    Used to hide this appsettings instance and values therein from the Inspector view as pull from class on another object - gamecontroller
	public AppSettings appSettings;
	public GameFile gameFile;
	public HighScore_C highScore;
	void Start() {
		DontDestroyOnLoad(this);
		appSettings = GameObject.FindObjectOfType<GameController> ().appSettings;
		//  !  This check portion is nessessary to successfully create new files/directories
		gameFile.fileCheck();
		highScore.fileCheck();
		if (debugMsgsEnabled) Debug.Log ("game data @ "+Application.persistentDataPath+"\\");
	}
	void FixedUpdate() {
		//    In case the originally referranced object for AppSettings goes missing, such as a level load
		if (appSettings == null) appSettings = GameObject.FindObjectOfType<GameController> ().appSettings;
		if (appSettings._I___EraseFile) {
			appSettings._I___EraseFile = false;
			Debug.LogError("Erasing: "+Application.persistentDataPath + "\\" + appSettings.highscoreSave);
			File.Delete(Application.persistentDataPath + "\\" + appSettings.highscoreSave);
		}
	}
	void OnApplicationExit() {
		if (debugMsgsEnabled) Debug.Log ("App Exit");
	}
	void OnApplicationQuit() {
		if (debugMsgsEnabled) Debug.Log ("App Quit");
	}
	//  Extra functions (in-progress)
	public class Extra_Utilities {
		//		In-Progress:
		//		public float ConvertFromScientificNotation (float valueToConvert) {
		//			//    Use: To convert values which become scientifically notated
		//		}
		public int func_ConvertFloatToInt (float floatVal, bool roundDown = true) {
			if (roundDown)
				return (Mathf.FloorToInt (floatVal));
			else
				return (Mathf.CeilToInt (floatVal));
		}

		private char[] ProcessString(string inString) {
			char[] c_array;
			c_array = inString.ToCharArray ();
			return c_array;
		}
		private string ProcessCharArray(char[] inCharArray){
			string outString = "";
			char evalChar;
			for ( int i=0; i < inCharArray.Length; i++ ) {
				evalChar = inCharArray [i];
				outString += evalChar.ToString ();
			}
			return outString;
		}
	}
}
[System.Serializable]
public class GameFile {
	private FileController _Controller { get { return GameObject.FindObjectOfType<FileController> (); } }
	private AppSettings appSettings { get { return _Controller.appSettings; } }
	public bool isLoading, isSaving;
	//    This check portion is nessessary to successfully create new files/directories
	public void fileCheck () {
		//    Check for the save files
		if (File.Exists(""+Application.persistentDataPath+"\\"+appSettings.playerSave)
			&&
			File.Exists (""+Application.persistentDataPath+"\\"+appSettings.gameSave)) {
			if (_Controller.debugMsgsEnabled) Debug.LogError ("Save files found.");
			return;
		}
		//    If no save files found then create new
		if (!File.Exists(""+Application.persistentDataPath+"\\"+appSettings.gameSave)) {
			if (_Controller.debugMsgsEnabled) Debug.LogError ("  No \'game\' save found!\t..creating.\n"+Application.persistentDataPath+"\\"+appSettings.gameSave);
			Save ("newGame");
		}
		if (!File.Exists(""+Application.persistentDataPath+"\\"+appSettings.playerSave)) {
			if (_Controller.debugMsgsEnabled) Debug.LogError ("  No \'player\' save found!\t..creating.\n"+Application.persistentDataPath+"\\"+appSettings.playerSave);
			Save ("newPlayer");
		}
	}
	public void Save(string inSaveCmd) {
		isSaving = true;
		if (inSaveCmd == "game" || inSaveCmd == "newGame" || 
			inSaveCmd == "player" || inSaveCmd == "newPlayer") {
			string savePath = "newFile";
			if (inSaveCmd == "game" || inSaveCmd == "newGame") {
				savePath = appSettings.gameSave;
			}
			else if (inSaveCmd == "player" || inSaveCmd == "newPlayer") {
				savePath = appSettings.playerSave;
			}
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (("" + Application.persistentDataPath + "\\" + savePath + ""), FileMode.OpenOrCreate, FileAccess.ReadWrite);
			GameSaveStruct dataGS = new GameSaveStruct ();
			//			if (inSaveCmd == "newGame" || inSaveCmd == "newPlayer") {
			//			//    Create basic save under the GameSaveStruct for both files as this script currently stands
			//				dataGS.currentScore = 0;
			//				dataGS.currentLvL = 1;
			//				dataGS.currentHP = 3;
			//				dataGS.currentSP = 0f;
			//				dataGS.stringText = "hello";
			//			} else {
			//			//    Save the values from the current running game to the GameSaveStruct for both the game and player as script currently stands
			//				dataGS.currentScore = gameCtrlr.score;
			//				dataGS.currentLvL = gameCtrlr.appSettings.hazardCount-2;
			//				dataGS.currentHP = gameCtrlr.playercontroller.playerHealth.Health();
			//				dataGS.currentSP = gameCtrlr.playercontroller.playerSheildScript.SheildHealth();
			//			}
			bf.Serialize (file, dataGS);
			file.Close ();
		}
		if (_Controller.debugMsgsEnabled) Debug.LogWarning (""+inSaveCmd+" saved");
		isSaving = false;
	}  
	public void Load(string inLoadCmd) {
		isLoading = true;
		if (inLoadCmd == "game" || inLoadCmd == "player") {

			if (inLoadCmd == "game") {
				inLoadCmd = appSettings.gameSave;
			}
			if (inLoadCmd == "player") {
				inLoadCmd = appSettings.playerSave;
			}
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (("" + Application.persistentDataPath + "\\" + inLoadCmd + ""), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Inheritable);
			#pragma warning disable 0219  //   Used to quit its complaining as empty in this example, temp
			GameSaveStruct dataGS = (GameSaveStruct)bf.Deserialize (file);
			#pragma warning restore 0219
			file.Close ();
			//    Restore values from the save file to the game, an example use
			//			gameCtrlr.score = dataGS.currentScore;
			//			gameCtrlr.BroadcastMessage ("UpdateScore");
			//			gameCtrlr.levelSelector (dataGS.currentLvL);
			//			if (gameCtrlr.playercontroller!=null){
			//				gameCtrlr.playercontroller.playerHealth.SetHealth(dataGS.currentHP);
			//				gameCtrlr.playercontroller.playerSheildScript.SetSheildStrength(dataGS.currentSP);
			//			_Controller.appSettings.testString = dataGS.stringText; 
			//			_Controller.appSettings.loadTest = dataGS.currentScore.ToString ();
		}
		if (_Controller.debugMsgsEnabled) Debug.LogWarning ("" + inLoadCmd + " loaded");
		isLoading = false;
	}
}
[System.Serializable]
public class HighScore_C {
	private FileController _Controller { get { return GameObject.FindObjectOfType<FileController> (); } }
	private AppSettings appSettings { get { return _Controller.appSettings; } }
	private string _fileLocation { get { return appSettings.highscoreSave; } }
	public bool isLoading, isSaving;
	[Header("Score List Stuff")]
	public int numberOfEntries = 10;
	public bool newHighScore;
	public List <Highscore> Highscores = new List<Highscore>();
	//    This check portion appears to be nessessary to successfully create new files/directories
	public void fileCheck (string FileName = "", bool isDescending = true) {
		if (FileName == "") /*then*/ FileName = _fileLocation;
		//    Check for the save files
		if (File.Exists(""+Application.persistentDataPath+"\\"+FileName)) {
			if (_Controller.debugMsgsEnabled) Debug.LogError ("  Highscore \'" + FileName + "\' file found.");
			return;
		}
		//    If no save files found then create new
		if (!File.Exists(""+Application.persistentDataPath+"\\"+FileName)) {
			if (_Controller.debugMsgsEnabled) Debug.LogError ("  No \'" + FileName + "\' file found!\t..creating.\nLocation:"+Application.persistentDataPath+"\\"+FileName);
			if (isDescending) {
				Save (FileName, isDescending, "newfile");
			} else {
				Save (FileName, isDescending, "-newfile");
			}
		}
	}
	public void Save (string SaveFileName = "", bool isDescending = true, string inOptions = "") {
		isSaving = true;
		if (SaveFileName == "") { 
			SaveFileName = _fileLocation;			
		} else {
			//  Infanite loop/break without warning, just run a filecheck() before first or each save
			//			if (_Controller.debugMsgsEnabled) Debug.LogWarning ("Save received filename to use: " + SaveFileName);
			//			if (SaveFileName != _fileLocation && (inOptions != "newfile" || inOptions != "-newfile")) {
			//				fileCheck (SaveFileName, isDescending);
			//			}
		}
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (("" + Application.persistentDataPath + "\\" + SaveFileName), FileMode.OpenOrCreate, FileAccess.ReadWrite);
		HighScore_C dataHS = new HighScore_C ();
		if (inOptions == "newfile") {
			if (_Controller.debugMsgsEnabled) Debug.LogError("Setting descending skeleton values");
			Highscores.Clear ();  //    Ensures the list is clear when making a new file
			// Make something to show, or not..
			SubmitScore(42, "Everything");
			SubmitScore(1000000, "Dr. Evil");
			SubmitScore(1234567890, "7#3Cr3470r-1337");
			SubmitScore(1000000000, "Dr. Evil (revised)");
			SubmitScore (666, "REDRUM");
			newHighScore = false;
		}
		if (inOptions == "-newfile") {
			if (_Controller.debugMsgsEnabled) Debug.LogError("Settings ascending skeleton values");
			Highscores.Clear ();  //    Ensures the list is clear when making a new file
			// Make something to show, or not..
			SubmitScore(-42, "Nothing");
			SubmitScore(-1000000, "UN to pay Dr. Evil");
			SubmitScore(-1234567890, "ins_your-name-here");
			SubmitScore(-1000000000, "A Mil isnt that much");
			SubmitScore (-666, "MURDER");
			newHighScore = false;
		}
		Highscores.Sort();
		if (isDescending == false)	Highscores.Reverse ();
		dataHS.Highscores = Highscores;
		bf.Serialize (file, dataHS);
		file.Close ();
		if (_Controller.debugMsgsEnabled) Debug.LogWarning ("Highscores saved to " + SaveFileName);
		isSaving = false;
	}  
	public void Load (string LoadFileName = "") {
		isLoading = true;
		if (LoadFileName == "") { 
			LoadFileName = _fileLocation;			
		}
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (("" + Application.persistentDataPath + "\\" + LoadFileName), FileMode.OpenOrCreate, FileAccess.ReadWrite);
		HighScore_C dataHS = (HighScore_C)bf.Deserialize (file);
		file.Close ();
		if (_Controller.debugMsgsEnabled) Debug.LogError ("Restoring score values from save, file: " + dataHS.Highscores.Count + "\tenv before: " + Highscores.Count);
		Highscores.Clear (); 
		newHighScore = false;
		Highscores = dataHS.Highscores;
		CheckNumEntries ();
		//newHighScore = false; //    Ensure that this was not saved or that it resets on next load, nessessary if entire class is serialized not just that of the struct
		if (_Controller.debugMsgsEnabled) Debug.LogWarning ("" + LoadFileName + " loaded");
		isLoading = false;
	}
	public void SubmitScore (/*float*/ double Score, string Name, bool desc = true){
		Highscore _submitting = new Highscore (Score, Name);
		Highscores.Add (_submitting);
		Highscores.Sort ();

		if (!desc) Highscores.Reverse();
		CheckNumEntries ();
		if (Highscores.Contains (_submitting)) {
			newHighScore = true;
			if (_Controller.debugMsgsEnabled) Debug.LogWarning ("\tNew High Score !!!");
		} else newHighScore = false;
	}
	private void CheckNumEntries () {
		if (Highscores.Count > numberOfEntries) {
			for (int i = numberOfEntries; Highscores.Count >= i; i++) {
				Highscores.RemoveAt(i);	
			}
		}
	}
}
#region Save Structs
[System.Serializable]
public class Highscore : IComparable<Highscore> {
	//    Made the class public here as the public list complains without, easier to access list than use function to return vales
	public /*float*/ double Score;
	public string Name;
	public Highscore (/*float*/ double _Score, string _Name) {
		Score = _Score;
		Name = _Name;
	}
	public int CompareTo (Highscore other) {
		if (other == null) { return 1; }
		if (Score > other.Score) { return -1; }
		if (Score < other.Score) { return 1; } 
		else { return 0; }
	}
}

//    Must have the values showing as public so that the other functions will be able to see and locate the informaiton.
[System.Serializable]
class GameSaveStruct {
	//	public int currentScore;
	//	public int currentLvL;
	//	public int currentHP;
	//	public float currentSP;
	//	public string stringText;
}
//[System.Serializable]
//class GameSettings {
//	Vector2 ScreenResolution;
//	bool FullScreenEnable;
//}
#endregion
