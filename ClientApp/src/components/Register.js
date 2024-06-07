import React, { Component } from 'react';
import {Link} from "react-router-dom";
//var bcrypt = require('bcryptjs');

function RegisterBox(){
    return(
        <div className='loginOrRegBox'>
            <p>E-Mail: </p><input id="inpMail" className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Username: </p><input id="inpName" className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Password: </p><input id='inpPassword' type='password' className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Password again: </p><input id="inpPassword2" type='password' className='usInpLogOrRegister'></input>
            <br></br>
            <p>Join Group: </p><input id="inpGroup" className='usInpLogOrRegister'></input>
            <br></br>
            <br></br><button className="btn btn-primary" onClick={sendDataToServer}>Register</button>
            <br></br><br></br>
            <Link to="/">Login</Link>
        </div>
    )
}

function checkIfMailValid(mail){
    if(mail.length > 0 && mail.length < 50){
        let atIsHere = false;
        for(let char of mail){
            if(char === "@"){
                atIsHere = true;
                break;
            }
        }
        if(atIsHere){
            return true;
        }
    }
    return false;
}

async function sendDataToServer(){
    const mail = document.getElementById("inpMail").value;
    alert(mail)
    const name = document.getElementById("inpName").value;
    const password = document.getElementById("inpPassword").value;
    const password2 = document.getElementById("inpPassword2").value;
    const group = document.getElementById('inpGroup').value;
    if(password !== password2){
        alert("The passwords are not the same! Try again.");
        document.getElementById("inpPassword").textContent = "";
        document.getElementById("inpPassword2").textContent = "";
        return;
    }
    if(!checkIfMailValid(mail)){
        alert("The mail is not valid.");
        return;
    }
    try{
        //how often the salt gets computed
        
        /* if you would want to hash it on the client
        const saltRounds = 10;
        const salt = await bcrypt.genSalt(saltRounds);
        const hashedPassword = await bcrypt.hash(password, salt);
        */
        
        const registrationData = {
            name: name,
            mail: mail,
            password: password,
            group: group
        }
        await fetch("register", {
            method: "POST",
            headers: {"Content-type": "application/json"},
            body: JSON.stringify(registrationData)
        })
    }
    catch(error){
        alert("An error occured!"+toString(error));
    }
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