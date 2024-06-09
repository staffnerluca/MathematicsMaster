import React, { } from 'react';
import { Link, useNavigate } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css'; // Make sure to import Bootstrap styles

//future background image: https://pixabay.com/de/illustrations/geometrie-mathematik-volumen-1044090/

export function Login(){
    const navigate = useNavigate(); 

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
        const data = new FormData();
        data.append("username", document.getElementById("inpUsername").value);
        data.append("password", document.getElementById("inpPassword").value);
        try{
            const myUser = await fetch("login", {
                method: "POST",
                body:  data,
            }).then(r=>{
                if(!r.ok){
                    alert("A network error occurred");
                    throw new Error("Network error");
                }
                return r.json();
            });

            if(myUser && myUser !== "nf"){
                localStorage.setItem("user", JSON.stringify(myUser));
                console.log("Login successful");
                navigate("/main");
            } else {
                console.log("User not found");
                // Handle invalid user login here
            }
        }
        catch(error){
            console.error("Something went wrong:", error);
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
};
