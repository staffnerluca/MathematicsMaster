import React, { Component, useState } from 'react';
import "./main.css"
var point = 0;
var showAnswer = false; 

async function getDataFromServer(apiPath) {
    let response = "Somtething went wrong";
    try {
        response = await fetch("task", {
        headers: {
          'Accept': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      const card = await response.json();
      alert("The Question"+data["question"])
      alert("Got something from Tasks:\n" + JSON.stringify(data));
      return card;
     
    } catch (error) {
      console.error("Error fetching data:", error.message);
    }

    const data = await response.json()
    console.log(data);
    //fancy code...
    let card = {
        question: "Something went wrong",
        answer: "Try again",
        points: "not working",
        type: "sad smiley"
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

export function Main(){
    const [card, setCard] = useState({});

    function loadTask() {
        setCard(getDataFromServer());    
    }
        
    return(
            <div>
                <center><h1>TASKS</h1></center><h1></h1>
                <button className='btn btn-primary' onClick={loadTask}>Load task</button>
                <div className='container d-flex justify-content-center align-items-center vh-100'>
                    <div className='text-center'>
                        <DisplayUserInfo card={card}/>
                        <QuestionField card={card["question"]}/>
                        <AnswerField/>
                    </div>
                </div>
            </div>
        );
}