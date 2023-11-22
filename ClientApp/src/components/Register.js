import React, { Component } from 'react';
import {Link} from "react-router-dom";

function RegisterBox(){
    return(
        <div className='loginOrRegBox'>
        <p>Unsername: </p><input className='usInpLogOrRegister'></input>
        <br></br><br></br>
        <p>Password: </p><input className='usInpLogOrRegister'></input>
        <br></br><br></br>
        <p>Password again: </p><input className='usInpLogOrRegister'></input>
        <br></br>
        <br></br><button onClick={sendDataToServer}>Register</button>
        <br></br><br></br>
        <Link to="/">Login</Link>
        </div>
    )
}

function sendDataToServer(){
    return 0;
}

export class Register extends Component{
    render(){
        return(
            <div className='loginOrRegiste'>
                <RegisterBox />
            </div>
        )
    }
}