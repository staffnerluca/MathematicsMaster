import React, { Component } from 'react';

var point = 0;
function getDataFromServer(){
    //fancy code...
    let card = {
        question: "?????????",
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


function QuestionField(card){
    return(
        <div>
            <p id="type">Art: {card[type]}</p>
            <p id="points">Mögliche Punkte: card[points]</p>
            <p id="question">{card[question]}</p>
        </div>
    )
}

function AnswerField(card){
    return(
        <div>
            <textarea id="answer"></textarea>
            <button id="check">Check</button>
            <button id="showAnswer">Show Answer</button>
        </div>
    )
}

export class Main extends Component(){
    render(){
        return(
            <div>
                <DisplayUserInfo/>
                <QuestionField/>
                <AnswerField/>
            </div>
        );
    }
}