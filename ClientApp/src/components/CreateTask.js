import React, { Component } from 'react';
import {Link} from "react-router-dom";
import { diff } from 'semver';

function CreateTaskBox(){
    return(
        <div className='createTaskBox'>
            <p>Typ: </p><select id='selType' className='usInpCreate' placeholder='A = Algebra, L = Logic, G = Gemoetry'>
                <option>Logic</option>
                <option>Algebra</option>
                <option>Geometry</option>
            </select>
            <br></br><br></br>
            <p>Name: </p><input id='inpName' className='usInpCreate'></input>
            <br></br><br></br>
            <p>Question: </p><input id='inpQuestion' className='usInpCreate'></input>
            <br></br><br></br>
            <p>Answer: </p><input id='inpAnswer' className='usInpCreate'></input>
            <br></br><br></br>
            <p>Group (0 means it is available for everyone): </p><input id="inpGroup" className='usInpCreate'></input>
            <br></br><br></br><br></br>
            <p>Estimated difficulte (optional): </p>
            <p>0 to 10 easy, 10 - 35 easy medium, 35 - 65 medium, 65 - 80 hard, 80 - 100 really hard</p><br></br>
            <input id="inpDifficulty" className='usInpCreate'></input>
            <br></br>
            <br></br><button className="btn btn-primary" onClick={sendDataToServer}>Create Task</button>
            <br></br><br></br>
            <Link to="/">Main</Link>
        </div>
    )
}


async function askServerIfGroupExists(group){  
        try {
          const response = await fetch('group'+"?name="+group, {
            method: 'GET',
            headers: {
              'Content-Type': 'application/json',
            },
          });
    
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
    
          const result = await response.json();
          console.log("result");
          return result;
        } catch (error) {
          console.error('Error:', error);
          alert('Error communicating with the server.');
          return true;
        }
    }


async function sendDataToServer(){
    const name = document.getElementById("inpName").value;
    let type = document.getElementById("selType").value;
    const question = document.getElementById("inpQuestion").value;
    const answer = document.getElementById("inpAnswer").value;
    let group = parseInt(document.getElementById("inpGroup").value);
    let difficulty = parseInt(document.getElementById("inpDifficulty").value);
    const exists = await askServerIfGroupExists(group)
    console.log("does the group exist: "+exists);

    if(!exists && group != 0){
        alert("Group doesn't exist. Stored for all");
        document.getElementById("inpGroup").value = "";
        group = 0;
    }
    if(typeof difficulty !== "number" || difficulty === ""){
        difficulty = 50;
    }
    console.log(type);
    switch(type){
        case "Logic":
            type = "l";
            break;
        case "Algebra":
            type = "a";
            break;
        case "Geometr":
            type = "g";
            break;
        default:
            type = "n"
    }
    console.log(type);
    const taskData = new FormData();
    taskData.append("name", name);
    taskData.append("type", type);
    taskData.append("question", question);
    taskData.append("answer", answer);
    taskData.append("group", group);
    taskData.append("difficulty", difficulty);
    console.log("Task Data:", Object.fromEntries(taskData)); // Convert FormData to object for logging
    try{
        await fetch("task", {
            method: "POST",
            body: taskData
        })
        document.getElementById("inpName").value = "";
        document.getElementById("selType").value = "";
        document.getElementById("inpQuestion").value = "";
        document.getElementById("inpAnswer").value = "";
        document.getElementById("inpGroup").value = "";
        document.getElementById("inpDifficulty").value = "";


    }catch(error){
       alert("An error occurde. Please try again.")     
    }
}

export class CreateTask extends Component{
    render(){
        return(
            <div className='container d-flex justify-content-center align-items-center vh-100'>
            <div className='text-center'>
            <CreateTaskBox/>
            </div>
        </div>
        )
    }
}