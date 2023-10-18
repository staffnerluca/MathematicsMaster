import React, { Component } from 'react';
import {Link} from "react-router-dom";

function RegisterBox(){
    return(
        <div className='loginOrRegBox'>
        <p>Unsername: </p><input className='usInpLogOrRegister'></input>
        <br></br><br></br>
        <p>Password: </p><input className='usInpLogOrRegister'></input>
        <br></br><button onClick={sendDataToServer}>Login</button>
        <br></br>
        <Link to="/Login">Login</Link>
        </div>
    )
}

function sendDataToServer(){
    
}

export class Register extends Component{
    constructor(props){
        super(props);
    }
    render(){
        return(
            <div>
                <RegisterBox/>
            </div>
        );
    }
}