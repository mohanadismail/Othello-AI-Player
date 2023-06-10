# Othello-AI-Player

## Table of Contents
- [Introduction](#introduction)
- [Game Rules](#game-rules)
- [User Manual](#user-manual)
- [Project Features](#project-features)

## Introduction
This is a project for the course of Artificial Intelligence at Ain Shams University. The goal of the project is to implement an AI player for the game of Othello. The player is implemented using different game searching algorithms like Minimax algorithm and its variant including Alpha-Beta pruning, and using a combination of heuristics based on a [paper](https://courses.cs.washington.edu/courses/cse573/04au/Project/mini1/RUSSIA/Final_Paper.pdf) from University of Washnigton.

## Game Rules
Othello is a strategy board game for two players, played on an 8×8 uncheckered board. There are sixty-four identical game pieces called disks, which are light on one side and dark on the other. Players take turns placing disks on the board with their assigned color facing up. During a play, any disks of the opponent's color that are in a straight line and bounded by the disk just placed and another disk of the current player's color are turned over to the current player's color. The objective of the game is to have the majority of disks turned to display your color when the last playable empty square is filled.

## User Manual
An exe of the game can be found [here]().
The game is played using the mouse. Once you open the exe file, you will be presented with a screen having 3 buttons at the top to choose the game mode. You can play against another human, against the AI, or make two AI players play against each other.
If you're playing against the AI, you can choose what color you want to play with, and also choose the difficulty of the AI player. The difficulty reflects better heuristics and deeper search depth.

## Project Features
### Modes
The game supports 3 different modes of playing:
1.	Human versus human
2.	Human vs AI
3.	AI vs AI

### Difficulty levels
The game supports 3 different difficulties the player can choose for any AI:
1.	Easy
2.	Medium
3.	Hard

### User Interface Features
The user interface supports multiple features:
1.	Displaying of all possible valid moves
2.	Displaying of the score of both players throughout the game
3.	Announcing the winner when no valid moves are left
