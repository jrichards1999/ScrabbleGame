using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class IPButtonHandler : NetworkBehaviour
{
    public Text IPtxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        string publicIPAddress = GetIPAddress();
        IPtxt.text = publicIPAddress;
    }

    static string GetIPAddress() {
        String address = "";
        WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
        using (WebResponse response = request.GetResponse())
        using (StreamReader stream = new StreamReader(response.GetResponseStream())) {
            address = stream.ReadToEnd();
        }

        int first = address.IndexOf("Address: ") + 9;
        int last = address.LastIndexOf("</body>");
        address = address.Substring(first, last - first);

        return address;
    }
}
