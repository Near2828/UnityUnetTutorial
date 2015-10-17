using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetUp : NetworkBehaviour {

    #region PrivateMember

    [SerializeField]
    Camera m_FPSCharaCamera;

    [SerializeField]
    AudioListener m_AudioListener;

    #endregion

    // Use this for initialization
    void Start () {
        if (isLocalPlayer) {
            GameObject.Find("Scene Camera").SetActive(false);
            GetComponent<CharacterController>().enabled = true;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            m_FPSCharaCamera.enabled = true;
            m_AudioListener.enabled = true;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
