using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {

	public static void SaveScene(string fileName = "inwmoneiei.xml"){
		XmlDocument doc = new XmlDocument ();
		doc.AppendChild(doc.CreateXmlDeclaration("1.0","UTF-8","no"));
			
		XmlElement rootElement = doc.CreateElement ("PlanList");
		doc.AppendChild (rootElement);
		XmlElement planElement = doc.CreateElement ("Plan");
		rootElement.AppendChild (planElement);

		XmlElement wallElement = doc.CreateElement ("WallList");
		planElement.AppendChild (wallElement);
		string wallList = "";
		for (int i = 0; i < BluePrintData.GetSize(); i++) {
			wallList += BluePrintData.GetValue (i).getStart() + "," + BluePrintData.GetValue (i).getEnd();
			wallList += " ";
		}
		wallElement.InnerText = wallList;
		wallElement.SetAttribute ("texture", BluePrintData.wallTexture.name);

		XmlElement furnitureListElement = doc.CreateElement ("FurnitureList");
		planElement.AppendChild (furnitureListElement);
		GameObject[] furnitureList = Furniture.furnitureInScene.ToArray ();
		for(int i=0;i<furnitureList.Length;i++){
			XmlElement furnitureElement = doc.CreateElement ("Furniture");
			GameObject furnitureObj = (GameObject) furnitureList.GetValue (i);
			furnitureElement.SetAttribute ("name",furnitureObj.GetComponent<Furniture>().furniturePath);

			XmlElement positionElement = doc.CreateElement ("Position");
			positionElement.SetAttribute ("x", furnitureObj.transform.position.x.ToString());
			positionElement.SetAttribute ("y", furnitureObj.transform.position.y.ToString());
			positionElement.SetAttribute ("z", furnitureObj.transform.position.z.ToString());
			furnitureElement.AppendChild (positionElement);

			XmlElement rotationElement = doc.CreateElement ("Rotation");
			rotationElement.SetAttribute("x",furnitureObj.transform.rotation.eulerAngles.x.ToString());
			rotationElement.SetAttribute("y",furnitureObj.transform.rotation.eulerAngles.y.ToString());
			rotationElement.SetAttribute("z",furnitureObj.transform.rotation.eulerAngles.z.ToString());
			furnitureElement.AppendChild (rotationElement);

			XmlElement scaleElement = doc.CreateElement ("Scale");
			scaleElement.SetAttribute ("x", furnitureObj.transform.localScale.x.ToString());
			scaleElement.SetAttribute ("y", furnitureObj.transform.localScale.y.ToString());
			scaleElement.SetAttribute ("z", furnitureObj.transform.localScale.z.ToString());
			furnitureElement.AppendChild (scaleElement);

			furnitureListElement.AppendChild (furnitureElement);
		}

		/*
		XmlElement el = (XmlElement)doc.AppendChild (doc.CreateElement ("Foo"));
		el.SetAttribute ("Bar", "value");
		*/
		//write xml to file
		TextWriter writter = new StreamWriter (fileName);
		writter.Write (doc.OuterXml);
		writter.Close();
	}

	public static void LoadScene(string fileName = "inwmoneiei.xml"){
		Furniture.furnitureInScene.Clear ();
		BluePrintData.clear ();
		//UIControl uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();

		TextReader reader = new StreamReader(fileName);
		XmlDocument doc = new XmlDocument ();
		doc.LoadXml(reader.ReadToEnd());
		XmlElement planNode = (XmlElement) doc.GetElementsByTagName ("Plan").Item (0);
		XmlNode wallListNode = planNode.FirstChild;
		string[] wall = wallListNode.InnerText.Split(' ');
		Texture wallTexture = Resources.Load ("Image/HouseWallpaper/"+wallListNode.Attributes.Item(0).InnerText, typeof(Texture)) as Texture;
		//Debug.Log ("Image/HouseWallpaper/"+wallListNode.Attributes.Item(0).InnerText);
		BluePrintData.wallTexture = wallTexture;
		Material wallMat = Resources.Load ("Wall/wall", typeof(Material)) as Material;
		wallMat.SetTexture ("_DiffuseMapSpecA", wallTexture);
		List<EdgeData> wallList = new List<EdgeData> ();
		for (int i = 0; i < wall.Length; i++) {
			if (wall [i].Trim () == "")
				continue;
			string[] edge = wall [i].Split (',');
			int startIdx = int.Parse (edge [0]);
			int endIdx = int.Parse (edge [1]);
			wallList.Add (new EdgeData (startIdx, endIdx));
			//draw line
			DotScript.DrawLine(DotScript.FindDot(startIdx),DotScript.FindDot(endIdx) ,Color.red,0);
			DotScript.list.Add (new EdgeData (startIdx, endIdx));
		}
		//BluePrintData.CreateArrayFromList (wallList);
		//BluePrintData.CreateRoom ();
		DotScript.ComfirmRoom();

		//furniture start from sceond child
		XmlElement furnitureList =(XmlElement) planNode.GetElementsByTagName("FurnitureList").Item(0);
		for (int i = 0; i < furnitureList.ChildNodes.Count; i++) {
			XmlElement furnitureXml = (XmlElement) furnitureList.ChildNodes.Item (i);
			string furnitureName = furnitureXml.GetAttribute ("name");
			GameObject furnitureObj = Resources.Load (furnitureName, typeof(GameObject)) as GameObject;
			furnitureObj = Instantiate(furnitureObj);
			Furniture furnitureScript = furnitureObj.GetComponent<Furniture> ();
			if (furnitureScript == null) {
				furnitureObj.AddComponent<Furniture> ();
				furnitureScript = furnitureObj.GetComponent<Furniture> ();
			}
			furnitureScript.EnableEditMode(false);
			Furniture.furnitureInScene.Add(furnitureObj);
			furnitureObj.GetComponent<Furniture> ().furniturePath = furnitureName;

			XmlElement positionXml = (XmlElement) furnitureXml.GetElementsByTagName("Position").Item(0);
			Vector3 position = new Vector3 (float.Parse(positionXml.GetAttribute ("x")), float.Parse(positionXml.GetAttribute ("y")), float.Parse(positionXml.GetAttribute ("z")));
			furnitureObj.transform.position = position;

			XmlElement rotationXml = (XmlElement) furnitureXml.GetElementsByTagName("Rotation").Item(0);
			Vector3 rotation = new Vector3 (float.Parse(rotationXml.GetAttribute ("x")), float.Parse(rotationXml.GetAttribute ("y")), float.Parse(rotationXml.GetAttribute ("z")));
			furnitureObj.GetComponent<Transform> ().eulerAngles = rotation;

			XmlElement scaleXml = (XmlElement)furnitureXml.GetElementsByTagName ("Scale").Item (0);
			Vector3 scale = new Vector3 (float.Parse(scaleXml.GetAttribute ("x")), float.Parse(scaleXml.GetAttribute ("y")), float.Parse(scaleXml.GetAttribute ("z")));
			furnitureObj.transform.localScale = scale*Furniture.cameraScale;

		}
		reader.Close ();
	}
}
