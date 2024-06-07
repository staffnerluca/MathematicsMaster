import React, { Component } from 'react';
import {Link} from "react-router-dom";


function CreateInstitutionsBox(){
    return(
        <div className='loginOrRegBox'>
            <p>Name of the institute: </p><input id="inpInstName" className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Address: </p><input id="inpAddress" className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <p>Admin mail: </p><input id='inpAdminMail' type='text' className='usInpLogOrRegister'></input>
            <br></br><br></br>
            <br></br><button className="btn btn-primary" onClick={sendDataToServer}>Register</button>
            <br></br><br></br>
            <Link to="/">Login</Link>
        </div>
    )
}


async function sendDataToServer(){
    const instName = document.getElementById("inpInstName").value;
    const address = document.getElementById("inpAddress").value;
    const adminMail = document.getElementById("inpAdminMail").value;
    try{
        const registrationData = {
            institutionName: instName,
            adminMail: adminMail,
            address: address,
        }
        await fetch("createInstitution", {
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

export class CreateInstitution extends Component{
    render(){
        return(
            <div className='container d-flex justify-content-center align-items-center vh-100'>
            <div className='text-center'>
            <CreateInstitutionsBox/>
            </div>
        </div>
        )
    }
}