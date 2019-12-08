using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : LivingEntity
{
    public GameObject healthUi;
    public RectTransform hpUiTransform;
    public GameObject camPrefabs;
    public Camera camPlayer;
    private Vector3 rotation;
    public GameObject grenadePrefabs;
    public Transform gunTransform;
    public override void Initialization()
    {
        base.Initialization();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        Initialization();
        if (isLocalPlayer)
        {
            name = "LocalPlayer";
        }
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        PlayerMovement();
        HpManager();
        if (Input.GetMouseButtonUp(0))
        {
            CmdSpawnGrenade();
        }
    }



    public void HpManager()
    {
        if (hpUiTransform != null)
        {
            if (maxHealth - damageHealth < 0)
            {
                damageHealth = maxHealth;
            }
            hpUiTransform.localScale = new Vector3((maxHealth - damageHealth) / maxHealth, 1, 1);

        }
        else
        {
            hpUiTransform = Instantiate(healthUi, GameObject.Find("Canvas").transform).transform.GetChild(0).GetComponent<RectTransform>();
        }
    }
    public void LockCursorToggle()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    [Command]
    public void CmdSpawnGrenade()
    {
        var gre = Instantiate(grenadePrefabs, gunTransform.position, Quaternion.identity);
        NetworkServer.Spawn(gre);
        gre.GetComponent<Grenade>().direction = camPlayer.transform.forward;
    }
    public void PlayerMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        rotation.x -= mouseY;
        rotation.y += mouseX;
        rigid.rotation = Quaternion.Euler(rotation);
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (jump)
        {
            AddForceEak(Vector3.up, jumpForce);
        }
        Move(camPlayer.transform.forward * z + camPlayer.transform.right * x, speed);

    }
}
