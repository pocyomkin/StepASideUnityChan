using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	private GameObject unitychan;

	private int point= -160;

	private GameObject[] objects;

	// Use this for initialization
	void Start () {
		this.unitychan = GameObject.Find ("unitychan");
/*
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < goalPos; i+=15) {
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range (0, 10);
			if (num <= 1) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {

				//レーンごとにアイテムを生成
				for (int j = -1; j < 2; j++) {
					//アイテムの種類を決める
					int item = Random.Range (1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					} else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
*/
	}
	// Update is called once per frame
	void Update () {
//		Debug.Log (this.unitychan.transform.position.z + ":" + point);
		if(startPos < unitychan.transform.position.z && unitychan.transform.position.z + 40 < goalPos
				&& point <= unitychan.transform.position.z){
			point = point + 15;
//			Debug.Log ("生成！");
			int num = Random.Range (0, 10);
			if (num <= 1) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, 
						unitychan.transform.position.z+40);
				}
			} else {
				//レーンごとにアイテムを生成
				for (int j = -1; j < 2; j++) {
					//アイテムの種類を決める
					int item = Random.Range (1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, 
							coin.transform.position.y, unitychan.transform.position.z + 40 + offsetZ);
					} else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, 
							car.transform.position.y, unitychan.transform.position.z + 40 + offsetZ);
					}
				}
			}
		}

		objects = GameObject.FindGameObjectsWithTag ("CarTag");
		foreach(GameObject obj in objects){
			if (obj.transform.position.z <= unitychan.transform.position.z-5) {
				Destroy (obj);
				Debug.Log ("Car破棄");
			}
		}

		objects = GameObject.FindGameObjectsWithTag ("CoinTag");
		foreach(GameObject obj in objects){
			if (obj.transform.position.z <= unitychan.transform.position.z-5) {
				Destroy (obj);
				Debug.Log ("コイン破棄");
			}
		}

		objects = GameObject.FindGameObjectsWithTag ("TrafficConeTag");
		foreach(GameObject obj in objects){
			if (obj.transform.position.z <= unitychan.transform.position.z-5) {
				Destroy (obj);
			}
			Debug.Log ("コーン破棄");
		}

	}
}