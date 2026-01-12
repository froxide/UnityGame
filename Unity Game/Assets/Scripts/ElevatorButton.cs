using UnityEngine;
using System.Collections;

public class ElevatorButton : MonoBehaviour {
	public Elevator Elevator;

	void OnTriggerEnter(Collider collider) {
         if (collider.CompareTag("HandTag")) {
			Elevator.CallElevator ();
		}
	}
}