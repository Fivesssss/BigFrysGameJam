using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] private AudioSource dungeon;

    private void Start()
    {
        dungeon.Play();
    }
}
