using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using Project.Utility;

public class NetworkClient : SocketIOComponent
    {
        [SerializeField]
        private Transform networkContainer;
        [SerializeField]
        private GameObject playerPrefab;

    private Dictionary<string, NetworkIdentity> serverObjects;
   
        public static string ClientID
        {
            get;
            private set;
        }

        // Start is called before the first frame update
        public override void Start()
        {
        base.Start();
        SetupEvents();
        initialize();
       
    }

        // Update is called once per frame
        public override void Update()
        {
           
        base.Update();
        
    }

        private void initialize() {
        serverObjects = new Dictionary<string, NetworkIdentity>();

    }

    void SetupEvents() {
        On("open", (E) =>
        {
            Debug.Log("Connection madeLeo");

        });


        On("register", (E) =>
        {
            // string id = E.data["id"].ToString().RemoveQuotes();
            // ClientID = E.data["id"].ToString().Trim('"');
            ClientID = E.data["id"].ToString().RemoveQuotes();
            Debug.Log(ClientID);
            Debug.Log("Register");

        });

        On("spawn", (E) =>
        {
            string id = E.data["id"].ToString().RemoveQuotes();
            GameObject go = Instantiate(playerPrefab, networkContainer);
            go.name = string.Format("Player({0})", id);
            NetworkIdentity ni = go.GetComponent<NetworkIdentity>();
            ni.SetControllerID(id);
            ni.SetSocketReference(this);
            serverObjects.Add(id, ni);
           // go.transform.SetParent(networkContainer);
           // serverObjects.Add(id, go);
            
            //Debug.Log(serverObjects);
           

        });

        On("disconnect", (E) =>
        {
            string id = E.data["id"].ToString();
            GameObject go = serverObjects[id].gameObject;
            Destroy(go);
            serverObjects.Remove(id);
            Debug.Log("On disconnect");

        });
        
        //part3 42:30
        On("updatePosition", (E) =>
        {

           
           
            string id = E.data["id"].ToString().RemoveQuotes();
           // Debug.Log(id);
            float x = E.data["position"]["x"].f;
            float y = E.data["position"]["y"].f;
            //Debug.Log("updatePosition");
            
            NetworkIdentity ni = serverObjects[id];
            //Debug.Log(ni);
            ni.transform.position = new Vector3(x, y, 0);
           

        });

    }
}
[Serializable]
public class Player
{
    public string id;
    public Position position;
}

[Serializable]
public class Position
{
    public float x;
    public float y;
}

[Serializable]
public class PlayerRotation
{
    public float tankRotation;
    public float barrelRotation;
}

[Serializable]
public class BulletData
{
    public string id;
    public string activator;
    public Position position;
    public Position direction;
}

[Serializable]
public class IDData
{
    public string id;
}

