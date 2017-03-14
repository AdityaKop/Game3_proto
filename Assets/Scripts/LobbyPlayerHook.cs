﻿using System.Collections;
using Prototype.NetworkLobby;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyPlayerHook : LobbyHook {

	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
	{
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer> ();
		SetupLocalPlayer localPlayer = gamePlayer.GetComponent<SetupLocalPlayer> ();

		localPlayer.pname = lobby.playerName;
		localPlayer.playerColor = lobby.playerColor;
	}
}