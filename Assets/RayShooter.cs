using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {

    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            Debug.Log ("Огонь");
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay (point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
                if (target != null) {
                    target.ReactToHit();
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
            
        }


	}

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds (3f);
        Destroy (sphere);

    }

    void OnGUI() {
        int size = 15;
        float posX = _camera.pixelWidth / 2 - size / 2;
        float posY = _camera.pixelHeight / 2 - size / 2;

        GUI.color = Color.red;
        GUI.Label(new Rect(posX, posY, size, size), "+");


    }
}
