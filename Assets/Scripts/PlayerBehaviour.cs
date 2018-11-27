using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	private Vector3 rotatedForward;
	private Vector3 rotatedUp;

	private Matrix3x3 matrix;
	private Matrix3x3 matrixEuler;
	private Matrix3x3 matrixX;
	private Matrix3x3 matrixY;
	private Matrix3x3 matrixZ;

	public GameObject objectToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		Vector3 euler = objectToFollow.transform.rotation.eulerAngles;

		matrixEuler = matrixEuler.Euler(euler);

		matrixEuler = matrixEuler.Rotate(euler.y, Matrix3x3.AxisId.y) *  matrixEuler.Rotate(euler.x,  Matrix3x3.AxisId.x) * matrixEuler.Rotate(euler.z,  Matrix3x3.AxisId.z);

		transform.forward = matrixEuler * Vector3.forward;
		transform.up = matrixEuler * Vector3.up;
	}


}
