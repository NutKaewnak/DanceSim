# Project status: Legacy support
Since I only maintained this project for a game I am working on and switched to Unreal 4, unityserializer-ng is no longer under active development. However, I released this to the open and thus believe that it is my responsibility to provide the users of this software with some form of support.
I do not want the developers of a potentially great game getting into trouble because this asset failed them. Here is a short list of what I will an will not do from now on:
* I **will not** implement new features
* I **will not** support new Unity versions (>5.4)
* I **will** take issue reports (either here or on GitHub)
* I **will** try to fix bugs in already implemented functionality
* I **will** answer questions

# Important annoucements
## How to submit a bug-report?
Since trying to reproduce bugs all by myself has proven quite time-consuming in the past, here's a new rule you have to follow, if you want me to look into your problems. Always have your bug submissions include:
* Summary title - (fewer than 8 words)
* What did you expect would happen
* What did happen (why is this a bug)
* What are the steps to reproduce
* Additional details.

## Limited Animator (mecanim) support!
unityserializer-ng now supports saving and restoring parts of your Animators. Instructions can be found here.

---------
---------

# Introduction
## What is unityserializer-ng?
unityserialier-ng is a fork of Mike Talbot's Unity Serializer asset; A complete save solution for games made with Unity 5.

## What's wrong with the original Unity Serializer?
It has been discontinued some time ago. While Unity has been updated a lot, the US (Unity Serializer) hasn't been since 2013. Bug fixes, stability improvements and support for completely new features did not happen.
The way US has been written, ensured that it will be flexible enough to not fully break on each update. As a result, it kept working with Unity 4. However, the Unity 5 update was the straw that finally broke the camel's neck and made US stop working.
unityserializer-ng is a continuation of Mike's excellent project. I decided to fork and change its name, in order to prevent confusion. This fork will not be backwards compatible to the old Unity Serializer.
It's made for Unity 5, which will enable me to remove old legacy bloat whenever I find it. The old Unity Serializer still works for Unity 4.6 and is available for download on the Unity Asset Store.

## What's the goal of this fork?
As stated earlier, the main goal of this fork is to bring the old Unity Serializer to Unity 5. Furthermore, I'll improve on it.
I already fixed quite a few nasty bugs and made sure that this asset works with the new components, that were introduced in the Unity 5 pre-order beta. On top of that, I'll extend already existing functionality.
I want to serialize as much as possible. The original US reduced support of certain components down to the lowest common denominator (see Renderers for a good example).
I will split them up, to ensure that the unique properties of similar components can all be saved.

## Do you support X?
I support Unity 5 (5.4 in particular, although there is a branch for older versions. Bugfixes were not backported). I do not support Unity 4 and older, because the old US is still available. If you want the new features and bug fixes of this for in the old US, you need to backport them yourself.
While the original developer supported iOS and Android, I do not. This does not mean that this asset doesn't work with mobile devices. It just means that I'm no mobile developer and as such have no way of testing it.
The only thing I can guarantee, is that I won't break compatability on purpose. Besites that I removed the iTweenSerializer and PlayMaker addons. Not using those assets myself, I cannot possibly guarantee stability.

## Why was JSON support dopped?
To understand why I dropped such a huge feature, you have to understand where I'm coming from. I did not fork Unity Serializer out of boredom. I forked it, because I use it in a game I am developing.
This explains why I consider certain things to be a waste of time, while others see it differently. JSON support was one such thing. It was broken.
The serializer would throw a fit whenever Renderers were deserialized. I don't know whether other components were broken too, but Renderes were. I spent a couple hours trying to find out what's happening and eventually was able to do so.
The issue boiled down to the serializer using binary deserialization at certain times, when JSON deserialization should have been used. I wasn't able to fix JSON support, without breaking binary serialization. After a couple of hours I finally decided to drop JSON support alltogether.
I develop this asset for my game and I, at no point, had any intention to use JSON serialization for a couple of reasons including JSON serialization...
* creating faaaaar bigger files
* making cheating much easier
* being considerably slower

I did not want to spend more time fixing an issue with a part of the asset, I never wanted to use in the first place. On the bright side, I was able to delete ~9000 lines of code by removing JSON support.
Doing so put a smile on my face, because of how painfully bad the documentation of the original code is.
Almost 9000 less lines of code to worry about.

# What's new?
## Fixes
* "WaitForSeconds" is now correctly being de-/serialized
* Rigidbodies can be deserialized again in Unity 5
* Room Manager no longer crashes the Wizard UI when no Room Manager exists
* "Bounds" are no longer excluded from serialization
* And many more ...

## New features
* Works with Unity 5
* All new material serializer that's far more stable and supports custom shaders and multiple materials
* Extended support for
* Camera
* Line-, Trail- and SkinnedMeshRenderer and Renderer (ParticleRenderer was removed due to being legacy)
* Box-, Capsule-, Mesh-, Wheel- and TerrainColliders
* NavMeshAgent
* AudioFilters
* Sprites
* New Unity GUI components (RectTransform, etc.)
* Limited support for mecanim Animators

# Installation
To install unityserializer-ng, just clone this repository and copy it into your project's directory.

# How to use?
The old tutorials from are available on the website of the original Unity Serializer and still apply. Updated documentation/tutorials will be written and the links will be added here.