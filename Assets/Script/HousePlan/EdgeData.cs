using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EdgeData{
	private int start;
	private int end;

	public EdgeData(int x,int y){
		//start is smaller value
		if (x < y) {
			start = x;
			end = y;
		} else {
			start = y;
			end = x;
		}
	}
	public int getStart(){
		return start;
	}
	public int getEnd(){
		return end;
	}

	public bool Equal(EdgeData e){
		//Debug.Log (e.getStart() +" "+e.getEnd() +" is Equal " + start+" "+end);
		if (e.getStart() == this.start && e.getEnd() == this.end) {
			return true;
		} else {
			return false;
		}
	}
}
