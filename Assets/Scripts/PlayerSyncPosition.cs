using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour {

    [SyncVar]
    Vector3 m_SyncPos;

    [SerializeField]
    Transform m_MyTransform;

    [SerializeField]
    float m_LerpRate = 15;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate () {
        TransmitPosition();
        LerpPosition();	//2点間を補間する
    }

    //ポジション補間用メソッド
    void LerpPosition() {
        //補間対象は相手プレイヤーのみ
        if (!isLocalPlayer) {
            m_MyTransform.position = Vector3.Lerp(m_MyTransform.position, m_SyncPos, m_LerpRate*Time.deltaTime);
        }
    }

    //クライアントからホストへ、Position情報を送る
    [Command]
    void CmdProvidePositionToServer(Vector3 pos) {
        //サーバー側が受け取る値
        m_SyncPos = pos;
    }

    //クライアントのみ実行される
    [ClientCallback]
    //位置情報を送るメソッド
    void TransmitPosition() {
        if (isLocalPlayer) {
            CmdProvidePositionToServer(m_MyTransform.position);
        }
    }
}
