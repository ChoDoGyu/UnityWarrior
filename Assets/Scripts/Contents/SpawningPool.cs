﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawningPool : MonoBehaviour
{
	[SerializeField]
	int _monsterCount = 0;

	int _reserveCount = 0;

	[SerializeField]
	int _keepMonsterCount = 0;

	[SerializeField]
	Vector3 _spawnPos;
	[SerializeField]
	float _spawnRadius = 20.0f;
	[SerializeField]
	float _spawnTime = 20.0f;

	string _enemyName;

	public void SetEnemyType(string enemyName)
	{
		_enemyName = enemyName;
	}

	public void AddMonsterCount(int value)
	{
		_monsterCount += value;
	}

	public void SetKeepMonsterCount(int count)
	{
		_keepMonsterCount = count;

	}

	public void SetRadius(float radius)
	{
		_spawnRadius = radius;
	}

	void Start()
	{
		Managers.Game.OnSpawnEvent -= AddMonsterCount;
		Managers.Game.OnSpawnEvent += AddMonsterCount;
		_spawnPos = transform.position;
	}

	void Update()
	{
		while (_reserveCount + _monsterCount < _keepMonsterCount)
		{
			StartCoroutine("ReserveSpawn");
		}
	}

	IEnumerator ReserveSpawn()
	{
		++_reserveCount;
		yield return new WaitForSeconds(Random.Range(0, _spawnTime));
		GameObject obj = Managers.Game.Spawn(Define.WorldObject.Enemy, _enemyName);
		NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();

		Vector3 randPos;

		while (true)
		{
			// 랜덤으로 뽑은 방향 벡터
			Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
			randDir.y = 0;
			randPos = _spawnPos + randDir;

			// 갈 수 있나?
			NavMeshPath path = new NavMeshPath();
			if (nma.CalculatePath(randPos, path))
				break;
		}

		obj.transform.position = randPos;
		--_reserveCount;
	}
}
