import React, { Component } from 'react';
import {Link} from "react-router-dom";



function LoginBox(){
    return(
        <div className='loginOrRegBox'>
        <p>Unsername: </p><input className='usInpLogOrRegister'></input>
        <br></br><br></br>
        <p>Password: </p><input className='usInpLogOrRegister'></input>
        <br></br><button onClick={sendDataToServerAndGetResponse}>Login</button>
        <br></br>
        <Link to="/Register">Register</Link>
        </div>
    )
}

/*
function getRegisterAddress(){
    let url = document.URL;
    url = url.slice(0, -5);
    url += "Register"
    return url
}*/

function sendDataToServerAndGetResponse(){

}

export class Login extends Component{
    render(){
        return(
            <div>
                <center>
                    <LoginBox/>
                </center>
            </div>
        )
    }
}