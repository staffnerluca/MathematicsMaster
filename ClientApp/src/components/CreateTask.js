import React, { Component } from 'react';
import {Link} from "react-router-dom";

function CreateTaskBox(){
    return(
        <div className='createTaskBox'>
            <p>Typ: </p><input id='inpQuestion' className='usInpCreate' placeholder='A = Algebra, L = Logic, G = Gemoetry'></input>
            <br></br><br></br>
            <p>Question: </p><input id='inpQuestion' className='usInpCreate'></input>
            <br></br><br></br>
            <p>Answer: </p><input id='inpAnswer' className='usInpCreate'></input>
            <br></br><br></br>
            <p>Group: </p><input id="inpGroup" className='usInpCreate'></input>
            <br></br>
            <br></br><button className="btn btn-primary" onClick={sendDataToServer}>Register</button>
            <br></br><br></br>
            <Link to="/">Main</Link>
        </div>
    )
}


async function sendDataToServer(){
    return 0;
}

export class CreateTask extends Component{
    render(){
        return(
            <div className='container d-flex justify-content-center align-items-center vh-100'>
            <div className='text-center'>
            <CreateTaskBox/>
            </div>
        </div>
        )
    }
}