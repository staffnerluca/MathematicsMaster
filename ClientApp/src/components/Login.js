import React, { Component } from 'react';
import {Link} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css'; // Make sure to import Bootstrap styles

//future background image: https://pixabay.com/de/illustrations/geometrie-mathematik-volumen-1044090/



export function Login(){
    function LoginBox(){
        return(
            <form>
                <div className='loginOrRegBox'>
                <p>Username: </p><input id="inpUsername" name="username" className='usInputUsername'></input>
                <br></br><br></br>
                <p>Password: </p><input id="inpPassword" name="password" type="password" className='usInputPassword'></input>
                <br></br>
                <Link to="/Register">Register</Link>
                </div>
            </form>
        )
    }
    
    
    async function sendDataToServerAndGetResponse(){
        let loginData = {
            username: document.getElementById("inpUsername").value,
            password: document.getElementById("inpPassword").value
        };
        try{
            console.log(loginData);
            const myUser = await fetch("login", {
                method: "POST",
                headers: {"Content-type": "application/json"},
                body: loginData
                //r is the response from the server. res is the response as json
            }).then(r=>{
                if(!r.ok){
                    alert("A network error occurde");
                }
                return r.json
            })
            .then(user => {
                if(user && user !== "nf"){
                    localStorage.setItem("user", JSON.stringify(user));
                    console.log("Login successeful");
                }
            })
        }
        catch(error){
            console.error("Something went wrong");
        }
    }


    return(
        <div className='container d-flex justify-content-center align-items-center vh-100'>
            <div className='text-center'>
            <LoginBox/>
                <button className='btn btn-primary' onClick={sendDataToServerAndGetResponse}>Login</button>
            </div>
        </div>
    )
}