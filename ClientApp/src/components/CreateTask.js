import React, { Component } from 'react';
import {Link} from "react-router-dom";

function CreateTaskBox(){
    return(
        <div className='createTaskBox'>
            <p>Typ: </p><select id='selType' className='usInpCreate' placeholder='A = Algebra, L = Logic, G = Gemoetry'>
                <option>Logic</option>
                <option>Algebra</option>
                <option>Geometry</option>
            </select>
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


function askServerIfGroupExists(group){  
      const handleSubmit = async () => {
        try {
          const response = await fetch('group', {
            method: 'GET',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({ input: group }),
          });
    
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
    
          const result = await response.json();
    
          return result;
        } catch (error) {
          console.error('Error:', error);
          alert('Error communicating with the server.');
          return true;
        }
      };
}


async function sendDataToServer(){
    const type = document.getElementById("selType").value;
    const question = document.getElementById("inpQuestion").value;
    const answer = document.getElementById("inpAnswer").value;
    const group = document.getElementById("inpGroup").value;
    let difficulty = document.getElementById("inpDifficulty").value;
    if(!await askServerIfGroupExists(group) && group != "0"){
        alert("Group doesn't exist.");
        document.getElementById("inpGroup").valu = "";
        return;
    }
    if(typeof difficulty !== "number" || difficulty === ""){
        difficulty = 50;
    }
    const taskData = {
        type: type,
        question: question,
        answer: answer,
        group: group,
        difficulty: difficulty
    }
    try{
        await fetch("task", {
            method: "POST",
            headers: {"Content-type": "application/json"},
            body: JSON.stringify(taskData)
        })

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