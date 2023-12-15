import React, { Component } from 'react';
import {Link} from "react-router-dom";

function RegisterBox(){
    return(
        <div className='loginOrRegBox'>
            <p>E-Mail: </p><input id="inpMail" className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Username: </p><input id="inpName" className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Password: </p><input className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Password again: </p><input id="inpPassword2" className='usInpLogOrRegister'></input>
            <br></br>
            <br></br><button className="btn btn-primary" onClick={sendDataToServer}>Register</button>
            <br></br><br></br>
            <Link to="/">Login</Link>
        </div>
    )
}

function checkIfMailValid(mail){
    let atIsHere = false;
    for(let char in mail){
        if(char === "@"){
            atIsHere = true;
        }
    }
    if(atIsHere){
        return true;
    }
    return false;
}

async function sendDataToServer(){
    const mail = document.getElementById("mail");
    const name = document.getElementById("inpName");
    const password = document.getElementById("inpPassword1")
    const password2 = document.getElementById("inpPassword2")
    if(password !== password2){
        alert("The passwords are not the same! Try again.");
        document.getElementById("password1").textContent = "";
        document.getElementById("password2").textContent = "";
        return;
    }
    if(!checkIfMailValid(mail)){
        alert("The mail is not valid.");
        return;
    }
    const registrationData = {
        name: "luggi"
    }
    const send = await fetch("register", {
        method: "POST",
        headers: {"Content-type": "application/json"},
        body: registrationData
    })
    return 0;
}

export class Register extends Component{
    render(){
        return(
            <div className='container d-flex justify-content-center align-items-center vh-100'>
            <div className='text-center'>
            <RegisterBox/>
            </div>
        </div>
        )
    }
}