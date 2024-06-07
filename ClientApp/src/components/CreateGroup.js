import React, { Component } from 'react';
import {Link} from "react-router-dom";


function CreateGroupBox(){
    return(
        <div className='createThings'>
            <p>: </p><input id="inpGroupName"></input>
            <button></button>
        </div>
    )
}


async function askServerToCreateGroup(){
    //send User and name to server
    //log into group with Group code
}


export function CreateGroup(){
    return(
        <div>
            <CreateGroupBox />
            <button className='btn btn-primary' onClick={() => askServerToCreateGroup}></button>
        </div>
    )
}