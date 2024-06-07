import React, { Component } from 'react';
import {Link} from "react-router-dom";


function CreateGroupBox(){
    return(
        <div className='createThings'>
            <p>Group name (will be used to join the group and must be unique): </p>
            <input id="inpGroupName"></input>
        </div>
    )
}


async function askServerToCreateGroup(){
    //send User and name to server
    //log into group with Group code
    const groupName = document.getElementById("inpGroupName").value;
    if(doesGroupExist(groupName)){
        try{
            const groupData = {
                code: groupName
            }
            await fetch("createGroup", {
                method: "POST",
                headers: {"Content-type": "application/json"},
                body: JSON.stringify(groupData)
            })
        }
        catch(error){
            alert("An error occured!"+toString(error));
        }
            return 0;
    }
}



function doesGroupExist(name){  
    const getFromServer = async () => {
      try {
        const response = await fetch('checkIfGroupExists', {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({ input: name }),
        });
  
        if (!response.ok) {
          throw new Error('Something went wrong');
        }
        const exists = await response.json();
        return exists;
      } catch (error) {
        console.error('Error:', error);
        alert('Error communicating with the server.');
        return true; //change to false when server is functioning, only for test purposes true
      }
    }
}

export function CreateGroup(){
    return(
        <div className='container d-flex justify-content-center align-items-center vh-100'>
            <div className='text-center'>
                <CreateGroupBox />
                <br></br>
                <button className='btn btn-primary' onClick={() => askServerToCreateGroup}>Create Task</button>
            </div>
        </div>
    )
}