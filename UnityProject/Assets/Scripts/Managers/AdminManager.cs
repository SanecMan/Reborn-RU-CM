﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Pipes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Objects.Wallmounts;
using System.Collections.Concurrent;
using Mirror;

public class AdminManager : MonoBehaviour
{
	public ItemStorage LocalAdminGhostStorage;
	public GameObject ItemStorageHolderPrefab;
	private Dictionary<string, ItemStorage> ghostStorageList = new Dictionary<string, ItemStorage>();

	private static AdminManager adminManager;
	public static AdminManager Instance
	{
		get
		{
			if (!adminManager)
			{
				adminManager = FindObjectOfType<AdminManager>();
			}
			return adminManager;
		}
	}

	public ItemStorage CreateItemSlotStorage(ConnectedPlayer player)
	{
		var holder = Spawn.ServerPrefab(ItemStorageHolderPrefab, null, gameObject.transform);
		var itemStorage = holder.GameObject.GetComponent<ItemStorage>();
		ghostStorageList.Add(player.UserId, itemStorage);
		return itemStorage;
	}

	public ItemStorage GetItemSlotStorage(ConnectedPlayer player)
	{
		return ghostStorageList[player.UserId];
	}

}