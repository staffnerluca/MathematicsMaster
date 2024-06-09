import React, { Component } from 'react';
import {Link} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css'; // Make sure to import Bootstrap styles

//future background image: https://pixabay.com/de/illustrations/geometrie-mathematik-volumen-1044090/

function LoginBox(){
    return(
        <form>
            <div className='loginOrRegBox'>
            <p>Username: </p><input id="inpUsername" name="username" className='usInputUsername'></input>
            <br></br><br></br>
            <p>Password: </p><input id="inpPassword" name="password" className='usInputPassword'></input>
            <br></br>
            <Link to="/Register">Register</Link>
            </div>
        </form>
    )
}


function getRegisterAddress(){
    let url = document.URL;
    url = url.slice(0, -5);
    url += "Register"
    return url
}


async function sendDataToServerAndGetResponse(){
    let loginData = {
        username: document.getElementById("inpUsername").value,
        password: document.getElementById("inpPassword").value
    };
    console.log(loginData);
    const response = await fetch("login");
    const user = await response.json();
    await fetch("userdata", {
        method: "POST",
        headers: {"Content-type": "application/json"},
        body: loginData
        //r is the response from the server. response is the response as json
    }).then(r=>r.json()).then(res=>{
        if(res){
          this.setState({message:'New Employee is Created Successfully'});
        }
    })
    const success = true;
    if(success){
        window.location.href = window.location.href+"Main";
        return;
    }
    alert("Username or password wrong");
}

export class Login extends Component{
    render(){
        return(
            <div className='container d-flex justify-content-center align-items-center vh-100'>
                <div className='text-center'>
                <LoginBox/>
                    <button className='btn btn-primary' onClick={sendDataToServerAndGetResponse}>Login</button>
                </div>
            </div>
        )
    }
}