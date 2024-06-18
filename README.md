# Math Master Wie man das Programm ausführen kann
Um den aktuellen Funktionsumfang des Programms zu sehen schauen Sie sich bitte dieses Video an in dem das Wichtigste gezeigt wird: https://youtu.be/34d31cubYEE

Sollten Sie beschliießen es auf Ihrem eigenen Computer laufen zu lassen ist dafür folgendes zu tun (Anleitung erstellt von Lukas Resch):
1. aktuellste Visual Studio Version
2. ASP.NET + Webentwicklung und Node.js Entwicklung
3. Repository klonen
4. Nuget Pakete sollten installiert sein, sonst bitte Visual Studio nochmals neu starten
5. Visual Studio schließen
5. Node installieren (da anscheinend noch nicht drauf) - winget install Schniz.fnm
--> Prebuild Installer (at the Installer: I did tick the thing with C++ but I think it doesn't have to be 
ticked on) - you can install chocolatey (it should do it automaticly in the console)


## Ausführen des Programms nach der Installation von allem Notwendigen:
1. Beim ersten Mal starten des Programms werden alle Abhängigkeiten installiert. Dabei durchlaufen lassen, es besteht die Chance, dass es hier zu einem Fehler kommt ([eslint] Plugin "react" was conflicted between "package.json » eslint-config-react-app » C:\Users\User\Source\Repos\2024-swp-4it-staffnerlresch3\ClientApp\node_modules\eslint-config-react-app\base.js" and "BaseConfig » C:\Users\User\source\repos\2024-swp-4it-staffnerlresch3\ClientApp\node_modules\eslint-config-react-app\base.js".)
2. Visual Studio MUSS neu gestartet werden! Beim erneuten Ausführen des Programms sollte der Fehler von oben verschwinden und das Programm danach vollständig funktionieren.


[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/qBcCQxyG)
[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-718a45dd9cf7e7f842a935f5ebbe5719a5e09af4491e668f4dbf3b35d5cca122.svg)](https://classroom.github.com/online_ide?assignment_repo_id=11936885&assignment_repo_type=AssignmentRepo)
