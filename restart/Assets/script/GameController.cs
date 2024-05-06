//using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int blockCount = 5;

    public LevelBlock[] levelBlockPrefabs;
    public LoseMenuTag LoseMenu;
    public charaster characterPrefab;
    public charaster playerCopy;
    public List<LevelBlock> spawnedBlocks = new();
   // public List<LoseMenuTag> spawnedUI = new();


    private void Start()
    {
        for (int qadam = 0; qadam < blockCount; qadam++)
        {
            SpawnBlock();
        }

        SpawnCharacter();
    }

    private void SpawnBlock()
    {
        int index = Random.Range(0, levelBlockPrefabs.Length);
        LevelBlock levelBlockPrefab = levelBlockPrefabs[index];
        LevelBlock levelBlockCopy = Instantiate(levelBlockPrefab);

        if (spawnedBlocks.Count > 0)
        {
            levelBlockCopy.transform.position = spawnedBlocks.Last().endPosition.position;
        }
        else
        {
            levelBlockCopy.transform.position = new Vector3(0, 0, 0);
        }

        spawnedBlocks.Add(levelBlockCopy);

        levelBlockCopy.endPositionSignals.onExit += RegenerateBlocks;
    }

    private void RegenerateBlocks()
    {
        SpawnBlock();
        DeleteOldBlock();
    }

    private void DeleteOldBlock()
    {
        if (spawnedBlocks.Count > 1)
        {
            LevelBlock oldBlock = spawnedBlocks.First();
            spawnedBlocks.Remove(oldBlock);

            Destroy(oldBlock.gameObject);
        }
    }

    private void SpawnCharacter()
    {
        playerCopy = Instantiate(characterPrefab);
        playerCopy.transform.position = new Vector3(0, 0, 0);

        playerCopy.WallTriger += StopGame;
        playerCopy.WallTriger += LoseMenuTag;
    }

    public void LoseMenuTag()
    {
        LoseMenuTag loseMenuPrefab = LoseMenu;
        LoseMenuTag levelBlockCopy = Instantiate(loseMenuPrefab);
    }

    private void StopGame()
    {
        playerCopy.Freeze();
    }
}