import React, { Component } from 'react';

var point = 0;
var showAnswer = false; 

function getDataFromServer(){
    //fancy code...
    let card = {
        question: "?????????",
        answer: "42",
        points: "1337",
        type: "Logic"
    };
    alert(card["question"])
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


function QuestionField(card){
    return(
        <div>
            <p id="type">Art: {card["type"]}</p>
            <p id="points">Mögliche Punkte: {card["points"]}</p>
            <p id="question">{card["question"]}</p>
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
                <textarea id="answer"></textarea>
                <button id="check">Check</button>
                <button id="showAnswer">Show Answer</button>
            </div>
        )
    }

}

export class Main extends Component(){
    constructor(props){
        super(props);
        this.card = getDataFromServer();
        this.points = this.card["points"];
        this.state = {card: getDataFromServer(), showAnswer: false};
    }

    render(){
        return(
            <div>
                <DisplayUserInfo card={this.card}/>
                <QuestionField card={this.card}/>
                <AnswerField/>
            </div>
        );
    }
}