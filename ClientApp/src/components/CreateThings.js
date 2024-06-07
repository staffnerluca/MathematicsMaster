import React, { Component, useState } from 'react';
import {Link, useNavigate} from "react-router-dom";

//menu for all the components that create stuff
export function CreateThings(){
    const [user, setUser] = useState(null);
    const navigate = useNavigate();
    
    //get the user
    /*
    useEffect(() => {
        const json_user = localStorage.getItem('user');
        if (json_user) {
            setUser(JSON.parse("storedUser"));
        }
    }, []);*/

    
    function CreateTaskMenu(){
        return(
            //if(user{isTeacher}){}
            <button className='btn btn-primary' onClick={() => navigate("/createTask")}>Create Task</button>
        )
    }

    function CreateInstitutionMenu(){
        return(
            <button className='btn btn-primary' onClick={() => navigate("/createInstitution")}>Create institute</button>
        )
    }

    function CreateGroupMenu(){
        return(
            <button className='btn btn-primary' onClick={() => navigate("/createGroup")}>Create group</button>
        )
    }

    return(
        <div className='container d-flex justify-content-center align-items-center vh-100'>
                <div className='text-center'>
                    <h1>Select what to create</h1>
                    <CreateTaskMenu />
                    <br></br><br></br>
                    <CreateGroupMenu />
                    <br></br><br></br>
                    <CreateInstitutionMenu />
            </div>
        </div>
    )
}