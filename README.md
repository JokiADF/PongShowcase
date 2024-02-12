# PongShowcase

This project is a clone of the game Pong. 
The purpose of this project is to demonstrate my skills as a developer.

* [Introduction](#introduction)
* [Mechanics](#mechanics)
* [Changes](#changes)
* [Dependencies](#dependencies)

## Introduction

This project is a rewritten version of my old [project](https://github.com/JokiADF/PongMVPShowcaseOld). 
The basic mechanics remain the same, only the architectural aspects have changed. All changes are described in Changes.

The project was realised on my template, [MyTemplateForU](https://github.com/JokiADF/MyTemplateForU).

## Mechanics
* Basic application architecture:
    * GameStateMachine;
    * AssetManagment; 
    * SceneManagment; 
    * Factories;
    * ScreenService;
* Pong, rackets and ball;
* AudioService, play music and audio effects;
* PoolingService, pattern object pool;
* StorageService, saving and loading player account data;
* StaticDataService, config loading.

## Changes
* Rejection of the MVP architecture;
* Zenject factories and pools waived;
* UniRx usage has been reduced;
* Part of the game logic is placed in a separate service, for example CameraShakerService;
* Improved AssetProvide;
* Added ScreenService, screens display control;
* Added StaticDataService and used ScriptableObject for configs;
* Added PollingService;
* Used Portrait screen, 1080x2350;

## Dependencies
1. Addressables
2. [Zenject (Extenject)](https://github.com/modesttree/Zenject)
3. [UniTask](https://github.com/Cysharp/UniTask)
4. [UniRx](https://github.com/neuecc/UniRx)
5. [DOTween](https://github.com/Demigiant/dotween)
