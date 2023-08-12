using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClientFilter : MonoBehaviour
{
    public Dropdown dropdown;
    public Text resultText;

    private string apiUrl = "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";
    private ClientData clientData;

    [System.Serializable]
    public class ClientData
    {
        public List<Client> clients;
    }

    [System.Serializable]
    public class Client
    {
        public string id;
        public string label;
        public bool isManager;
    }

    public void Start()
    {
        dropdown.onValueChanged.AddListener(FilterClients);
        StartCoroutine(GetClientData());
    }

    IEnumerator GetClientData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                clientData = JsonUtility.FromJson<ClientData>(webRequest.downloadHandler.text);
                FilterClients(0);
            }
        }
    }

    public void FilterClients(int filterIndex)
    {
        List<Client> filteredClients = new List<Client>();

        switch (filterIndex)
        {
            case 0:
                break;
            case 1: 
                filteredClients.AddRange(clientData.clients);
                break;
            case 2:
                filteredClients.AddRange(clientData.clients.FindAll(client => client.isManager));
                break;
            case 3:
                filteredClients.AddRange(clientData.clients.FindAll(client => !client.isManager));
                break;
        }

        DisplayFilteredClients(filteredClients);
    }

    void DisplayFilteredClients(List<Client> filteredClients)
    {
        resultText.text = "";
        foreach (Client client in filteredClients)
        {
            resultText.text += "Client ID: " + client.id + " , Label: " + client.label + "\n";
        }
    }
}