using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerControl : UI {

    public Animator _Servers;
    public Text _ServerName;

    private Server _Server;

	// Use this for initialization
	void Start () {
        Init();
    }

    public void Init()
    {
        ServerSetUp(Server.anton);

        UIHelper.AddButtonListener(Vars["anton"], () => {
            ServerSetUp(Server.anton);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["bakal"], () => {
            ServerSetUp(Server.bakal);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["cain"], () => {
            ServerSetUp(Server.cain);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["casillas"], () => {
            ServerSetUp(Server.casillas);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["diregie"], () => {
            ServerSetUp(Server.diregie);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["hillder"], () => {
            ServerSetUp(Server.hillder);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["prey"], () => {
            ServerSetUp(Server.prey);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["siroco"], () => {
            ServerSetUp(Server.siroco);
            _Servers.SetTrigger("close");
        });

        UIHelper.AddButtonListener(Vars["Server"], () => {
            _Servers.SetTrigger("open");
        });

        UIHelper.AddButtonListener(Vars["Enter"], () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/CharacterSearch")).GetComponent<SearchcharacterInfo>().SearchUrl(_Server, Vars["characterNameInput"].GetComponentInChildren<Text>().text, this.gameObject);
        });

    }

    private void ServerSetUp(Server server)
    {
        _Server = server;

        switch (_Server)
        {
            case Server.anton:
                _ServerName.text = "안톤";
                break;
            case Server.bakal:
                _ServerName.text = "바칼";
                break;
            case Server.cain:
                _ServerName.text = "카인";
                break;
            case Server.casillas:
                _ServerName.text = "카시야스";
                break;
            case Server.diregie:
                _ServerName.text = "디레지에";
                break;
            case Server.hillder:
                _ServerName.text = "힐더";
                break;
            case Server.prey:
                _ServerName.text = "프레이";
                break;
            case Server.siroco:
                _ServerName.text = "시로코";
                break;
        }
    }
}
