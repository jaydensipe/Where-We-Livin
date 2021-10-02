<!-- PROJECT LOGO -->
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

This is an application (that plays like a game) that allows you to go through all 50 U.S. states and vote "Yes", "Maybe", "No" on them and see the most picked and least picked results at the end. 
It can be played both singleplayer and multiplayer.

When talking with friends or family about the future, a topic that comes up a lot is potential places everyone would want to move to. I've always wanted an easy way to compile
all these answers together to see if anyone shares common ground in their decisions. While that is my intended purpose for the application, it can be used in deciding any number of things, such as where to go on vacation, etc.
### Development Tools

* C#
* Rider IDE

### Frameworks Used

* Json.NET


<!-- USAGE EXAMPLES -->
## Getting Started

This application requires a server and a client to function. This section will show you how to host your server to connect to and play solo, or have your friends connect to you.

Project Download: link here<br/>
Run WhereWeLivin.exe to use.<br/><br/><br/>

### Host Setup

1. Enter the information you want to host at and press host. The server address is typically the IPv4 address of your computer (ipconfig in cmd.exe) and the port is a port you will need to open through port forwarding.

[![Image from Gyazo](https://i.gyazo.com/006a8295b65152e7e6acbc36d112e334.png)](https://gyazo.com/006a8295b65152e7e6acbc36d112e334)
    
2. Wait for clients to connect to your server (through specified IPv4 address and port).

[![Image from Gyazo](https://i.gyazo.com/ed167b2dacc7365b80a46b23e8e0e723.png)](https://gyazo.com/ed167b2dacc7365b80a46b23e8e0e723)

3. Once ready, press start game. Clients names will turn RED indicating they have not chosen an answer. Once they they have chosen, their name will turn GREEN. Once all clients names are GREEN (or whenever you want) pressing next round will send the clients a new state.

[![Image from Gyazo](https://i.gyazo.com/7f4aa3375378de917703908520b408f2.png)](https://gyazo.com/7f4aa3375378de917703908520b408f2)

<br/> <br/>
### Client Setup

1. Enter the information you want to connect to and press connect. If you are playing SOLO or WITH FRIENDS, this will be the IPv4 address and port of whoever is hosting.

[![Image from Gyazo](https://i.gyazo.com/006a8295b65152e7e6acbc36d112e334.png)](https://gyazo.com/006a8295b65152e7e6acbc36d112e334)

2. Once connected, you must wait for the host to start the game.

[![Image from Gyazo](https://i.gyazo.com/10ab446c531c1428230c22031e37bd55.png)](https://gyazo.com/10ab446c531c1428230c22031e37bd55)

3. When the host starts the game, you will be greeted with a U.S. state and the options "Yes", "Maybe", "No". These answers correspond to whatever reason you have for playing.

[![Image from Gyazo](https://i.gyazo.com/b2f7a3235e6065940998a0fa4ba19937.png)](https://gyazo.com/b2f7a3235e6065940998a0fa4ba19937)
[![Image from Gyazo](https://i.gyazo.com/00e22bd9750452638645934e96420f19.png)](https://gyazo.com/00e22bd9750452638645934e96420f19)

4. Once the game is finished, players will be greeted with a screen that displays the top 10 and least 10 picked states calculated from everyone's choices.

[![Image from Gyazo](https://i.gyazo.com/46ea5d93b535d827dc78ee2769f26b94.png)](https://gyazo.com/46ea5d93b535d827dc78ee2769f26b94)

<!-- CONTACT -->
## Contact

Website/Portfolio - [https://jaydensipe.github.io/](https://jaydensipe.github.io/)

Project Link: [https://github.com/jaydensipe/WhereWeLivin](https://github.com/jaydensipe/WhereWeLivin)

