import React, { Component } from 'react';
import {Link} from "react-router-dom";


function LoginBox(){
    //        <br></br><button onClick={sendDataToServerAndGetResponse}>Login</button>

    return(
        <div className='loginOrRegBox'>
        <p>Unsername: </p><input className='usInputUsername'></input>
        <br></br><br></br>
        <p>Password: </p><input className='usInputPassword'></input>
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

/*
function sendDataToServerAndGetResponse(){
    let loginData = {
        username: document.getElementsByClassName("usInputUsername").value,
        password: document.getElementsByClassName("usInputPassword").value
    };

    fetch("https://localhost:44488/api/LoginUser", {
        method: "POST",
        headers: {"Content-type": "application/json"},
        body: loginData
        //r is the response from the server. response is the response as json
    }).then(r=>r.json()).then(res=>{
        if(res){
          this.setState({message:'New Employee is Created Successfully'});
        }
    })
}*/

export class Login extends Component{
    render(){
        return(
            <div className='loginOrRegiste'>
                    <LoginBox/>
            </div>
        )
    }
}