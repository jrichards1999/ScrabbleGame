using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class NetworkManagerScrabble : NetworkManager
{
   public override void OnServerAddPlayer(NetworkConnection conn) {
        base.OnServerAddPlayer(conn);
   }

    public override void OnServerDisconnect(NetworkConnection conn) {
        base.OnServerDisconnect(conn);
    }
}
