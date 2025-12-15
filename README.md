<!-- PROJECT LOGO -->
<br/>
<p align="center">
  <a href="https://github.com/jaydensipe/WhereWeLivin">
    <img src="logo.png" alt="Logo">
  </a>
  <p align="center">
    Helps people choose a potential spot to move or vacation too in a fun game-like style. (BOTH Singleplayer and Multiplayer)!
    <br />
  </p>
</p>


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#development-tools">Tools Used</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#host-setup">Host</a></li>
        <li><a href="#client-setup">Client</a></li>
      </ul>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>


<!-- ABOUT THE PROJECT -->
## About The Project

This is an application (that plays like a game) that allows you to go through all 50 U.S. states and vote "Yes", "Maybe" or "No" on them and see the most picked and least picked results at the end. 
It can be played both singleplayer and multiplayer.

When talking with friends or family about the future, a topic that comes up a lot is potential places everyone would want to move to. I've always wanted an easy way to compile
all these answers together to see if anyone shares common ground in their decisions. While that is my intended purpose for the application, it can be used in deciding any number of things, such as where to go on vacation, etc.
### Development Tools

* .NET Framework
* Rider IDE

### Frameworks Used

* Json.NET


<!-- USAGE EXAMPLES -->
## Getting Started

This application requires a server and a client to function. This section will show you how to host your server to connect to and play solo, or have your friends connect to you.

<b>Project Download:</b> [https://drive.google.com/file/d/1VOvoJ_6p3fezrshEjktIMiMAiRYsvNno/view?usp=sharing](https://drive.google.com/file/d/1VOvoJ_6p3fezrshEjktIMiMAiRYsvNno/view?usp=sharing)<br/><br/><br/>

### Host Setup

1. Enter the information you want to host at and press host. The server address is typically the IPv4 address of your computer (ipconfig in cmd.exe) and the port is a port you will need to open through port forwarding.

    
2. Wait for clients to connect to your server (through specified IPv4 address and port).

3. Once ready, press start game. Clients names will turn RED indicating they have not chosen an answer. Once they have chosen, their name will turn GREEN. Once all clients names are GREEN (or whenever you want) pressing next round will send the clients a new state.
   
### Client Setup

1. Enter the information you want to connect to and press connect. If you are playing SOLO or WITH FRIENDS, this will be the public IP address and port of whoever is hosting.

2. Once connected, you must wait for the host to start the game.

3. When the host starts the game, you will be greeted with a U.S. state and the options "Yes", "Maybe" or "No". These answers correspond to whatever reason you have for playing.

4. Once the game is finished, players will be greeted with a screen that displays the top 10 and least 10 picked states calculated from everyone's choices.

<!-- CONTACT -->
## Contact

Website/Portfolio - [https://jaydensipe.github.io/](https://jaydensipe.github.io/)

Project Link: [https://github.com/jaydensipe/Where-We-Livin](https://github.com/jaydensipe/Where-We-Livin)

