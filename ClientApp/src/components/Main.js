import React, { Component } from 'react';
import "./main.css"
var point = 0;
var showAnswer = false; 

async function getDataFromServer(){
    const response = await fetch("Tasks")
    .then(alert("Got something"));
    /*let filter = {
        "type": "A",
        "difficulty": "100"
    }

    const response = await fetch("task", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(filter)
    })*/

    const data = await response.json()
    console.log(data);
    //fancy code...
    let card = {
        question: `Die Osloer Bank gibt Münzen aus Aluminium (mit A bezeichnet) und aus Bronze (mit B bezeichnet) heraus. Marianne hat n 
        Aluminiummünzen und n Bronzemünzen beliebig in einer Reihe angeordnet. Eine
        Kette sei eine Teilfolge aufeinanderfolgender Münzen aus gleichem
        Material. Für eine gegebene positive ganze Zahl k 6 2n führt Marianne wiederholt die folgende
        Operation durch: Sie identifiziert die längste Kette, die die k -te Münze von links enthält, und
        verschiebt alle Münzen dieser Kette an das linke Ende der Reihe. Zum Beispiel erhält sie für
        n = 4 und k = 4 ausgehend von der Konfguration AABBBABA nacheinander
        AABBBABA → BBBAAABA → AAABBBBA → BBBBAAAA → BBBBAAAA → · · · .
        Man bestimme alle Paare (n, k) mit 1 6 k
        6 2n, sodass für jede Ausgangskonfiguration zu
        irgendeinem Zeitpunkt im Verlauf des Prozesses die n am weitesten links liegenden Münzen aus
        dem gleichen Material sind.`,
        answer: "42",
        points: "1337",
        type: "Logic"
    };
    return card
}

function getUserData(){
    let user = {
        dNamme: "Luggi",
        points: 10
    };
    return user;
}

function DisplayUserInfo(){
    getUserData()
}


function QuestionField(cards){
    const card = getDataFromServer();
    return(
        <div>
            <p id="type">Art: {card["type"]}</p>
            <p id="points">Mögliche Punkte: {card["points"]}</p>
            <p className="lblQuestion" id="question">{card["question"]}</p>
        </div>
    )
}

function updatePoints(points){
    //fancy stuff
    console.log("Writing points");
}

function AnswerField(card, points){
    if(showAnswer){
        let correct = false;
        let userA = document.getElementById("answer");
        if (userA == card["answer"]){
            correct = true;
            updatePoints()
            return(
                <div id="correct">{card["answer"]}</div>
            )
        }
       
    }

    else{
        return(
            <div>
                <textarea id="taAnswer"></textarea><br></br>
                <button className="btn btn-primary" id="check">Check</button>
                <button className="btn btn-primary" id="showAnswer">Show Answer</button>
            </div>
        )
    }
}

export class Main extends Component{
    constructor(props){
        super(props);
        this.card = getDataFromServer();
        this.points = this.card["points"];
        this.state = {card: getDataFromServer(), showAnswer: false};
    }

    render(){
        return(
            <div>
                <center><h1>TASKS</h1></center><h1></h1>
                <div className='container d-flex justify-content-center align-items-center vh-100'>
                    <div className='text-center'>
                        <DisplayUserInfo card={this.card}/>
                        <QuestionField card={this.card}/>
                        <AnswerField/>
                    </div>
                </div>
            </div>
        );
    }
}